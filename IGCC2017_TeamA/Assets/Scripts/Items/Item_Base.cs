using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Base : MonoBehaviour {
    protected int number_resources;
    public GameObject main_gather;
	// Use this for initialization
	public virtual void Start () {
		
	}
	
    public virtual int GetNumberOfResourcesWorth()
    {
        return number_resources;
    }

    public virtual void SetMainGather(GameObject go)
    {
        main_gather = go;
    }
    public virtual GameObject GetMainGather()
    {
        return main_gather;
    }
    //// Update is called once per frame
    //public virtual void Update () {

    //}
}
