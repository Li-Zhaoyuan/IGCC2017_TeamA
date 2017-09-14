using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotCreater : MonoBehaviour {
	private RobotGenerator m_robotGenerator = null;

	[SerializeField]
	private int m_useItemNum = 0;

	private ItemHolder m_itemHolder = null;

	private ITEM_TYPE m_type = ITEM_TYPE.RESOURCE_SPRING;

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

		for (int i = 0; i < (int)ITEM_TYPE.TOTAL_RESOURCE; i++)
		{
			int num = m_itemHolder.GetItemRemain((ITEM_TYPE)i);

			if (num < m_useItemNum)
			{
				return;
			}
		}

		for (int i = 0; i < (int)ITEM_TYPE.TOTAL_RESOURCE; i++)
		{
			m_itemHolder.UseItem((ITEM_TYPE)i,m_useItemNum);
		}

		m_robotGenerator.MakeRandomRobot();

	}
}
