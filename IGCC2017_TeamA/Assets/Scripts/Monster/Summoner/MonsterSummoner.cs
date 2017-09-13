//************************************************/
//* @file  :MonsterSummoner.cs
//* @brief :モンスターを召喚する
//* @brief :Summon a monster
//* @date  :2017/09/13
//* @author:S.Katou
//************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSummoner : MonoBehaviour {

	[SerializeField]
	private ItemGenerator m_itemGenerator = null;

	[SerializeField]
	private float m_probabilityOfItem = 20.0f;

	//召喚するモンスター
	[SerializeField]
	private GameObject[] m_unit = null;

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


	[SerializeField]
	private float m_addHPMax = 200.0f;

	[SerializeField]
	private float m_addATKMax = 5.0f;

	[SerializeField]
	private float m_addDEFMax = 5.0f;

	[SerializeField]
	private float m_addSPDMax = 5.0f;

	private float m_cnt = 0.0f;
	private float m_startTime;
	private float m_interval = 1.0f;

	void Start()
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

	private void Summon()
	{
		float probability = Random.Range(0.0f, 100.0f);


		//召喚するユニットがモンスターならばエリアの情報を設定する
		//If the unit to be summoned is a monster, set area information
		if (probability > m_probabilityOfItem)
		{
			GameObject unit;
			int num = Random.Range(0, m_unit.Length);

			unit = Instantiate(m_unit[num]) as GameObject;
			unit.transform.position = RandomPos(gameObject.transform.position);

			var stats = unit.GetComponent<MonsterStats>();

			stats.m_chargeArea = m_chargeArea;
			stats.m_robotList = m_chargeArea.GetComponent<RobotList>();

			stats.HP += Random.Range(0, m_addHPMax);
			stats.ATK += Random.Range(0, m_addATKMax);
			stats.DEF += Random.Range(0, m_addDEFMax);
			stats.SPD += Random.Range(0, m_addSPDMax);
		}
		else
		{
			m_itemGenerator.SpawnRandomResource(RandomPos(gameObject.transform.position));
		}
	}


	/// <summary>
	/// 召喚位置をエリア内でランダムに決定する
	/// Randomly determine the summoning position within the area
	/// </summary>
	/// <param name="gameObjectPos">エリアの中心位置</param>
	/// <param name="gameObjectPos">Center position of area</param>
	/// <returns>召喚位置</returns>
	/// <returns>Summon position</returns>
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
