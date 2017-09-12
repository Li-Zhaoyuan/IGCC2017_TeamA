﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
	static public ItemHolder instance;

	private int m_remainNum = 0;

	public Dictionary<ITEM_TYPE, int> m_itemsCollected = new Dictionary<ITEM_TYPE, int>();

	void Awake()
	{
		if (instance == null)
		{
			instance = this;

			for (int i = 0; i < (int)ITEM_TYPE.TOTAL_USABLE; ++i)
			{
				if (i != (int)ITEM_TYPE.TOTAL_RESOURCE && i != (int)ITEM_TYPE.TOTAL_USABLE)
				{
					m_itemsCollected.Add((ITEM_TYPE)i, 0);
				}
			}

			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public void AddItem(ITEM_TYPE type, int num)
	{
		m_itemsCollected[type] += num;
	}

	public bool UseItem(ITEM_TYPE type,int num)
	{
		var remain = m_itemsCollected[type];
		if (remain >= num)
		{
			m_itemsCollected[type] = remain - num;
			return true;
		}

		return false;
	}

	public int GetItemRemain(ITEM_TYPE type)
	{
		return m_itemsCollected[type];
	}
}
