﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rescue_State : Robot_BaseState
{
    public GameObject revival_effect;
    public float needed_time_torevive;
    public float energy_recoverrate;

    bool rescued_from_poweroutage;
    bool rescued_from_nohealth;
    GameObject tempTarget;
    
    // Use this for initialization
    public override void Start()
    {
        base.Start();
        rescued_from_poweroutage = false;
        rescued_from_nohealth = false;
    }

    // Update is called once per frame
    public override void Update()
    {
        //TODO: rescue other robots
        if(state_holder_stateManager.GetAllyTarget().GetComponent<Robot_Status>().state_manager.states_enum != ROBOT_STATES.DEAD || state_holder_stateManager.GetAllyTarget().GetComponent<Robot_Status>().state_manager.states_enum != ROBOT_STATES.OUTOFENERGY)
        {
            timer = 0f;
            rescued_from_poweroutage = false;
            rescued_from_nohealth = false;

            isDone = true;
        }
        if (UsefulFunctions.GetDistanceOfTwoPoints(main_robot.transform.position, state_holder_stateManager.GetAllyTarget().transform.position) < state_holder_stateManager.robot_local_sprite_size.x*2)
        {
            main_robot.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            if (state_holder_stateManager.GetAllyTarget().GetComponent<Robot_Status>().GetHealthPoint() > 0)
            {
                rescued_from_nohealth = true;
            }
            else
            {
                main_robot.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                timer += Time.deltaTime;
                if (timer > needed_time_torevive)
                {
                    timer = 0;
                    state_holder_stateManager.GetAllyTarget()
                        .GetComponent<Robot_Status>()
                        .SetHealthPoint(state_holder_stateManager.GetAllyTarget().GetComponent<Robot_Status>().GetBaseHealthPoint());//50% health revive with 
                }
                SpawnParticles(revival_effect, Vector3.zero, state_holder_stateManager.GetAllyTarget());
            }
            if (state_holder_stateManager.GetAllyTarget().GetComponent<Robot_Status>().GetEnergyPoint() >= state_holder_stateManager.GetAllyTarget().GetComponent<Robot_Status>().GetBaseEnergyPoint())
            {
                rescued_from_poweroutage = true;
            }
            else
            {
                state_holder_stateManager.GetAllyTarget().GetComponent<Robot_Status>().AddEnergyPoint(state_holder_stateManager.GetAllyTarget().GetComponent<Robot_Status>().GetBaseEnergyPoint());
                SpawnParticles(revival_effect, Vector3.zero, state_holder_stateManager.GetAllyTarget());

            }

            
        }
        else
        {
            Vector2 temp = UsefulFunctions.GetDirectionFromOneToTwo(main_robot.transform.position, state_holder_stateManager.GetAllyTarget().transform.position);
            main_robot.GetComponent<Rigidbody2D>().velocity = new Vector2(temp.x * (main_robot.GetComponent<Robot_Status>().GetSpeedPoint() * 10) * UsefulFunctions.ConstantValueToReplaceDT()
                , temp.y * (main_robot.GetComponent<Robot_Status>().GetSpeedPoint() * 10) * UsefulFunctions.ConstantValueToReplaceDT());
        }
        if(rescued_from_poweroutage && rescued_from_nohealth)
        {
            rescued_from_poweroutage = false;
            rescued_from_nohealth = false;

            isDone = true;
        }
    }

    public override void Execute()
    {

    }
}
