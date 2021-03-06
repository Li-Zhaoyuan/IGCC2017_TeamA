﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo_State : Robot_BaseState
{
    
    // Use this for initialization
    public override void Start()
    {
        base.Start();
        
    }

    public override void Update()
    {
        //TODO: move to the disignated area
        robot_direction = (state_holder_stateManager.GetDisignatedPosition() - main_robot.transform.position);
        robot_direction.Normalize();
        main_robot.GetComponent<Rigidbody2D>().velocity = new Vector2(robot_direction.x * (main_robot.GetComponent<Robot_Status>().GetSpeedPoint() * 10) * UsefulFunctions.ConstantValueToReplaceDT()
            , robot_direction.y * (main_robot.GetComponent<Robot_Status>().GetSpeedPoint() * 10) * UsefulFunctions.ConstantValueToReplaceDT());
        //Debug.Log(state_holder_stateManager.GetDisignatedPosition() - main_robot.transform.position);
        //robot_direction = (state_holder_stateManager.mainWaypoint - main_robot.transform.position).normalized;
        //main_robot.GetComponent<Rigidbody2D>().velocity = new Vector2(robot_direction.x, robot_direction.y);
    }

    public override void Execute()
    {
        
        
    }
}
