using UnityEngine;
using System.Collections.Generic;

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
