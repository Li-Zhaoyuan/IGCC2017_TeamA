using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base_Projectile : MonoBehaviour {

    protected Vector2 projectile_direction;
    protected float projectile_speed;
    protected float projectile_damage;
    protected float max_life_time;
    protected float life_time;
    //size of the sprite.
    protected Vector2 projectile_sprite_size;
    protected Vector2 projectile_local_sprite_size;
    protected float projectile_sprite_across_length;
    protected Sprite projectile_sprite;

    protected GameObject enemy;

    public GameObject disappear_effect;

    // Use this for initialization
    public virtual void Start () {
        life_time = 0f;

        //get the sprite size
        projectile_sprite = GetComponent<SpriteRenderer>().sprite;
        projectile_sprite_size = projectile_sprite.rect.size;
        projectile_local_sprite_size = projectile_sprite_size / projectile_sprite.pixelsPerUnit;
        projectile_sprite_across_length = Mathf.Sqrt(projectile_local_sprite_size.x * projectile_local_sprite_size.x + projectile_local_sprite_size.y * projectile_local_sprite_size.y);


        enemy = null;
    }

    // Update is called once per frame
    public virtual void Update () {
		
	}

    //setter
    public virtual void Initialize(Vector2 direction, float speed, float damage, float time)
    {
        projectile_direction = direction;
        projectile_speed = speed;
        projectile_damage = damage;
        max_life_time = time;
    }
}
