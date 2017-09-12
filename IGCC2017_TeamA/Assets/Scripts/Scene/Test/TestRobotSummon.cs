using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRobotSummon : MonoBehaviour {

	// Use this for initialization
	void Start () {
		var list = RobotHolder.instance.robotList;

		foreach(var robot in list)
		{
			if (robot != null)
			{
				robot.SetActive(true);
				robot.transform.position = Vector3.zero;
			}
		}
	}

	void OnDestroy()
	{
		var list = RobotHolder.instance.robotList;

		foreach (var robot in list)
		{
			if (robot != null)
			{
				robot.SetActive(false);
			}
		}
	}
}
