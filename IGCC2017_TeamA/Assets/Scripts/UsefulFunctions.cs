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
}
