using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour {

    //Area waypoints
    protected Vector3 disignated_area;
    protected GameObject owner;


	// Use this for initialization
	public virtual void Start () {
		
	}
	
	// Update is called once per frame
	public virtual void Update () {
		
	}

    public void SetDisignatedArea(float x, float y, float z)
    {
        disignated_area.Set(x, y, z);
    }
    public void SetDisignatedArea(Vector3 coord)
    {
        disignated_area = coord;
    }

    public void SetOwner(GameObject go)
    {
        owner = go;
    }
}
