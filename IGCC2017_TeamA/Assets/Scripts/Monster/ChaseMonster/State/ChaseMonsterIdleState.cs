//************************************************/
//* @file  :ChaseMonsterIdleState.cs
//* @brief :ロボットを追跡するモンスター待機状態
//* @brief :State to idle the robot
//* @date  :2017/09/07
//* @author:S.Katou
//************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseMonsterIdleState : State<ChaseMonster>
{
	public ChaseMonsterIdleState(ChaseMonster obj) : base(obj) { }

	//追跡するターゲット
	//Target to chase
	private GameObject m_target = null;

	/// <summary>
	/// 開始処理
	/// </summary>
	public override void Enter()
	{
		m_target = GameObject.Find("TestMonster");
		obj.m_anime.SetBool("isIdle", true);
	}

	/// <summary>
	/// 実行処理
	public override void Execute()
	{
		if (m_target == null)
		{
			m_target = obj.GetStats().m_robotList.GetTarget(obj.transform.position);
		}
		else
		{
			obj.ChangeState(ChaseMonsterState.CHASE);
		}
	}


	/// <summary>
	/// 終了処理
	/// </summary>
	public override void Exit()
	{
		obj.m_anime.SetBool("isIdle", false);
	}
}
