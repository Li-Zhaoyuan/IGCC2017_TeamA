using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_State : Robot_BaseState
{
    public GameObject projectile;

    public float attack_interval;
    public float attack_speed;
    public float attack_damage;
    public float alive_time;

    GameObject new_projectile;
    
	// Use this for initialization
	public override void Start () {
        base.Start();
	}

    // Update is called once per frame
    public override void Update () {
        //TODO: attack monsters
        base.Update();
        timer += Time.deltaTime;
        if(timer > attack_interval)
        {
            timer = 0f;
            new_projectile = Instantiate(projectile, main_robot.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            new_projectile.GetComponent<Robot_Bullet>().Initialize(UsefulFunctions.GetDirectionFromOneToTwo(main_robot.transform.position, state_holder_stateManager.GetEnemyTarget().transform.position)
                , attack_speed
                , attack_damage + (main_robot.GetComponent<Robot_Status>().GetAttackPoint() * 3)
                , alive_time);
        }
	}

    public override void Execute()
    {

    }
}
