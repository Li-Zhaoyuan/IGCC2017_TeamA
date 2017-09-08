//************************************************/
//* @file  :MonsterSummoner.cs
//* @brief :モンスターを召喚する
//* @brief :Summon a monster
//* @date  :2017/09/08
//* @author:S.Katou
//************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSummoner : MonoBehaviour {

	//召喚するモンスター
	[SerializeField]
	private GameObject m_unit = null;

	//召喚の間隔
	[SerializeField]
	private float m_maxInterval = 5.0f;
	[SerializeField]
	private float m_minInterval = 1.0f;

	//このモンスターのいるエリア
	//Areas where this monster is located
	public GameObject m_chargeArea;

	//エリア範囲取得用
	//For area range acquisition
	private Collider2D m_col = null;

	private float m_cnt = 0.0f;
	private float m_startTime;
	private float m_interval = 1.0f;

	public void Start()
	{
		m_startTime = Time.time;

		m_interval = Random.Range(m_minInterval, m_maxInterval);

		m_col = m_chargeArea.GetComponent<Collider2D>();
	}

		void Update()
	{
		m_cnt = Time.time - m_startTime;

		if (m_cnt > m_interval)
		{
			Summon();

			m_startTime = Time.time;
			m_interval = Random.Range(m_minInterval, m_maxInterval);
		}
	}

	private GameObject Summon()
	{
		GameObject unit;
		unit = Instantiate(m_unit) as GameObject;
		unit.transform.position = RandomPos(gameObject.transform.position);

		var stats = unit.GetComponent<MonsterStats>();

		stats.m_chargeArea = m_chargeArea;
		stats.m_robotList = m_chargeArea.GetComponent<RobotList>();

		return unit;
	}

	private Vector3 RandomPos(Vector3 gameObjectPos)
	{
		Vector3 pos;
		Vector3 adjustment = new Vector3(0.0f,0.0f,0.0f);

		if (m_col != null)
		{
			var area = m_col.bounds.size;
			float x = area.x / 2.0f;
			float y = area.y / 2.0f;
			adjustment.x = Random.Range(-x, x);
			adjustment.y = Random.Range(-y, y);
		}
		pos = gameObjectPos + adjustment;

		return pos;
	}
}
