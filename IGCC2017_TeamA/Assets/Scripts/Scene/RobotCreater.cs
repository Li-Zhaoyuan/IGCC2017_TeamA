using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotCreater : MonoBehaviour {
	private RobotGenerator m_robotGenerator = null;

	[SerializeField]
	private int m_useItemNum = 0;

	private ItemHolder m_itemHolder = null;


	public void Start()
	{
		m_itemHolder = ItemHolder.instance;
		if (m_robotGenerator == null)
		{
			m_robotGenerator = GetComponentInChildren<RobotGenerator>();
		}
	}

	public void CreateRobot()
	{
		bool isCreate = m_itemHolder.UseItem(m_useItemNum);

		if (isCreate)
		{
			m_robotGenerator.MakeRandomRobot();
		}
	}
}
