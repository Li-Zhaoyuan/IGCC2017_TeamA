using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Secret : MonoBehaviour {

	private ItemHolder m_item;

	// Use this for initialization
	void Start () {
		m_item = ItemHolder.instance;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.RightShift))
		{
			for (int i = 0; i < (int)ITEM_TYPE.TOTAL_RESOURCE; i++)
			{
				m_item.SetItem((ITEM_TYPE)i, 100);
			}
		}
	}
}
