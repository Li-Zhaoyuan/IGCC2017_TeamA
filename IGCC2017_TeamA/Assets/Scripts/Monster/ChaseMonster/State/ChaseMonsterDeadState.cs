﻿//************************************************/
//* @file  :ChaseMonsterDeadState.cs
//* @brief :ロボットを追跡するモンスターの死亡状態
//* @brief :State of death
//* @date  :2017/09/07
//* @author:S.Katou
//************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseMonsterDeadState : State<ChaseMonster>
{
	public ChaseMonsterDeadState(ChaseMonster obj) : base(obj) { }

	private float m_cnt;
	private float m_time;

	private GameObject m_target = null;

	/// <summary>
	/// 開始処理
	/// Start processing
	/// </summary>
	public override void Enter()
	{
		m_time = Time.time;
		obj.m_anime.SetTrigger("dead");
	}

	/// <summary>
	/// 実行処理
	/// Execution processing
	/// </summary>
	public override void Execute()
	{
		m_cnt = Time.time - m_time;

		if (m_cnt > 2.0f)
		{
			CreateEffect();
			GameObject.Destroy(obj.gameObject);
		}
	}


	/// <summary>
	/// 終了処理
	/// End processing
	/// </summary>
	public override void Exit()
	{

	}

	private void CreateEffect()
	{
		obj.GetStats().CreateEffect(obj.GetStats().m_deadEffect, obj.transform.position);
	}

}
