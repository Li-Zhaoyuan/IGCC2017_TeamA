using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Usable : Item_Base {

    // Use this for initialization
    public override void Start()
    {
        number_resources = Random.Range(1, 3);
    }
    // Update is called once per frame
   
}
