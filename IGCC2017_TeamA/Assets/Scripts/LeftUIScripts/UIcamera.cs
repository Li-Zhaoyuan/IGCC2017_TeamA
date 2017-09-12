using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIcamera : MonoBehaviour {

    public GameObject Robot_camera;
    public GameObject HP_camera;

    public GameObject UI_manager;

    public LeftClickRobot robotUIcs;
    public LeftClickMap baseUIcs;


    // Use this for initialization
    void Start () {
        baseUIcs = UI_manager.GetComponent<LeftClickMap>();
        robotUIcs = UI_manager.GetComponent<LeftClickRobot>();
    }
	
	// Update is called once per frame
	void Update () {
		if(baseUIcs._state==true)
        {
            HP_camera.SetActive(false);
        }
        else
        {
            HP_camera.SetActive(true);
        }
	}
}
