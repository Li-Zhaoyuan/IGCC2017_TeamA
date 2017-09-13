using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragRobot : MonoBehaviour {

	[SerializeField]
	private ClickObject clickObject;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0))
		{
			Debug.Log("Drag");
			if (clickObject.m_target != null)
			{
				Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				Debug.Log(pos);
				clickObject.m_target.transform.position = pos;
			}
		}
	}
}
