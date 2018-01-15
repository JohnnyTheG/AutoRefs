using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedExample : MonoBehaviour
{
	[AutoRef(AutoRefTargetType.Self)]
	[SerializeField]
	TestRef m_SelfTestRef;

	[AutoRef(AutoRefTargetType.Parent)]
	[SerializeField]
	TestRef m_ParentTestRef;

	[AutoRef(AutoRefTargetType.Children)]
	[SerializeField]
	TestRef m_ChildTestRef;

	[AutoRef(AutoRefTargetType.Children)]
	[SerializeField]
	TestRef[] m_ChildTestRefArray;

	[AutoRef(AutoRefTargetType.Self | AutoRefTargetType.Children)]
	[SerializeField]
	TestRef[] m_SelfAndChildTestRefArray;

	[AutoRef(AutoRefTargetType.Siblings)]
	[SerializeField]
	TestRef[] m_SiblingTestRefArray;

	[AutoRef(AutoRefTargetType.Scene)]
	[SerializeField]
	TestRef[] m_SceneTestRefArray;

	[AutoRef(AutoRefTargetType.Self | AutoRefTargetType.Parent | AutoRefTargetType.Children | AutoRefTargetType.Siblings)]
	[SerializeField]
	List<TestRef> m_SelfParentChildAndSiblingTestRefList;
}
