using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemRemainText : MonoBehaviour {

	[SerializeField]
	private Text m_text = null;

	private ItemHolder m_itemHolder = null;

	// Use this for initialization
	void Start () {
		m_itemHolder = ItemHolder.instance;
	}

	// Update is called once per frame
	void Update () {
		m_text.text = "Battery			: " + m_itemHolder.GetItemRemain(ITEM_TYPE.RESOURCE_BATTERY).ToString()+"\n"
					+ "Cog				: " + m_itemHolder.GetItemRemain(ITEM_TYPE.RESOURCE_COG).ToString()+"\n"
					+ "Spring			: " + m_itemHolder.GetItemRemain(ITEM_TYPE.RESOURCE_SPRING).ToString()+"\n"
					+ "ScrapMetal	: " + m_itemHolder.GetItemRemain(ITEM_TYPE.RESOURCE_SCRAPMETAL).ToString()+"\n";
	}
}
