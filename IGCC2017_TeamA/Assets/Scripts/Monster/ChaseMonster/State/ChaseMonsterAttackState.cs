//************************************************/
//* @file  :ChaseMonsterAttackState.cs
//* @brief :ロボットを追跡するモンスターの攻撃状態
//* @brief :Attack status of monster
//* @date  :2017/09/07
//* @author:S.Katou
//************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseMonsterAttackState : State<ChaseMonster>
{
	public ChaseMonsterAttackState(ChaseMonster obj) : base(obj) { }

	//攻撃対象
	//Attack target
	private GameObject m_target = null;

	/// <summary>
	/// 開始処理
	/// </summary>
	public override void Enter()
	{
		Debug.Log(obj.name + " Attack Enter");

		m_target = GameObject.Find("TestMonster");
		obj.m_anime.SetTrigger("attack");
	}

	/// <summary>
	/// 実行処理
	/// </summary>
	public override void Execute()
	{
		if (m_target == null)
		{
			obj.ChangeState(ChaseMonsterState.CHASE);
			return;
		}

		// 画像の向きをターゲットがいる方向に合わせる
		// Fit the orientation of the image to the direction in which the target is located
		obj.SpriteFlipX(m_target.transform.position.x);

		//攻撃が終わったらもう一度攻撃する
		//Attack once again when the attack ends
		if (obj.m_anime.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
		{
			Debug.Log(obj.name + " Attack");
			obj.m_anime.SetTrigger("attack");
		}

		//ターゲットの存在する方向
		//Direction in which the target exists
		Vector3 direction = m_target.transform.position - obj.transform.position;

		//ターゲットに離れていたら追跡状態に移行する
		//If you are away from target, shift to chase state
		if (direction.magnitude >= 1.0f)
		{
			obj.ChangeState(ChaseMonsterState.CHASE);
			return;
		}
	}


	/// <summary>
	/// 終了処理
	/// </summary>
	public override void Exit()
	{
		Debug.Log(obj.name + " Attack Exit");
	}
}
