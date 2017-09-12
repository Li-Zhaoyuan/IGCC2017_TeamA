using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : MonoBehaviour
{
	static public ItemHolder instance;

	int m_remainNum = 0;

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	bool UseItem(int numResources,int num)
	{

		if (m_remainNum > num)
		{
			m_remainNum -= num;
			return true;
		}

		return false;
	}
}
