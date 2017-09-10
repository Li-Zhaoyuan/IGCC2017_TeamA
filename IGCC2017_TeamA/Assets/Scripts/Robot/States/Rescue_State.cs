using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rescue_State : Robot_BaseState
{
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
        if (UsefulFunctions.GetDistanceOfTwoPoints(main_robot.transform.position, state_holder_stateManager.GetAllyTarget().transform.position) < state_holder_stateManager.robot_local_sprite_size.x*2)
        {
            main_robot.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            if (state_holder_stateManager.GetAllyTarget().GetComponent<Robot_Status>().GetHealthPoint() > 0)
            {
                rescued_from_nohealth = true;
            }
            else
            {
                timer += Time.deltaTime;
                if (timer > needed_time_torevive)
                {
                    timer = 0;
                    state_holder_stateManager.GetAllyTarget()
                        .GetComponent<Robot_Status>()
                        .SetHealthPoint(state_holder_stateManager.GetAllyTarget().GetComponent<Robot_Status>().GetBaseHealthPoint() * 0.5f);//50% health revive with 
                }
            }
            if (state_holder_stateManager.GetAllyTarget().GetComponent<Robot_Status>().GetEnergyPoint() > state_holder_stateManager.GetAllyTarget().GetComponent<Robot_Status>().GetBaseEnergyPoint() * 0.5)
            {
                rescued_from_poweroutage = true;
            }
            else
            {
                state_holder_stateManager.GetAllyTarget().GetComponent<Robot_Status>().AddEnergyPoint((energy_recoverrate + (2 * robot_status.GetMagicPoint())) * Time.deltaTime);


            }

            
        }
        else
        {
            Vector2 temp = UsefulFunctions.GetDirectionFromOneToTwo(main_robot.transform.position, state_holder_stateManager.GetAllyTarget().transform.position);
            main_robot.GetComponent<Rigidbody2D>().velocity = new Vector2(temp.x, temp.y);
        }
        if(rescued_from_poweroutage && rescued_from_nohealth)
        {
            isDone = true;
        }
    }

    public override void Execute()
    {

    }
}
