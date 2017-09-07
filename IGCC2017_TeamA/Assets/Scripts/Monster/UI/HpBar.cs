//************************************************/
//* @file  :HpBar.cs
//* @brief :ロボットを追跡するモンスターの追跡状態
//* @brief :State to chase the robot
//* @date  :2017/09/07
//* @author:S.Katou
//************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBar : MonoBehaviour {

	[SerializeField]
	private GameObject m_fill;

	[SerializeField]
	private MonsterStats m_stats;

	void Update () {
		m_fill.transform.localScale =new Vector3(m_stats.HP/m_stats.MAX_HP,m_fill.transform.localScale.y, m_fill.transform.localScale.z) ;
	}
}
