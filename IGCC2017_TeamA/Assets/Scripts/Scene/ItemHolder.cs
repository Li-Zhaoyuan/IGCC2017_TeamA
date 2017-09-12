using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
	static public ItemHolder instance;

	[SerializeField]
	private int m_firstRemainNum = 100;

	private int m_remainNum = 0;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
			m_remainNum = m_firstRemainNum;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public bool UseItem(int num)
	{

		if (m_remainNum > num)
		{
			m_remainNum -= num;
			return true;
		}

		return false;
	}

	public int GetItemRemain()
	{
		return m_remainNum;
	}
}
