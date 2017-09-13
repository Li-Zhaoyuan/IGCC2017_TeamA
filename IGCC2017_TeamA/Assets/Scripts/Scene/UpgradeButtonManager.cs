using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtonManager : MonoBehaviour {

	[SerializeField]
	private float m_radius = 2.0f;

	[SerializeField]
	private Button[] m_upgradeButton = new Button[8];

	[SerializeField]
	private ClickObject m_clickTarget;

	private GameObject m_target = null;


	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		m_target = m_clickTarget.m_target;

		if (m_target != null)
		{
			for (int i = 0; i < 8; i++)
			{
				//オブジェクト間の角度差
				float angleDiff = 360.0f / 8.0f;

				Vector3 postion = m_target.transform.position;

				float angle = (90 - angleDiff * i) * Mathf.Deg2Rad;
				postion.x += m_radius*Mathf.Cos(angle);
				postion.y += m_radius*Mathf.Sin(angle);

				m_upgradeButton[i].transform.position = postion;
			}
		}
		else
		{
			for (int i = 0; i < 8; i++)
			{
				m_upgradeButton[i].transform.position = new Vector3(0.0f,300.0f,0.0f);
			}
		}
	}
}
