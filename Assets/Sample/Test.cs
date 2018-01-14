using UnityEngine;
using System.Collections.Generic;

public class Test : MonoBehaviour
{
	// This is an example of an AutoRef setting a reference to an
	// instance of a class which exists on the same game object.
	[AutoRef]
	[SerializeField]
	TestRef cTestRef;

	// This is an example of an AutoRef being applied to an
	// array of references to components on the same game object.
	[AutoRef]
	[SerializeField]
	TestRef[] acTestRef;

	// This is an example of an AutoRef being applied to an
	// list of references to components on the same game object.
	[AutoRef]
	[SerializeField]
	List<TestRefAlternate> lstTestRefAlternative;

	// This is an example of an AutoRef being applied to an
	// incompatible data type.
	[AutoRef]
	int nBadTestRef;
}
