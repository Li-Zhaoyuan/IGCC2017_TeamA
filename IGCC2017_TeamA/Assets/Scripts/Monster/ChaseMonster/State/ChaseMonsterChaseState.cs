﻿//************************************************/
//* @file  :ChaseMonsterChaseState.cs
//* @brief :ロボットを追跡するモンスターの追跡状態
//* @brief :State to chase the robot
//* @date  :2017/09/07
//* @author:S.Katou
//************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseMonsterChaseState : State<ChaseMonster>
{
	public ChaseMonsterChaseState(ChaseMonster obj) : base(obj) { }

	//追跡するターゲット
	//Target to chase
	private GameObject m_target = null;

	/// <summary>
	/// 開始処理
	/// Start processing
	/// </summary>
	public override void Enter()
	{
		//m_target = obj.GetStats().m_robotList.GetTarget(obj.transform.position);

		//obj.m_anime.SetBool("isWalked",true);
	}

	/// <summary>
	/// 実行処理
	/// Execution processing
	/// </summary>
	public override void Execute()
	{
		m_target = obj.GetStats().m_robotList.GetTarget(obj.transform.position);

		if (m_target == null)
		{
			obj.ChangeState(CHASE_MONSTER_STATE.IDLE);
			return;
		}
		// 画像の向きをターゲットがいる方向に合わせる
		// Fit the orientation of the image to the direction in which the target is located
		obj.SpriteFlipX(m_target.transform.position.x);

		//ターゲットの存在する方向
		//Direction in which the target exists
		Vector3 direction = m_target.transform.position - obj.transform.position;

		//ターゲットに近づいていたら攻撃状態に移行する
		//When approaching the target, it shifts to the attack state
		if (direction.magnitude < 1)
		{
			obj.ChangeState(CHASE_MONSTER_STATE.ATTACK);
			return;
		}

		//ターゲットの方向に移動
		//Move in the direction of the target
		direction.Normalize();
		obj.transform.position += direction * obj.GetStats().SPD * Time.deltaTime;
	}


	/// <summary>
	/// 終了処理
	/// End processing
	/// </summary>
	public override void Exit()
	{
		//obj.m_anime.SetBool("isWalked", false);
	}
}
