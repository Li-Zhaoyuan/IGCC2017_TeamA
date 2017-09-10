﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gather_State : Robot_BaseState
{
    public float gather_time;
    // Use this for initialization
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        //TODO: Collect Items
        base.Update();
        

        if (state_holder_stateManager.item_target == null)
        {
            isDone = true;
            return;
        }
        else if (UsefulFunctions.GetDistanceOfTwoPoints(main_robot.transform.position, state_holder_stateManager.item_target.transform.position) < state_holder_stateManager.robot_local_sprite_size.x * 2)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
            if (timer > gather_time)
            {
                timer = 0f;
                robot_status.inventory.AddNumberOfresourcesCollected(
                    state_holder_stateManager.item_target.GetComponent<Item_Resource>().GetNumberOfResourcesWorth() + (int)(main_robot.GetComponent<Robot_Status>().GetLuckPoint()));
                Destroy(state_holder_stateManager.item_target);
                state_holder_stateManager.item_target = null;
            }
        }
        else
        {
            if (UsefulFunctions.GetDistanceOfTwoPoints(main_robot.transform.position, state_holder_stateManager.item_target.transform.position) > state_holder_stateManager.robot_local_sprite_size.x * 4)
            {
                isDone = true;
                return;
            }
            Vector2 temp = UsefulFunctions.GetDirectionFromOneToTwo(main_robot.transform.position, state_holder_stateManager.item_target.transform.position);
            main_robot.GetComponent<Rigidbody2D>().velocity = new Vector2(temp.x, temp.y);
        }
    }

    public override void Execute()
    {

    }
}
