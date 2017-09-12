using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickObject : MonoBehaviour {

	[System.NonSerialized]
	public GameObject m_target = null;

	// Update is called once per frame
	void Update()
	{
		GetClickObject();
	}

	void GetClickObject()
	{
		if (EventSystem.current.IsPointerOverGameObject())
		{
			return;
		}

		// 左クリックされた場所のオブジェクトを取得
		if (Input.GetMouseButtonDown(0))
		{
			Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Collider2D collition2d = Physics2D.OverlapPoint(tapPoint);
			if (collition2d)
			{
				if (collition2d.gameObject.tag == "Robot")
				{
					m_target = collition2d.transform.gameObject;
					return;
				}

			}

			m_target = null;
		}
	}

	public void ResetTarget()
	{
		m_target = null;
	}
}
