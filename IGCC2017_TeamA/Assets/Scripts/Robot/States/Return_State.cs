using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return_State : Robot_BaseState
{
    public float rate_of_recharge;
    public float time_to_change_mood;
    // Use this for initialization
    public override void Start()
    {
        base.Start();
        time_to_change_mood = 1f;
    }

    // Update is called once per frame
    public override void Update()
    {
        //TODO: return to base
        //using vector3 zero first since dont know where is the home base for now.
        if (UsefulFunctions.GetDistanceOfTwoPoints((Vector2)main_robot.transform.position, (Vector2)state_holder_stateManager.home_base.transform.position) < state_holder_stateManager.robot_local_sprite_size.x)
        {
            robot_status.AddEnergyPoint(10 * UsefulFunctions.ConstantValueToReplaceDT());
            robot_status.AddHealthPoint(10 * UsefulFunctions.ConstantValueToReplaceDT());

            timer += Time.deltaTime;
            if(timer > time_to_change_mood)
            {
                timer = 0f;
                robot_status.RandomMood();
            }
        }
        else
        {
            Vector2 temp = UsefulFunctions.GetDirectionFromOneToTwo(main_robot.transform.position, state_holder_stateManager.home_base.transform.position);
            main_robot.GetComponent<Rigidbody2D>().velocity = new Vector2(temp.x * (main_robot.GetComponent<Robot_Status>().GetSpeedPoint() * 10) * UsefulFunctions.ConstantValueToReplaceDT()
                , temp.y * (main_robot.GetComponent<Robot_Status>().GetSpeedPoint() * 10) * UsefulFunctions.ConstantValueToReplaceDT());
        }

        if(robot_status.GetEnergyPoint() >= robot_status.GetBaseEnergyPoint())
        {
            //timer = 0;
            isDone = true;
            return;
        }
    }
    public override void Execute()
    {

    }
}
