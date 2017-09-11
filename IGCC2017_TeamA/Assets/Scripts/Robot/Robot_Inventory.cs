using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_Inventory : MonoBehaviour {

    public List<GameObject> items;

    public int max_inventory_size;
    public int resources_collected;
    //public int 

    //public void Start()
    //{
    //    items = new GameObject();
    //}

    

    public int GetNumberOfresourcesCollected()
    {
        return resources_collected;
    }

    public void SetNumberOfresourcesCollected(int value)
    {
        resources_collected = value;
    }

    public void AddNumberOfresourcesCollected(int value)
    {
        resources_collected = Mathf.Clamp(resources_collected+ value,0, max_inventory_size);
    }

    public void MinusNumberOfresourcesCollected(int value)
    {
        resources_collected = Mathf.Clamp(resources_collected - value, 0, max_inventory_size) ;
    }


    public void SetMaxInventorySize(int value)
    {
        max_inventory_size = value;
    }

    public void AddMaxInventorySize(int value)
    {
        max_inventory_size = Mathf.Clamp(resources_collected + value, 0, max_inventory_size);
    }

    public void MinusMaxInventorySize(int value)
    {
        max_inventory_size = Mathf.Clamp(resources_collected - value, 0, max_inventory_size);
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
