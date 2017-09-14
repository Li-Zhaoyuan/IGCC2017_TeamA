using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResousePuls : MonoBehaviour {

	private ItemHolder m_itemHolder;

	private float m_timer = 0.0f;
	// Use this for initialization
	void Start () {
		m_itemHolder = ItemHolder.instance;
	}

	// Update is called once per frame
	void Update () {

		m_timer += Time.time;
		if (m_timer > 60.0f)
		{
			m_timer = 0.0f;

			for (int i = 0; i < (int)ITEM_TYPE.TOTAL_RESOURCE; i++)
			{
				m_itemHolder.AddItem((ITEM_TYPE)i, 1);
			}

		}
	}
}
