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

	private Robot_Status m_robotStats;

	/// <summary>
	/// 開始処理
	/// </summary>
	public override void Enter()
	{
		Debug.Log(obj.name + " Attack Enter");

		m_target = obj.m_tmpTarget;
		obj.m_anime.SetTrigger("attack");

		//ロボットにダメージを与える
		//Damaging robots
		m_robotStats = m_target.GetComponent<Robot_Status>();
		if (m_robotStats != null)
		{
			m_robotStats.TakeDamage(obj.GetStats().ATK);
		}
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
			obj.m_anime.SetTrigger("attack");

			//ロボットにダメージを与える
			//Damaging robots
			if (m_robotStats != null)
			{
				m_robotStats.TakeDamage(obj.GetStats().ATK);
			}
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
