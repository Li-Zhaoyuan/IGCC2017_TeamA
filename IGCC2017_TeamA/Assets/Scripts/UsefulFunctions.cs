using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UsefulFunctions  {



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

    //find item
    public static GameObject GetNearbyItemWithBoxCollider(Vector3 position, Vector2 size)
    {
        RaycastHit2D[] collision = Physics2D.BoxCastAll(position, size, 0, Vector2.zero, 0);

        foreach (RaycastHit2D temp in collision)
        {
            if (temp.collider != null)
            {
                if (temp.collider.gameObject.tag == "Item")
                {
                    return temp.collider.gameObject;
                }
            }
        }
        return null;
    }
    public static GameObject[] GetNearbyItemWithBoxColliderArray(Vector3 position, Vector2 size)
    {
        RaycastHit2D[] collision = Physics2D.BoxCastAll(position, size, 0, Vector2.zero, 0);
        List<GameObject> temp_list = new List<GameObject>();
        foreach (RaycastHit2D temp in collision)
        {
            if (temp.collider != null)
            {
                if (temp.collider.gameObject.tag == "Item")
                {
                    temp_list.Add(temp.collider.gameObject);

                }
            }
        }
        return temp_list.ToArray();
    }

    public static GameObject GetNearbyItemWithCircleCollider(Vector3 position, float radius)
    {
        RaycastHit2D[] collision = Physics2D.CircleCastAll(position, radius, Vector2.zero, 0);

        foreach (RaycastHit2D temp in collision)
        {
            if (temp.collider != null)
            {
                if (temp.collider.gameObject.tag == "Item")
                {
                    return temp.collider.gameObject;
                }
            }
        }
        return null;
    }
    public static GameObject[] GetNearbyItemWithCircleColliderArray(Vector3 position, float radius)
    {
        RaycastHit2D[] collision = Physics2D.CircleCastAll(position, radius, Vector2.zero, 0);
        List<GameObject> temp_list = new List<GameObject>();
        foreach (RaycastHit2D temp in collision)
        {
            if (temp.collider != null)
            {
                if (temp.collider.gameObject.tag == "Item")
                {
                    temp_list.Add(temp.collider.gameObject);
                }
            }
        }
        return temp_list.ToArray();
    }

    public static bool CheckForNearbyItemWithBoxCollider(Vector3 position, Vector2 size)
    {
        //RaycastHit2D[] collision = Physics2D.CircleCastAll(transform.position, local_sprite_size.x / 2, Vector2.zero, 0);
        RaycastHit2D[] collision = Physics2D.BoxCastAll(position, size, 0, Vector2.zero, 0);

        foreach (RaycastHit2D temp in collision)
        {
            if (temp.collider != null)
            {
                if (temp.collider.gameObject.tag == "Item")
                {
                    return true;
                }
            }
        }
        return false;
    }

    public static bool CheckForNearbyitemWithCircleCollider(Vector3 position, float radius)
    {
        //RaycastHit2D[] collision = Physics2D.CircleCastAll(transform.position, local_sprite_size.x / 2, Vector2.zero, 0);
        RaycastHit2D[] collision = Physics2D.CircleCastAll(position, radius, Vector2.zero, 0);

        foreach (RaycastHit2D temp in collision)
        {
            if (temp.collider != null)
            {
                if (temp.collider.gameObject.tag == "Item")
                {
                    return true;
                }
            }
        }
        return false;
    }


    //for drawing rect

    static Texture2D white_texture;
    public static Texture2D White_Texture
    {
        get
        {
            if(white_texture == null)
            {
                white_texture = new Texture2D(1, 1);
                white_texture.SetPixel(0, 0, Color.white);
                white_texture.Apply();
            }
            return white_texture;
        }
    }

    public static void DrawScreenRect(Rect rect, Color color)
    {
        GUI.color = color;
        GUI.DrawTexture(rect, White_Texture);
        GUI.color = Color.white;
    }

    public static void DrawScreenRectBorder(Rect rect,float thickness,Color color)
    {
        //top
        DrawScreenRect(new Rect(rect.xMin, rect.yMin, rect.width, thickness), color);
        //left
        DrawScreenRect(new Rect(rect.xMin, rect.yMin, thickness, rect.height), color);
        //right
        DrawScreenRect(new Rect(rect.xMax - thickness, rect.yMin, thickness, rect.height), color);
        //bottom
        DrawScreenRect(new Rect(rect.xMin, rect.yMax - thickness, rect.width, thickness), color);
    }

    public static Rect GetScreenRect(Vector3 screenpos1, Vector3 screenpos2)
    {
        //move the origin to the top left
        screenpos1.y = Screen.height - screenpos1.y;
        screenpos2.y = Screen.height - screenpos2.y;

        //corners
        var top_left = Vector3.Min(screenpos1,screenpos2);
        var bottom_right = Vector3.Max(screenpos1, screenpos2);

        return Rect.MinMaxRect(top_left.x, top_left.y, bottom_right.x, bottom_right.y);
    }

    public static Vector3 GetCenterOfLine(Vector3 pos1,Vector3 pos2)
    {
        //Vector3 tempTopleft, tempBottomRight;
        //tempTopleft = Vector3.Min(pos1, pos2);
        //tempBottomRight = Vector3.Max(pos1, pos2);

        return new Vector3((pos1.x + pos2.x) / 2, (pos1.y + pos2.y) / 2);
    }
}
