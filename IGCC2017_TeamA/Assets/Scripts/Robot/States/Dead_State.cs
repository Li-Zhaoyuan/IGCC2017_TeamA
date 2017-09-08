using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead_State : Robot_BaseState
{

    // Use this for initialization
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        //TODO: die and cannot do anything
        if (UsefulFunctions.GetPercentageInFloat(main_robot.GetComponent<Robot_Status>().GetHealthPoint(), main_robot.GetComponent<Robot_Status>().GetBaseHealthPoint()) >= 0.5)//at least 50 energy to go on
        {
            isDone = true;
        }
    }

    public override void Execute()
    {

    }
}
