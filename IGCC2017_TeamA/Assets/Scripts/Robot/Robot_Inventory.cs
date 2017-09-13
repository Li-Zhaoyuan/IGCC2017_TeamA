using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_Inventory : MonoBehaviour {

    //public List<GameObject> items;

    public int max_inventory_size;
    //public int resources_collected;
    [SerializeField]
    public Dictionary<ITEM_TYPE, int> items_collected = new Dictionary<ITEM_TYPE, int>();
    public Dictionary<ITEM_TYPE, int> max_space_for_items = new Dictionary<ITEM_TYPE, int>();
    //public int 

    public virtual void Start()
    {
        //items = new GameObject();
        for(int i = 0; i < (int)ITEM_TYPE.TOTAL_USABLE; ++i)
        {
            if(i != (int)ITEM_TYPE.TOTAL_RESOURCE && i != (int)ITEM_TYPE.TOTAL_USABLE)
            {
                items_collected.Add((ITEM_TYPE)i, 0);
            }
        }

        for (int i = 0; i < (int)ITEM_TYPE.TOTAL_USABLE; ++i)
        {
            if (i != (int)ITEM_TYPE.TOTAL_RESOURCE && i != (int)ITEM_TYPE.TOTAL_USABLE)
            {
                max_space_for_items.Add((ITEM_TYPE)i, 100);
            }
        }
    }
    public virtual void Update()
    {

    }

    public virtual int GetTotalNumberOfresourcesCollected()
    {
        int temp = 0;
        for (int i = 0; i < (int)ITEM_TYPE.TOTAL_USABLE; ++i)
        {
            if (i != (int)ITEM_TYPE.TOTAL_RESOURCE && i != (int)ITEM_TYPE.TOTAL_USABLE)
            {
                temp += items_collected[(ITEM_TYPE)i];
            }
        }
        return temp;
    }
    public virtual int GetNumberOfresourcesCollected(ITEM_TYPE type)
    {
        return items_collected[type];
    }

    public virtual void SetNumberOfresourcesCollected(int value, ITEM_TYPE type)
    {
        items_collected[type] = value;
        //resources_collected = value;
    }

    public virtual void AddNumberOfresourcesCollected(int value,ITEM_TYPE type)
    {
        items_collected[type] = Mathf.Clamp(items_collected[type] + value, 0, max_space_for_items[type]);
        //resources_collected = Mathf.Clamp(resources_collected+ value,0, max_inventory_size);
    }

    public virtual void MinusNumberOfresourcesCollected(int value, ITEM_TYPE type)
    {
        items_collected[type] = Mathf.Clamp(items_collected[type] - value, 0, max_space_for_items[type]);
    }


    public virtual void SetMaxInventorySize(int value, ITEM_TYPE type)
    {
        max_space_for_items[type] = value;
    }

    public virtual void AddMaxInventorySize(int value, ITEM_TYPE type)
    {
        max_space_for_items[type] += value;
    }

    public virtual void MinusMaxInventorySize(int value, ITEM_TYPE type)
    {
        max_space_for_items[type] -= value;
    }
    //public GameObject[] GetListOfItems()
    //{
    //    PopulateItemArray();
    //    return items;
    //}

    //public int GetNumberOfItems()
    //{
    //    PopulateItemArray();
    //    return items.Length;
    //}

    //public void PopulateItemArray()
    //{
    //    //items = GetComponentInChildren<Item>()
    //}


}
