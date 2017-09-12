using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotCreater : MonoBehaviour {

	[SerializeField]
	private RobotGenerator m_robotCreater = null;

	[SerializeField]
	private int m_useItemNum = 0;

	private ItemHolder m_itemHolder = null;


	public void Start()
	{
		m_itemHolder = ItemHolder.instance;
	}

	public bool CreateRobot()
	{
		bool isCreate = m_itemHolder.UseItem(m_useItemNum);

		if (isCreate)
		{
			m_robotCreater.MakeRandomRobot();
			return true;
		}
		return false;
	}
}
