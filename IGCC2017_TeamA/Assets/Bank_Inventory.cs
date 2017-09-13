using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/* RESOURCE_BATTERY,
    RESOURCE_SPRING,
    RESOURCE_COG,
    RESOURCE_SCRAPMETAL,*/
public class Bank_Inventory : Robot_Inventory {
    public int debug_battery;
    public int debug_spring;
    public int debug_cog;
    public int debug_scrapmetal;
    public ItemHolder item_holder;

    public override void Start()
    {
        base.Start();
        item_holder = FindObjectOfType<ItemHolder>();
    }

    public override void Update()
    {
        base.Update();
        debug_battery = items_collected[ITEM_TYPE.RESOURCE_BATTERY];
        debug_spring = items_collected[ITEM_TYPE.RESOURCE_SPRING];
        debug_cog = items_collected[ITEM_TYPE.RESOURCE_COG];
        debug_scrapmetal = items_collected[ITEM_TYPE.RESOURCE_SCRAPMETAL];
    }

    public override void SetNumberOfresourcesCollected(int value, ITEM_TYPE type)
    {
        base.SetNumberOfresourcesCollected(value, type);
        if(item_holder != null)
        {
            item_holder.SetItem(type, value);
        }
        //resources_collected = value;
    }

    public override void AddNumberOfresourcesCollected(int value, ITEM_TYPE type)
    {
        base.AddNumberOfresourcesCollected(value, type);
        if (item_holder != null)
        {
            item_holder.AddItem(type, value);
        }
        //resources_collected = Mathf.Clamp(resources_collected+ value,0, max_inventory_size);
    }

    public override void MinusNumberOfresourcesCollected(int value, ITEM_TYPE type)
    {
        //items_collected[type] = Mathf.Clamp(items_collected[type] - value, 0, max_space_for_items[type]);
        base.MinusNumberOfresourcesCollected(value,type);
        if (item_holder != null)
        {
            item_holder.UseItem(type, value);
        }
    }


    //public virtual void SetMaxInventorySize(int value, ITEM_TYPE type)
    //{
    //    max_space_for_items[type] = value;
    //}

    //public virtual void AddMaxInventorySize(int value, ITEM_TYPE type)
    //{
    //    max_space_for_items[type] += value;
    //}

    //public virtual void MinusMaxInventorySize(int value, ITEM_TYPE type)
    //{
    //    max_space_for_items[type] -= value;
    //}
}
