using System.Collections;
using System.Collections.Generic;
using System;
using System.Reflection;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

public class AutoRefs : Editor
{
	[MenuItem("AutoRefs/GetAutoRefs")]
	static void GetAutoRefs()
	{
		// Get all game objects.
		GameObject[] acGameObjects = FindObjectsOfType<GameObject>();

		for (int nGameObject = 0; nGameObject < acGameObjects.Length; nGameObject++)
		{
			GameObject cGameObject = acGameObjects[nGameObject];

			// Get all MonoBehaviours attached to the current GameObject.
			MonoBehaviour[] acMonoBehaviours = cGameObject.GetComponents<MonoBehaviour>();

			for (int nMonoBehaviour = 0; nMonoBehaviour < acMonoBehaviours.Length; nMonoBehaviour++)
			{
				MonoBehaviour cMonoBehaviour = acMonoBehaviours[nMonoBehaviour];

				// Get the type of the MonoBehaviour.
				Type cType = cMonoBehaviour.GetType();

				// Get each of the fields.
				FieldInfo[] acFieldInfos = cType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

				for (int nFieldInfo = 0; nFieldInfo < acFieldInfos.Length; nFieldInfo++)
				{
					FieldInfo cFieldInfo = acFieldInfos[nFieldInfo];

					// Check that field for the AutoRef attribute.
					AutoRefAttribute cAutoRef = Attribute.GetCustomAttribute(cFieldInfo, typeof(AutoRefAttribute)) as AutoRefAttribute;

					// If it is marked to be set up as an automatic reference.
					if (cAutoRef != null)
					{
						// Get the field type.
						Type cFieldType = cFieldInfo.FieldType;

						// Get the component on the object which matches the required type.
						try
						{
							// Check to see if the field is an array.
							if (cFieldType.IsArray)
							{
								// Get the element type of the array (i.e. int[] the element type is int).
								Type cFieldElementType = cFieldType.GetElementType();

								// Find all components which match that element type (may be multiple components).
								Component[] acComponents = cGameObject.GetComponents(cFieldElementType);

								// Create an array of the element type with the same length as the array of components which were found.
								// This is necessary to convert the Component[] type array into an array of the type specified in the FieldInfo.
								// i.e. The FieldInfo may be an array MyClass[]. You cannot set the value of a MyClass[] to a Component[].
								Array cArrayObject = Array.CreateInstance(cFieldElementType, acComponents.Length);

								// For each component which was found, copy it into the correctly typed array.
								for (int nComponent = 0; nComponent < acComponents.Length; nComponent++)
								{
									cArrayObject.SetValue(acComponents[nComponent], nComponent);
								}

								// Set the value of the FieldInfo to the newly created array.
								cFieldInfo.SetValue(cMonoBehaviour, cArrayObject);
							}
							// Check to see if the field is a generic type.
							else if (cFieldType.IsGenericType)
							{
								// Check to see if the field is a list.
								if (cFieldType.GetGenericTypeDefinition() == typeof(List<>))
								{
									// Get the element type of the list (only 1 argument for a list, so always [0]).
									Type cFieldElementType = cFieldType.GetGenericArguments()[0];

									// Find all components which match that element type (may be multiple components).
									Component[] acComponents = cGameObject.GetComponents(cFieldElementType);

									// Get the type of a list of the field element type.
									Type cListOfElementsType = typeof(List<>).MakeGenericType(cFieldElementType);

									// Create an IList of the correct type.
									IList cIList = Activator.CreateInstance(cListOfElementsType) as IList;

									// For each component which was found, copy it into the IList.
									for (int nComponent = 0; nComponent < acComponents.Length; nComponent++)
									{
										cIList.Add(acComponents[nComponent]);
									}

									// Set the value of the FieldInfo to the value of the IList, which fills the original list.
									cFieldInfo.SetValue(cMonoBehaviour, cIList);
								}
							}
							else
							{
								// Find a component with a matching type to the field.
								Component cComponent = cGameObject.GetComponent(cFieldType);

								// If that component exists.
								if (cComponent != null)
								{
									// Set the value of that field on the monobehaviour to match the found component.
									// This is where the reference is set.
									cFieldInfo.SetValue(cMonoBehaviour, cComponent);
								}
							}
						}
						catch (ArgumentException)
						{
							Debug.LogError("AutoRefs: An incompatible type has been annotated with the [AutoRef] attribute.\nType: [" + cFieldType.Name + "]	MonoBehaviour: [" + cMonoBehaviour.name + "]	Field: [" + cFieldInfo.Name + "]");
						}
					}
				}
			}
		}
	}

	[PostProcessScene]
	static void OnPostProcessScene()
	{
		GetAutoRefs();
	}
}
