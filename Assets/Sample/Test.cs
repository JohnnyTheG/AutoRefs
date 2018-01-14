using UnityEngine;
using System.Collections.Generic;

public class Test : MonoBehaviour
{
	[AutoRef]
	[SerializeField]
	TestRef cTestRef;

	[AutoRef]
	[SerializeField]
	TestRef[] acTestRef;

	[AutoRef]
	[SerializeField]
	List<TestRef> lstTestRef;

	[AutoRef]
	int nBadTestRef;
}
