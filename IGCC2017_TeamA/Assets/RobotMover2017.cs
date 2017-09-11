using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotMover2017 : MonoBehaviour {

    public GameObject[] robots;
    public bool is_selecting = false;
    public Vector3 screen_mouse_initialpos;
    public Vector3 world_mouse_initialpos;
    public Vector3 screen_mouse_currentpos;
    public Vector3 world_mouse_currentpos;
    public Vector3 center_of_quad;
    public Vector3 size_of_boxcollider;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //left click to drag and select
		if(Input.GetMouseButtonDown(0))
        {
            is_selecting = true;
            screen_mouse_initialpos = Input.mousePosition;
            Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        }
        else if(Input.GetMouseButtonUp(0))
        {
            is_selecting = false;
            //do find the units in the rect here 
            //box collider herez
            world_mouse_initialpos = Camera.main.ScreenToWorldPoint(screen_mouse_initialpos);
            world_mouse_currentpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            center_of_quad = UsefulFunctions.GetCenterOfLine(world_mouse_initialpos, world_mouse_currentpos);
            size_of_boxcollider = new Vector3(Mathf.Abs(world_mouse_currentpos.x) - Mathf.Abs(world_mouse_initialpos.x), Mathf.Abs(world_mouse_currentpos.y) - Mathf.Abs(world_mouse_initialpos.y), 1);

            robots = UsefulFunctions.GetNearbyEnemyWithBoxColliderArray(center_of_quad, size_of_boxcollider);
            Debug.Log((size_of_boxcollider));
        }
	}

    void OnGUI()
    {
        if (is_selecting)
        {
            var rect = UsefulFunctions.GetScreenRect(screen_mouse_initialpos, Input.mousePosition);
            UsefulFunctions.DrawScreenRect(rect, new Color(0.902f, 0.902f, 0.98f,0.25f));
        }
        //UsefulFunctions.DrawScreenRect(new Rect(32, 32, 256, 128), Color.green);
        //UsefulFunctions.DrawScreenRectBorder(new Rect(32, 32, 256, 128), 2,Color.green);
        //UsefulFunctions.DrawScreenRect(new Rect(32, 32, 256, 128), Color.green);
    }
}
