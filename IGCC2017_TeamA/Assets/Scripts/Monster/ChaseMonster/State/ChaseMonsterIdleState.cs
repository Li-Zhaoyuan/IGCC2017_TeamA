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
		Debug.Log(obj.name + " Idle Enter");

		m_target = GameObject.Find("TestMonster");
		obj.m_anime.SetBool("isIdle", true);
	}

	/// <summary>
	/// 実行処理
	/// </summary>
	public override void Execute()
	{
		if (m_target == null)
		{
			m_target= GameObject.Find("TestMonster");
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
		Debug.Log(obj.name + " Idle Exit");
		obj.m_anime.SetBool("isIdle", false);
	}
}
