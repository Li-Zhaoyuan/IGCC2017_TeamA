using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape_State : Robot_BaseState
{

    // Use this for initialization
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        //TODO: run away from monster
        base.Update();
        if (state_holder_stateManager.enemy_target == null)
        {
            isDone = true;
            return;
        }
        else if (UsefulFunctions.GetDistanceOfTwoPoints(main_robot.transform.position, state_holder_stateManager.enemy_target.transform.position) < state_holder_stateManager.robot_local_sprite_size.x * 2)
        {
            Vector2 temp = UsefulFunctions.GetDirectionFromOneToTwo(state_holder_stateManager.enemy_target.transform.position, main_robot.transform.position);
            main_robot.GetComponent<Rigidbody2D>().velocity = new Vector2(temp.x, temp.y);

        }
        else// out of range #escaped
        {
            isDone = true;
            return;
        }
    }

    public override void Execute()
    {

    }
}
