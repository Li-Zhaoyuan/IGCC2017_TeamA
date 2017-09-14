using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeButton : MonoBehaviour {

	[SerializeField]
	private GameObject m_buttonImage;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0))
		{

		}
		else
		{
			Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Collider2D collition2d = Physics2D.OverlapPoint(mousePos);
			if (collition2d)
			{
				m_buttonImage.SetActive(true);
			}
			else
			{
				m_buttonImage.SetActive(false);
			}
		}
	}
}
