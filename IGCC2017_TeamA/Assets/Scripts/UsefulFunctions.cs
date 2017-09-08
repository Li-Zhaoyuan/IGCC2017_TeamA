using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsefulFunctions  {

	public static float GetDistanceOfTwoPoints(Vector2 one , Vector2 two)
    {
        return (one - two).magnitude;
    }

    public static float GetDistanceOfTwoPoints(Vector3 one, Vector3 two)
    {
        return (one - two).magnitude;
    }

    public static Vector2 GetDirectionFromOneToTwo(Vector2 one, Vector2 two)
    {
        return (two - one).normalized;
    }

    public static Vector3 GetDirectionFromOneToTwo(Vector3 one, Vector3 two)
    {
        return (two - one).normalized;
    }

    public static float GetPercentageInFloat(float one, float two)
    {
        return one/two;
    }

    public static GameObject GetNearbyEnemyWithBoxCollider(Vector3 position, Vector2 size)
    {
        RaycastHit2D[] collision = Physics2D.BoxCastAll(position, size, 0, Vector2.zero, 0);

        foreach (RaycastHit2D temp in collision)
        {
            if (temp.collider != null)
            {
                if (temp.collider.gameObject.tag == "Monster")
                {
                    return temp.collider.gameObject;
                }
            }
        }
        return null;
    }
    public static GameObject[] GetNearbyEnemyWithBoxColliderArray(Vector3 position, Vector2 size)
    {
        RaycastHit2D[] collision = Physics2D.BoxCastAll(position, size, 0, Vector2.zero, 0);
        List<GameObject> temp_list = new List<GameObject>();
        foreach (RaycastHit2D temp in collision)
        {
            if (temp.collider != null)
            {
                if (temp.collider.gameObject.tag == "Monster")
                {
                    temp_list.Add(temp.collider.gameObject);
                    
                }
            }
        }
        return temp_list.ToArray();
    }

    public static GameObject GetNearbyEnemyWithCircleCollider(Vector3 position, float radius)
    {
        RaycastHit2D[] collision = Physics2D.CircleCastAll(position, radius, Vector2.zero, 0);

        foreach (RaycastHit2D temp in collision)
        {
            if (temp.collider != null)
            {
                if (temp.collider.gameObject.tag == "Monster")
                {
                    return temp.collider.gameObject;
                }
            }
        }
        return null;
    }
    public static GameObject[] GetNearbyEnemyWithCircleColliderArray(Vector3 position, float radius)
    {
        RaycastHit2D[] collision = Physics2D.CircleCastAll(position, radius, Vector2.zero, 0);
        List<GameObject> temp_list = new List<GameObject>();
        foreach (RaycastHit2D temp in collision)
        {
            if (temp.collider != null)
            {
                if (temp.collider.gameObject.tag == "Monster")
                {
                    temp_list.Add(temp.collider.gameObject);
                }
            }
        }
        return temp_list.ToArray();
    }

    public static bool CheckForNearbyEnemyWithBoxCollider(Vector3 position,Vector2 size)
    {
        //RaycastHit2D[] collision = Physics2D.CircleCastAll(transform.position, local_sprite_size.x / 2, Vector2.zero, 0);
        RaycastHit2D[] collision = Physics2D.BoxCastAll(position, size, 0,Vector2.zero,0);

        foreach (RaycastHit2D temp in collision)
        {
            if (temp.collider != null)
            {
                if (temp.collider.gameObject.tag == "Monster")
                {
                    return true;
                }
            }
        }
        return false;
    }

    public static bool CheckForNearbyEnemyWithCircleCollider(Vector3 position, float radius)
    {
        //RaycastHit2D[] collision = Physics2D.CircleCastAll(transform.position, local_sprite_size.x / 2, Vector2.zero, 0);
        RaycastHit2D[] collision = Physics2D.CircleCastAll(position, radius, Vector2.zero, 0);

        foreach (RaycastHit2D temp in collision)
        {
            if (temp.collider != null)
            {
                if (temp.collider.gameObject.tag == "Monster")
                {
                    return true;
                }
            }
        }
        return false;
    }


    //find robot
    public static GameObject GetNearbyRobotWithBoxCollider(Vector3 position, Vector2 size)
    {
        RaycastHit2D[] collision = Physics2D.BoxCastAll(position, size, 0, Vector2.zero, 0);

        foreach (RaycastHit2D temp in collision)
        {
            if (temp.collider != null)
            {
                if (temp.collider.gameObject.tag == "Robot")
                {
                    return temp.collider.gameObject;
                }
            }
        }
        return null;
    }
    public static GameObject[] GetNearbyRobotWithBoxColliderArray(Vector3 position, Vector2 size)
    {
        RaycastHit2D[] collision = Physics2D.BoxCastAll(position, size, 0, Vector2.zero, 0);
        List<GameObject> temp_list = new List<GameObject>();
        foreach (RaycastHit2D temp in collision)
        {
            if (temp.collider != null)
            {
                if (temp.collider.gameObject.tag == "Robot")
                {
                    temp_list.Add(temp.collider.gameObject);

                }
            }
        }
        return temp_list.ToArray();
    }

    public static GameObject GetNearbyRobotWithCircleCollider(Vector3 position, float radius)
    {
        RaycastHit2D[] collision = Physics2D.CircleCastAll(position, radius, Vector2.zero, 0);

        foreach (RaycastHit2D temp in collision)
        {
            if (temp.collider != null)
            {
                if (temp.collider.gameObject.tag == "Robot")
                {
                    return temp.collider.gameObject;
                }
            }
        }
        return null;
    }
    public static GameObject[] GetNearbyRobotWithCircleColliderArray(Vector3 position, float radius)
    {
        RaycastHit2D[] collision = Physics2D.CircleCastAll(position, radius, Vector2.zero, 0);
        List<GameObject> temp_list = new List<GameObject>();
        foreach (RaycastHit2D temp in collision)
        {
            if (temp.collider != null)
            {
                if (temp.collider.gameObject.tag == "Robot")
                {
                    temp_list.Add(temp.collider.gameObject);
                }
            }
        }
        return temp_list.ToArray();
    }

    public static bool CheckForNearbyRobotWithBoxCollider(Vector3 position, Vector2 size)
    {
        //RaycastHit2D[] collision = Physics2D.CircleCastAll(transform.position, local_sprite_size.x / 2, Vector2.zero, 0);
        RaycastHit2D[] collision = Physics2D.BoxCastAll(position, size, 0, Vector2.zero, 0);

        foreach (RaycastHit2D temp in collision)
        {
            if (temp.collider != null)
            {
                if (temp.collider.gameObject.tag == "Robot")
                {
                    return true;
                }
            }
        }
        return false;
    }

    public static bool CheckForNearbyRobotWithCircleCollider(Vector3 position, float radius)
    {
        //RaycastHit2D[] collision = Physics2D.CircleCastAll(transform.position, local_sprite_size.x / 2, Vector2.zero, 0);
        RaycastHit2D[] collision = Physics2D.CircleCastAll(position, radius, Vector2.zero, 0);

        foreach (RaycastHit2D temp in collision)
        {
            if (temp.collider != null)
            {
                if (temp.collider.gameObject.tag == "Robot")
                {
                    return true;
                }
            }
        }
        return false;
    }
}
