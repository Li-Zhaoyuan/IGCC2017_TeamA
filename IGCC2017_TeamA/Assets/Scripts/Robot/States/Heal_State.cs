using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal_State : Robot_BaseState
{
    public float base_healing_value;
    // Use this for initialization
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        //TODO: Heal allies
        
        if (UsefulFunctions.GetDistanceOfTwoPoints(main_robot.transform.position, state_holder_stateManager.GetAllyTarget().transform.position) < state_holder_stateManager.robot_local_sprite_size.x * 2)
        {
            main_robot.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
           
            {
                state_holder_stateManager.GetAllyTarget()
                       .GetComponent<Robot_Status>()
                       .AddHealthPoint(base_healing_value * Time.deltaTime * robot_status.GetMagicPoint());//heal
            }
           


        }
        else
        {
            Vector2 temp = UsefulFunctions.GetDirectionFromOneToTwo(main_robot.transform.position, state_holder_stateManager.GetAllyTarget().transform.position);
            main_robot.GetComponent<Rigidbody2D>().velocity = new Vector2(temp.x * (main_robot.GetComponent<Robot_Status>().GetSpeedPoint() * 10) * Time.deltaTime
                , temp.y * (main_robot.GetComponent<Robot_Status>().GetSpeedPoint() * 10) * Time.deltaTime);
        }

        if(state_holder_stateManager.GetAllyTarget()
                       .GetComponent<Robot_Status>().GetHealthPoint() > state_holder_stateManager.GetAllyTarget()
                       .GetComponent<Robot_Status>().GetBaseHealthPoint())
            isDone = true;
    }

    public override void Execute()
    {

    }
}
