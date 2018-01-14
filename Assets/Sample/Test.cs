using UnityEngine;
using System.Collections.Generic;

public class Test : MonoBehaviour
{
	// This is an example of an AutoRef setting a reference to an
	// instance of a class which exists on the same game object.
	[AutoRef]
	[SerializeField]
	TestRef m_TestAutoRef;

	[SerializeField]
	TestRef m_NotAnAutoRef;

	// This is an example of an AutoRef being applied to an
	// array of references to components on the same game object.
	[AutoRef]
	[SerializeField]
	TestRef[] m_TestAutoRefArray;

	// This is an example of an AutoRef being applied to an
	// list of references to components on the same game object.
	[AutoRef]
	[SerializeField]
	List<TestRefAlternate> m_TestAutoRefAlternateList;

	// This is an example of an AutoRef being applied to an
	// incompatible data type.
	//[AutoRef]
	//int m_BadTestRefInt;

	// Example of AutoRef being used with a Unity built in component type.
	[AutoRef]
	[SerializeField]
	Rigidbody m_Rigidbody;

	// Example of AutoRef being used to get the transform of the GameObject.
	// This is useful as it caches the Transform rather than .transform which gets it each time.
	[AutoRef]
	[SerializeField]
	Transform m_Transform;

	// Example of AutoRef being used to get all instances of a base class component.
	[AutoRef]
	[SerializeField]
	List<Collider> m_Colliders;
}
