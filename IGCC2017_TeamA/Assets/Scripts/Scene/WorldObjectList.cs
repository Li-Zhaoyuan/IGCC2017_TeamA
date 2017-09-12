﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObjectList : MonoBehaviour {

	private List<GameObject> m_gameObjectList = new List<GameObject>();

	void OnTriggerEnter2D(Collider2D col)
	{
		m_gameObjectList.Add(col.gameObject);
	}

	void OnTriggerExit2D(Collider2D col)
	{
		m_gameObjectList.Remove(col.gameObject);
	}

	void OnDestroy()
	{
		//当たったオブジェクトがロボットならばリストから削除
		//Delete from the list if the hit object is a robot
		foreach (var obj in m_gameObjectList)
		{
			if (obj == null) continue;

			var robotStats = obj.gameObject.GetComponent<Robot_Status>();

			if (robotStats != null)
			{
				RobotHolder.instance.AddRobot(obj);
			}
			else
			{
				Destroy(obj);
			}
		}
	}
}