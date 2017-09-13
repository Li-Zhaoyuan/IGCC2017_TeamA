using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObjectList : MonoBehaviour {

	private List<GameObject> m_gameObjectList = new List<GameObject>();
	//private Bank_Inventory m_bank = null;
	//private ItemHolder m_itemHolder = null;

	void Awake()
	{
		//m_bank = FindObjectOfType<Bank_Inventory>();
		//m_itemHolder = ItemHolder.instance;
	}

	void Update()
	{
		//if (m_bank != null)
		//{
		//	for (int i = 0; i < (int)ITEM_TYPE.TOTAL_RESOURCE; i++)
		//	{
		//		ITEM_TYPE type = (ITEM_TYPE)i;
		//		int num = m_bank.GetNumberOfresourcesCollected(type);

		//		m_itemHolder.AddItem(type, num);

		//	}
		//	m_itemHolder.AddItem(ITEM_TYPE.RESOURCE_BATTERY, m_bank.debug_battery);
		//	m_itemHolder.AddItem(ITEM_TYPE.RESOURCE_COG, m_bank.debug_cog);
		//	m_itemHolder.AddItem(ITEM_TYPE.RESOURCE_SCRAPMETAL, m_bank.debug_scrapmetal);
		//	m_itemHolder.AddItem(ITEM_TYPE.RESOURCE_SPRING, m_bank.debug_spring);
		//	m_itemHolder.AddItem(ITEM_TYPE.RESOURCE_BATTERY, m_bank.debug_battery);
		//	m_itemHolder.AddItem(ITEM_TYPE.RESOURCE_COG, m_bank.debug_cog);
		//	m_itemHolder.AddItem(ITEM_TYPE.RESOURCE_SCRAPMETAL, m_bank.debug_scrapmetal);
		//	m_itemHolder.AddItem(ITEM_TYPE.RESOURCE_SPRING, m_bank.debug_spring);

		//	m_bank.debug_battery = 0;
		//	m_bank.debug_cog = 0;
		//	m_bank.debug_scrapmetal = 0;
		//	m_bank.debug_spring = 0;

		//	Debug.Log("battery : "+m_bank.debug_battery.ToString());
		//}
	}
		void OnTriggerEnter2D(Collider2D col)
	{
		m_gameObjectList.Add(col.gameObject);
	}

	void OnTriggerExit2D(Collider2D col)
	{
		m_gameObjectList.Remove(col.gameObject);
	}

	void OnDestroy()
	{
		ItemHolder itemHolder = ItemHolder.instance;

		//当たったオブジェクトがロボットならばリストから削除
		//Delete from the list if the hit object is a robot
		foreach (var obj in m_gameObjectList)
		{
			if (obj == null) continue;

			var robotStats = obj.gameObject.GetComponent<Robot_Status>();

			if (robotStats != null)
			{
				RobotHolder.instance.AddRobot(obj);

				//var inventory = obj.GetComponentInChildren<Robot_Inventory>();

				//for (int i = 0; i < (int)ITEM_TYPE.TOTAL_RESOURCE; i++)
				//{
				//	ITEM_TYPE type = (ITEM_TYPE)i;
				//	int num = inventory.GetNumberOfresourcesCollected(type);
				//	itemHolder.AddItem(type, num);
				//}
			}
			else
			{
				Destroy(obj);
			}

			//アイテムを消す
			GameObject[] items = GameObject.FindGameObjectsWithTag("Item");
			foreach (GameObject cube in items)
			{
				Destroy(cube);
			}
		}
	}
}
