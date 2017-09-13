using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class viewItem : MonoBehaviour {
    //draw status Text
    public Text[] itemText;

    private ItemHolder m_itemHolder = null;



    // Use this for initialization
    void Start()
    {
        m_itemHolder = ItemHolder.instance;
    }

    // Update is called once per frame
    void Update()
    {
        itemText[0].text = ": " + m_itemHolder.GetItemRemain(ITEM_TYPE.RESOURCE_BATTERY).ToString();
        itemText[1].text = ": " + m_itemHolder.GetItemRemain(ITEM_TYPE.RESOURCE_COG).ToString();
        itemText[2].text = ": " + m_itemHolder.GetItemRemain(ITEM_TYPE.RESOURCE_SPRING).ToString();
        itemText[3].text = ": " + m_itemHolder.GetItemRemain(ITEM_TYPE.RESOURCE_SCRAPMETAL).ToString();
    }
}
