﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotGenerator : MonoBehaviour {

    public GameObject robot;

    GameObject home_base;
    Vector3 spawn_pos;
	// Use this for initialization
	void Start () {
        home_base = GameObject.FindGameObjectWithTag("Base");
        if(home_base != null)
        {
            spawn_pos = home_base.transform.position;
            Debug.Log(spawn_pos);
        }
        else
        {
            spawn_pos = Vector3.zero;
        }
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space))
        {
            MakeRandomRobot();
        }
       

    }

    public void MakeRandomRobot()
    {
        if (home_base == null)
        {
            home_base = GameObject.FindGameObjectWithTag("Base");
            
            if (home_base != null)
            {
                spawn_pos = home_base.transform.position;
            }
        }
       
        int rnd_robot = Random.Range(0, 6);
        if (rnd_robot == 0)
            MakeBraveRobot();
        else if (rnd_robot == 1)
            MakeCuriousRobot();
        else if (rnd_robot == 2)
            MakeSensitiveRobot();
        else if (rnd_robot == 3)
            MakeLazyRobot();
        else if (rnd_robot == 4)
            MakeImpatientRobot();
        else if (rnd_robot == 5)
            MakeCarefulRobot();
    }

    void MakeBraveRobot()
    {
        GameObject tempRobot = Instantiate(robot, spawn_pos, Quaternion.Euler(0, 0, 0)) as GameObject;
        tempRobot.GetComponent<Robot_Status>().SetAllRobotStatus(Random.Range(7,11)
                                                               , Random.Range(4, 7)
                                                               , Random.Range(1, 5)
                                                               , Random.Range(4, 7)
                                                               , Random.Range(4, 7)
                                                               , 100
                                                               , 100
                                                               , PERSONALITY.BRAVE);
       
    }

    void MakeCuriousRobot()
    {
        GameObject tempRobot = Instantiate(robot, spawn_pos, Quaternion.Euler(0, 0, 0)) as GameObject;
        tempRobot.GetComponent<Robot_Status>().SetAllRobotStatus(Random.Range(4, 7)
                                                                       , Random.Range(4, 7)
                                                                       , Random.Range(4, 7)
                                                                       , Random.Range(7, 11)
                                                                       , Random.Range(1, 5)
                                                                       , 100
                                                                       , 100
                                                                       , PERSONALITY.CURIOUS);
        
    }
    void MakeSensitiveRobot()
    {
        GameObject tempRobot = Instantiate(robot, spawn_pos, Quaternion.Euler(0, 0, 0)) as GameObject;
        tempRobot.GetComponent<Robot_Status>().SetAllRobotStatus(Random.Range(1, 5)
                                                                       , Random.Range(4, 7)
                                                                       , Random.Range(7, 11)
                                                                       , Random.Range(4, 7)
                                                                       , Random.Range(4, 7)
                                                                       , 100
                                                                       , 100
                                                                       , PERSONALITY.SENSITIVE);
       
    }
    void MakeLazyRobot()
    {
        GameObject tempRobot = Instantiate(robot, spawn_pos, Quaternion.Euler(0, 0, 0)) as GameObject;
        tempRobot.GetComponent<Robot_Status>().SetAllRobotStatus(Random.Range(1, 5)
                                                                       , Random.Range(1, 5)
                                                                       , Random.Range(1, 5)
                                                                       , Random.Range(1, 5)
                                                                       , Random.Range(1, 5)
                                                                       , 100
                                                                       , 100
                                                                       , PERSONALITY.LAZY);
      
    }
    void MakeImpatientRobot()
    {

        GameObject tempRobot = Instantiate(robot, spawn_pos, Quaternion.Euler(0, 0, 0)) as GameObject;
        tempRobot.GetComponent<Robot_Status>().SetAllRobotStatus(Random.Range(4, 7)
                                                                       , Random.Range(7, 11)
                                                                       , Random.Range(4, 7)
                                                                       , Random.Range(1, 5)
                                                                       , Random.Range(4, 7)
                                                                       , 100
                                                                       , 100
                                                                       , PERSONALITY.IMPATIENT);
        
    }
    void MakeCarefulRobot()
    {
        GameObject tempRobot = Instantiate(robot, spawn_pos, Quaternion.Euler(0, 0, 0)) as GameObject;
        tempRobot.GetComponent<Robot_Status>().SetAllRobotStatus(Random.Range(4, 7)
                                                                       , Random.Range(1, 5)
                                                                       , Random.Range(4, 7)
                                                                       , Random.Range(4, 7)
                                                                       , Random.Range(7, 11)
                                                                       , 100
                                                                       , 100
                                                                       , PERSONALITY.CAREFUL);
        
    }
   
}
