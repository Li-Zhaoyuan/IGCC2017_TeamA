using System.Collections;
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
            timer = 0f;
            isDone = true;
            return;
        }
        if (state_holder_stateManager.item_target.GetComponent<Item_Base>().GetMainGather() == null)
        {
            state_holder_stateManager.item_target.GetComponent<Item_Base>().SetMainGather(main_robot);
        }
        if (UsefulFunctions.GetDistanceOfTwoPoints((Vector2)main_robot.transform.position, (Vector2)state_holder_stateManager.item_target.transform.position) < state_holder_stateManager.robot_local_sprite_size.x
            && state_holder_stateManager.item_target.GetComponent<Item_Base>().GetMainGather() == main_robot)
        {
            timer += Time.deltaTime;
            //Debug.Log(timer);
            if (timer > gather_time)
            {
                timer = 0f;
                robot_status.inventory.AddNumberOfresourcesCollected(
                    state_holder_stateManager.item_target.GetComponent<Item_Base>().GetNumberOfResourcesWorth() + (int)(main_robot.GetComponent<Robot_Status>().GetLuckPoint()), state_holder_stateManager.item_target.GetComponent<Item_Base>().GetItemType());
                Destroy(state_holder_stateManager.item_target);
                state_holder_stateManager.item_target = null;
            }
        }
        else if(state_holder_stateManager.item_target.GetComponent<Item_Base>().GetMainGather() != main_robot)
        {
            timer = 0f;
            isDone = true;
            return;
        }
        else
        {
            if (UsefulFunctions.GetDistanceOfTwoPoints((Vector2)main_robot.transform.position, (Vector2)state_holder_stateManager.item_target.transform.position) > state_holder_stateManager.robot_local_sprite_size.x * 4)
            {
                timer = 0f;
                state_holder_stateManager.item_target.GetComponent<Item_Base>().SetMainGather(null);
                isDone = true;
                return;
            }
            Vector2 temp = UsefulFunctions.GetDirectionFromOneToTwo(main_robot.transform.position, state_holder_stateManager.item_target.transform.position);
            main_robot.GetComponent<Rigidbody2D>().velocity = new Vector2(temp.x * (main_robot.GetComponent<Robot_Status>().GetSpeedPoint() * 10) * Time.deltaTime
                , temp.y * (main_robot.GetComponent<Robot_Status>().GetSpeedPoint() * 10) * Time.deltaTime);
        }
    }

    public override void Execute()
    {

    }
}
