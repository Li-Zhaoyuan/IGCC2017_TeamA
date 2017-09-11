using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Base : MonoBehaviour {
    protected int number_resources;
	// Use this for initialization
	public virtual void Start () {
		
	}
	
    public virtual int GetNumberOfResourcesWorth()
    {
        return number_resources;
    }
	//// Update is called once per frame
	//public virtual void Update () {
		
	//}
}
