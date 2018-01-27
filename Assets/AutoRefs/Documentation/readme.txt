== AutoRefs ==

Automatic component referencing for Unity.


== Author == 

John Gray 

http://www.johnnygray.co.uk


== Instructions ==

Simply annotate any reference in your Unity scripts with the [AutoRef] attribute and one or more target types which specify where the references are expected to be exist in your scene.

Supported target types are as follows:

- Self: The reference/references exist on the GameObject with the component class containing variables using the [AutoRef] attribute.
- Parent: The reference/references exist on the parent GameObject of the GameObject with the component class containing variables using the [AutoRef] attribute.
- Children: The reference/references exist on the children GameObjects of the GameObject with the component class containing variables using the [AutoRef] attribute.
- Siblings: The reference/references exist on GameObjects which share the same parent GameObject of the GameObject with the component class containing variables using the [AutoRef] attribute.
- Scene: The reference/references exist on any GameObject found within the same scene file.

To set the references automatically either select the "Tools/AutoRefs/Set AutoRefs" option in the Unity inspector menu, press the play button or build the project. By selecting the "Tools/AutoRefs/Set AutoRefs" menu option, the references are set without the Unity player running, which allows the references found to be saved into the scene file. The other methods will set the references but will not save them as the references are set at runtime. After exiting the player runtime, the changes are discarded and the references will appear as unassigned in the Unity inspector again.


== Example ==

An example of setting references in a class using AutoRefs can be seen below:

public class BasicExample : MonoBehaviour
{
	// This is an example of an AutoRef setting a reference to an
	// instance of a class which exists on the same game object.
	[AutoRef(AutoRefTargetType.Self)]
	[SerializeField]
	TestRef m_TestAutoRef;

	// This is an example of a TestRef reference which is not set by AutoRef.
	[SerializeField]
	TestRef m_NotAnAutoRef;

	// This is an example of an AutoRef being applied to an
	// array of references to components on the same game object.
	[AutoRef(AutoRefTargetType.Self)]
	[SerializeField]
	TestRef[] m_TestAutoRefArray;

	// This is an example of an AutoRef being applied to an
	// list of references to components on the same game object.
	[AutoRef(AutoRefTargetType.Self)]
	[SerializeField]
	List<TestRefAlternate> m_TestAutoRefAlternateList;

	// Example of AutoRef being used with a Unity built in component type.
	[AutoRef(AutoRefTargetType.Self)]
	[SerializeField]
	Rigidbody m_Rigidbody;

	// Example of AutoRef being used to get the transform of the GameObject.
	[AutoRef(AutoRefTargetType.Self)]
	[SerializeField]
	Transform m_Transform;

	// Example of AutoRef being used to get all instances of a base class component.
	[AutoRef(AutoRefTargetType.Self)]
	[SerializeField]
	List<Collider> m_Colliders;
}

The example above and further examples can be found in the "Examples" folder of the unitypackage file for AutoRefs.


== Support ==

If you require further support or find a bug please email unity@johnnygray.co.uk