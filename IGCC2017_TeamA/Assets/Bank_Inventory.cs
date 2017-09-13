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

    public override void Update()
    {
        base.Update();
        debug_battery = items_collected[ITEM_TYPE.RESOURCE_BATTERY];
        debug_spring = items_collected[ITEM_TYPE.RESOURCE_SPRING];
        debug_cog = items_collected[ITEM_TYPE.RESOURCE_COG];
        debug_scrapmetal = items_collected[ITEM_TYPE.RESOURCE_SCRAPMETAL];
    }

}
