using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Resource : Item_Base {

    // Use this for initialization
    public override void Start()
    {
        number_resources = Random.Range(1, 11);
    }

    //// Update is called once per frame
    //public override void Update()
    //{

    //}
}
