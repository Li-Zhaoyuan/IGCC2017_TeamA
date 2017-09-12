using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return_State : Robot_BaseState
{
    public float rate_of_recharge;
    // Use this for initialization
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        //TODO: return to base
        //using vector3 zero first since dont know where is the home base for now.
        if (UsefulFunctions.GetDistanceOfTwoPoints((Vector2)main_robot.transform.position, (Vector2)state_holder_stateManager.home_base.transform.position) < state_holder_stateManager.robot_local_sprite_size.x)
        {
            robot_status.AddEnergyPoint(rate_of_recharge * UsefulFunctions.ConstantValueToReplaceDT());
        }
        else
        {
            Vector2 temp = UsefulFunctions.GetDirectionFromOneToTwo(main_robot.transform.position, state_holder_stateManager.home_base.transform.position);
            main_robot.GetComponent<Rigidbody2D>().velocity = new Vector2(temp.x * (main_robot.GetComponent<Robot_Status>().GetSpeedPoint() * 10) * UsefulFunctions.ConstantValueToReplaceDT()
                , temp.y * (main_robot.GetComponent<Robot_Status>().GetSpeedPoint() * 10) * UsefulFunctions.ConstantValueToReplaceDT());
        }

        if(robot_status.GetEnergyPoint() >= robot_status.GetBaseEnergyPoint())
        {
            isDone = true;
            return;
        }
    }
    public override void Execute()
    {

    }
}
