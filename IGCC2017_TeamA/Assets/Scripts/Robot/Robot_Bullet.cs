using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_Bullet : Base_Projectile {

    Rigidbody2D rigidBody;

    GameObject temp_obj;
    //CircleCollider2D circle_collider;

    // Use this for initialization
    public override void Start()
    {
        base.Start();
        rigidBody = GetComponent<Rigidbody2D>();
        //circle_collider = GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    public override void Update()
    {
        life_time += Time.deltaTime;
        if (life_time > max_life_time)
            Destroy(gameObject);

        enemy = UsefulFunctions.GetNearbyEnemyWithCircleCollider(transform.position, projectile_local_sprite_size.x/2);

        if(enemy != null)//hit
        {
            // do damage to the enemy
            temp_obj = Instantiate(disappear_effect, transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
            
            Destroy(gameObject);
        }

        projectile_direction.Normalize();
        rigidBody.velocity = new Vector2(projectile_direction.x * projectile_speed, projectile_direction.y * projectile_speed);
    }
}
