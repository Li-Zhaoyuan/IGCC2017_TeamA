﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roam_State : Robot_BaseState
{

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        timer = 1.0f;
        robot_direction = Vector2.zero;
        robot_velocity = Vector2.zero;
    }

    // Update is called once per frame
    public override void Update()
    {
        //TODO: Roam the disignated area
        timer += Time.deltaTime;
        if (timer > 1.0f)
        {
            timer = 0.0f;
            if (Random.Range(0, 19) < 2)//20% to not move
            {
                robot_velocity = Vector2.zero;
            }
            else
            {
                robot_velocity = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2)).normalized;
            }
            main_robot.GetComponent<Rigidbody2D>().velocity = robot_velocity;
        }
    }
    public override void Execute()
    {
        
    }
}