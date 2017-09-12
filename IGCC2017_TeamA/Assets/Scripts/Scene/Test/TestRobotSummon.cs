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
				//robot.SetActive(true);
				robot.transform.position = Vector3.zero;
				var stats = robot.GetComponent<Robot_Status>();
				stats.health_point = 100.0f;
				stats.energy_point = 100.0f;
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
				//robot.SetActive(false);
			}
		}
	}
}
