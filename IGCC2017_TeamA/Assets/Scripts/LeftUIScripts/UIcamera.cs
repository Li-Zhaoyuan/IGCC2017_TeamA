using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIcamera : MonoBehaviour {

    public GameObject Robot_camera;
    public GameObject HP_camera;
    public GameObject[] monster_camera;

    public GameObject UI_manager;

    public LeftClickRobot robotUIcs;
    public LeftClickMap baseUIcs;
    public LeftClickMonster monsterUIcs;


    // Use this for initialization
    void Start () {
        baseUIcs = UI_manager.GetComponent<LeftClickMap>();
        robotUIcs = UI_manager.GetComponent<LeftClickRobot>();
        monsterUIcs = UI_manager.GetComponent<LeftClickMonster>();
    }
	
	// Update is called once per frame
	void Update () {
        
	
        if(baseUIcs.target!=null)
        {
            Robot_camera.SetActive(true);
            HP_camera.SetActive(false);
            monster_camera[0].SetActive(false);
            monster_camera[1].SetActive(false);
        }
        else if(robotUIcs.target!=null)
        {
            Robot_camera.SetActive(true);
            HP_camera.SetActive(true);
            monster_camera[0].SetActive(false);
            monster_camera[1].SetActive(false);
        }
        else if(monsterUIcs.target!=null)
        {
            Robot_camera.SetActive(false);
            HP_camera.SetActive(false);
            monster_camera[0].SetActive(true);
            monster_camera[1].SetActive(true);
        }
        
	}
}
