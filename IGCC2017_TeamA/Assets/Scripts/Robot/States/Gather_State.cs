using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gather_State : Robot_BaseState
{
    public float gather_time;
    public GameObject gather_effect;
    // Use this for initialization
    public override void Start()
    {
        gather_time = 1;
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
        //if (state_holder_stateManager.item_target.GetComponent<Item_Base>().GetMainGather() == null)
        //{
        //    state_holder_stateManager.item_target.GetComponent<Item_Base>().SetMainGather(main_robot);
        //}
        if (UsefulFunctions.GetDistanceOfTwoPoints((Vector2)main_robot.transform.position, (Vector2)state_holder_stateManager.item_target.transform.position) < state_holder_stateManager.robot_local_sprite_size.x
            /*&& state_holder_stateManager.item_target.GetComponent<Item_Base>().GetMainGather() == main_robot*/)
        {
            timer += Time.deltaTime;
            Debug.Log(timer);
            Debug.Log((Vector2)state_holder_stateManager.item_target.transform.position);
            if (timer > gather_time)
            {
                timer = 0f;
                robot_status.bank.AddItem(
                    state_holder_stateManager.item_target.GetComponent<Item_Base>().GetItemType(), state_holder_stateManager.item_target.GetComponent<Item_Base>().GetNumberOfResourcesWorth() + (int)(main_robot.GetComponent<Robot_Status>().GetLuckPoint()));
                Destroy(state_holder_stateManager.item_target);
                state_holder_stateManager.item_target = null;
                //state_holder_stateManager.item_target.GetComponent<Item_Base>().DestroyOwnself();
                isDone = true;
                
            }
            if(state_holder_stateManager.item_target != null)
                SpawnParticles(gather_effect, Vector3.zero, state_holder_stateManager.item_target);
        }
        //else if(state_holder_stateManager.item_target.GetComponent<Item_Base>().GetMainGather() != main_robot)
        //{
        //    Debug.Log("1");
        //    timer = 0f;
        //    isDone = true;
        //    return;
        //}
        else
        {
            if (UsefulFunctions.GetDistanceOfTwoPoints((Vector2)main_robot.transform.position, (Vector2)state_holder_stateManager.item_target.transform.position) > state_holder_stateManager.robot_local_sprite_size.x * 4)
            {
                Debug.Log("2");
                timer = 0f;
                state_holder_stateManager.item_target.GetComponent<Item_Base>().SetMainGather(null);
                isDone = true;
                return;
            }
            Vector2 temp = UsefulFunctions.GetDirectionFromOneToTwo(main_robot.transform.position, state_holder_stateManager.item_target.transform.position);
            main_robot.GetComponent<Rigidbody2D>().velocity = new Vector2(temp.x * (main_robot.GetComponent<Robot_Status>().GetSpeedPoint() * 10) * UsefulFunctions.ConstantValueToReplaceDT()
                , temp.y * (main_robot.GetComponent<Robot_Status>().GetSpeedPoint() * 10) * UsefulFunctions.ConstantValueToReplaceDT());
        }
    }

    public override void Execute()
    {

    }
}
