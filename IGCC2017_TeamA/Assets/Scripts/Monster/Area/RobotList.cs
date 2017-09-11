using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotList : MonoBehaviour {

	private List<GameObject> m_robotList = new List<GameObject>();

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (m_robotList.Contains(null))
		{
			m_robotList.Remove(null);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		//当たったオブジェクトがロボットならばリストに追加
		//If the hit object is a robot add it to the list
		var robotStats = col.gameObject.GetComponent<Robot_Status>();

		if (robotStats != null)
		{
			m_robotList.Add(col.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		//当たったオブジェクトがロボットならばリストから削除
		//Delete from the list if the hit object is a robot
		var robotStats = col.gameObject.GetComponent<Robot_Status>();

		if (robotStats != null)
		{
			m_robotList.Remove(col.gameObject);
		}
	}


	/// <summary>
	/// 最も近い位置にいるロボットを取得する
	/// Acquire the closest robot
	/// </summary>
	/// <param name="monsterPos">ターゲットを取得するオブジェクトの位置</param>
	/// <param name="monsterPos">Position of object to obtain target</param>
	/// <returns>nullの場合はエリアにロボットがいない</returns>
	/// <returns>In the case of null, there is no robot in the area</returns>
	public GameObject GetTarget(Vector3 monsterPos)
	{
		GameObject target = null;
		float minDistance = float.MaxValue;

		foreach (var robot in m_robotList)
		{
			var robotStats = robot.GetComponent<Robot_Status>();
			if (robotStats != null)
			{
				Vector3 distance = robot.transform.position - monsterPos;

				if (distance.magnitude < minDistance && robotStats.health_point > 0.0f)
				{
					target = robot;
					minDistance = distance.magnitude;
				}
			}
		}

		return target;
	}
}
