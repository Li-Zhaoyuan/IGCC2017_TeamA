using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ITEM_LIST
{
	ITEM = 0,
}
public class ItemHolder : MonoBehaviour
{

	static public ItemHolder instance;

	Dictionary<ITEM_LIST, int> m_itemMap;

	void Awake()
	{
		if (instance == null)
		{
			m_itemMap = new Dictionary<ITEM_LIST, int>() {
				{ITEM_LIST.ITEM,0 },
			};

			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	bool UseItem(ITEM_LIST item,int num)
	{
		int remainNum = m_itemMap[item];

		if (remainNum > num)
		{
			m_itemMap[item] = remainNum - num;
			return true;
		}

		return false;
	}
}
