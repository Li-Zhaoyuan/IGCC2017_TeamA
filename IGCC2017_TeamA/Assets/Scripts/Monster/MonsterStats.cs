//************************************************/
//* @file  :MonsterStats.cs
//* @brief :モンスターに必要なステータス
//* @brief :State required for monsters
//* @date  :2017/09/06
//* @author:S.Katou
//************************************************/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterStats : MonoBehaviour
{

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
}
