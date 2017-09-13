//************************************************/
//* @file  :MonsterStats.cs
//* @brief :モンスターに必要なステータス
//* @brief :State required for monsters
//* @date  :2017/09/13
//* @author:S.Katou
//************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStats : MonoBehaviour
{
	public GameObject m_attackEffect;

	public GameObject m_deadEffect;

	[System.NonSerialized]
	public AudioSource m_hitSE;

	[System.NonSerialized]
	public AudioSource m_deadSE;

	//体力 HitPoint
	[SerializeField]
	private float m_hp;
	public float HP
	{
		get { return m_hp; }
		set
		{
			if (value > 0) { m_hp = value; }
			else { m_hp = 0; }
		}
	}

	//最大体力 MaxHitPoint
	private float m_maxHp;
	public float MAX_HP
	{
		get { return m_maxHp; }
	}

	//攻撃力　Attack
	[SerializeField]
	private float m_atk;
	public float ATK
	{
		get { return m_atk; }
		set
		{
			if (value > 0) { m_atk = value; }
			else { m_atk = 0; }
		}
	}

	//攻撃速度　AttackSpeed
	[SerializeField]
	private float m_attackInterval;
	public float AtkInterval
	{
		get { return m_attackInterval; }
		set
		{
			if (value > 0.1f) { m_attackInterval = value; }
			else { m_attackInterval = 0.1f; }
		}
	}

	//移動速度　MoveSpeed
	[SerializeField]
	private float m_spd;
	public float SPD
	{
		get { return m_spd; }
		set
		{
			if (value > 0) { m_spd = value; }
			else { m_spd = 0; }
		}
	}

	//守備力　Defense
	[SerializeField]
	private float m_def;
	public float DEF
	{
		get { return m_def; }
		set
		{
			if (value > 0) { m_def = value; }
			else { m_def = 0; }
		}
	}

	//魔法力　Magic
	[SerializeField]
	private float m_mag;
	public float MAG
	{
		get { return m_mag; }
		set
		{
			if (value > 0) { m_mag = value; }
			else { m_mag = 0; }
		}
	}

	//このモンスターのいるエリア
	//Areas where this monster is located
	public GameObject m_chargeArea;

	[System.NonSerialized]
	public RobotList m_robotList;

	public void Start()
	{
		var audio= GetComponentsInChildren<AudioSource>();
		m_hitSE = audio[0];
		m_deadSE = audio[1];

		m_maxHp = m_hp;
		if (m_chargeArea != null)
		{
			m_robotList = m_chargeArea.GetComponent<RobotList>();
		}
	}

	public void CreateEffect(GameObject effect, Vector3 pos)
	{
		GameObject.Instantiate(effect,pos, Quaternion.Euler(0, 0, 0));
	}
}
