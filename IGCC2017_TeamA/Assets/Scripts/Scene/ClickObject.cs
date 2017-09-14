using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ClickObject : MonoBehaviour
{

	[System.NonSerialized]
	public GameObject m_target = null;

	[SerializeField]
	private GameObject m_selectEffect;

	[SerializeField]
	private AudioSource m_selectSE;

	// Update is called once per frame
	void Update()
	{
		GetClickObject();
		DragObject();
		if (m_target == null)
		{
			foreach (Selected_Effect effect in FindObjectsOfType<Selected_Effect>())
			{
				Destroy(effect.gameObject);
			}
		}
	}

	void GetClickObject()
	{
		//UIの場合は判定をしない
		//In case of UI, do not make judgment
		if (EventSystem.current.IsPointerOverGameObject())
		{
			return;
		}

		// 左クリックされた場所のオブジェクトを取得
		//Get the object of the left clicked place
		if (Input.GetMouseButtonDown(0))
		{
			Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Collider2D collition2d = Physics2D.OverlapPoint(tapPoint);
			if (collition2d)
			{
				if (collition2d.gameObject.tag == "Robot")
				{
					foreach (Selected_Effect effect in FindObjectsOfType<Selected_Effect>())
					{
						Destroy(effect.gameObject);
					}
					CreateEffect(collition2d.transform.gameObject);
					m_target = collition2d.transform.gameObject;
					m_selectSE.Play();
					return;
				}

			}

			m_target = null;
		}
	}

	void DragObject()
	{
		//UIの場合は判定をしない
		//In case of UI, do not make judgment
		if (EventSystem.current.IsPointerOverGameObject())
		{
			return;
		}

		if (Input.GetMouseButton(0))
		{
			if (m_target != null)
			{
				Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
				m_target.transform.position = pos;
			}
		}
	}


	void CreateEffect(GameObject target)
	{
		GameObject effect = null;
		effect = Instantiate(m_selectEffect, Vector3.zero, Quaternion.Euler(0, 0, 0)) as GameObject;
		effect.transform.parent = target.transform;
		effect.transform.localPosition = new Vector3(0, 0, 0);
	}

	public void ResetTarget()
	{
		m_target = null;
	}
}
