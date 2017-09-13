using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dead_State : Robot_BaseState
{
    public float time_till_disappearance;
    public GameObject explosion_effect;
    // Use this for initialization
    public override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        //TODO: die and cannot do anything
        timer += Time.deltaTime;
        if(timer > time_till_disappearance)
        {
            timer = 0;
            Destroy(main_robot);
            SpawnParticles(explosion_effect, Vector3.zero, main_robot);
        }
        if (UsefulFunctions.GetPercentageInFloat(main_robot.GetComponent<Robot_Status>().GetHealthPoint(), main_robot.GetComponent<Robot_Status>().GetBaseHealthPoint()) >= 0.5)//at least 50 health to go on
        {
            timer = 0;
            isDone = true;
        }
    }

    public override void Execute()
    {

    }
}
