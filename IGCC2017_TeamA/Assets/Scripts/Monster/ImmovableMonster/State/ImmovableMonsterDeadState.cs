//************************************************/
//* @file  :ImmovableMonsterDeadState.cs
//* @brief :動かないモンスターの死亡状態
//* @brief :State of death
//* @date  :2017/09/08
//* @author:S.Katou
//************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmovableMonsterDeadState : State<ImmovableMonster>
{
	public ImmovableMonsterDeadState(ImmovableMonster obj) : base(obj) { }

	private float m_cnt;
	private float m_time;

	private GameObject m_target = null;
	private bool m_isDead = false;


	/// <summary>
	/// 開始処理
	/// Start processing
	/// </summary>
	public override void Enter()
	{
		m_time = Time.time;
		m_isDead = false;
		//obj.m_anime.SetTrigger("dead");
	}

	/// <summary>
	/// 実行処理
	/// Execution processing
	/// </summary>
	public override void Execute()
	{
		m_cnt = Time.time - m_time;

		if (m_cnt > 1.0f && !(m_isDead))
		{
			m_isDead = true;
			CreateEffect();
			obj.GetStats().m_deadSE.Play();
			obj.m_spriteRenderer.enabled = false;
			GameObject.Destroy(obj.gameObject, obj.GetStats().m_deadSE.clip.length);
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
