using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack_State : Robot_BaseState
{
    public GameObject projectile;
    public GameObject hit_effect;

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
        //Chase the enemy if not close enough
        if (state_holder_stateManager.enemy_target == null)
        {
            isDone = true;
            return;
        }
        else if (UsefulFunctions.GetDistanceOfTwoPoints(main_robot.transform.position, state_holder_stateManager.enemy_target.transform.position) < state_holder_stateManager.robot_local_sprite_size.x)
        {
            if (timer > attack_interval)
            {
                timer = 0f;
                //new_projectile = Instantiate(projectile, main_robot.transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
                //new_projectile.GetComponent<Robot_Bullet>().Initialize(UsefulFunctions.GetDirectionFromOneToTwo(main_robot.transform.position, state_holder_stateManager.GetEnemyTarget().transform.position)
                //    , attack_speed
                //    , attack_damage + (main_robot.GetComponent<Robot_Status>().GetAttackPoint() * 3)
                //    , alive_time);
                if(state_holder_stateManager.enemy_target.GetComponent<ChaseMonster>() != null)
                    state_holder_stateManager.enemy_target.GetComponent<ChaseMonster>().TakeDamage(main_robot.GetComponent<Robot_Status>().GetAttackPoint() * 3);
                else if(state_holder_stateManager.enemy_target.GetComponent<TestMonster>() != null)
                    state_holder_stateManager.enemy_target.GetComponent<TestMonster>().TakeDamage(main_robot.GetComponent<Robot_Status>().GetAttackPoint() * 3);
                else if (state_holder_stateManager.enemy_target.GetComponent<ImmovableMonster>() != null)
                    state_holder_stateManager.enemy_target.GetComponent<ImmovableMonster>().TakeDamage(main_robot.GetComponent<Robot_Status>().GetAttackPoint() * 3);
                else if (state_holder_stateManager.enemy_target.GetComponent<RoamMonster>() != null)
                    state_holder_stateManager.enemy_target.GetComponent<RoamMonster>().TakeDamage(main_robot.GetComponent<Robot_Status>().GetAttackPoint() * 3);

                SpawnParticles(hit_effect, state_holder_stateManager.enemy_target.transform.position);
            }
        }
        else
        {
            if(UsefulFunctions.GetDistanceOfTwoPoints(main_robot.transform.position, state_holder_stateManager.enemy_target.transform.position) > state_holder_stateManager.robot_local_sprite_size.x * 4)
            {
                isDone = true;
                return;
            }
            Vector2 temp = UsefulFunctions.GetDirectionFromOneToTwo(main_robot.transform.position, state_holder_stateManager.enemy_target.transform.position);
            main_robot.GetComponent<Rigidbody2D>().velocity = new Vector2(temp.x * (main_robot.GetComponent<Robot_Status>().GetSpeedPoint() * 10) * UsefulFunctions.ConstantValueToReplaceDT(), temp.y * (main_robot.GetComponent<Robot_Status>().GetSpeedPoint() * 10) * UsefulFunctions.ConstantValueToReplaceDT());
        }
	}

    public override void Execute()
    {

    }
}
