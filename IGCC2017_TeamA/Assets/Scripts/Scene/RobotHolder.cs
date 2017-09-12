using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotHolder : MonoBehaviour {

	static public RobotHolder instance;

	private List<GameObject> m_robotList = new List<GameObject>();

	public List<GameObject> robotList
	{
		get { return m_robotList; }
	}

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Destroy(gameObject);
		}
	}

	public bool AddRobot(GameObject robot)
	{
		if (!(m_robotList.Contains(robot)))
		{
			robot.SetActive(false);
			Debug.Log("Add Robot");
			m_robotList.Add(robot);

			return true;
		}
		return false;
	}

	public bool DestroyRobot(GameObject robot)
	{
		if (m_robotList.Contains(robot))
		{
			Debug.Log("Remove Robot");
			m_robotList.Remove(robot);
			return true;
		}
		return false;
	}
}
