//************************************************/
//* @file  :ImmovableMonsterAttackState.cs
//* @brief :動かないモンスターの攻撃状態
//* @brief :Attack status of monster
//* @date  :2017/09/08
//* @author:S.Katou
//************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmovableMonsterAttackState : State<ImmovableMonster>
{
	public ImmovableMonsterAttackState(ImmovableMonster obj) : base(obj) { }

	//攻撃対象
	//Attack target
	private GameObject m_target = null;

	private Robot_Status m_robotStats;

	//ダメージを与える処理をアニメーション中に一回に制限する
	//Limit damage processing to one at time during animation
	private bool isTakedDamage = false;
	private float m_timer = 0.0f;


	/// <summary>
	/// 開始処理
	/// Start processing
	/// </summary>
	public override void Enter()
	{
		m_target = obj.GetStats().m_robotList.GetTarget(obj.transform.position);

		//obj.m_anime.SetTrigger("attack");
		m_timer = 0.0f;

		if (m_target != null)
		{
			m_robotStats = m_target.GetComponent<Robot_Status>();
			m_robotStats.TakeDamage(obj.GetStats().ATK);
			CreateEffect();
			isTakedDamage = true;
		}
	}


	/// <summary>
	/// 実行処理
	/// Execution processing
	/// </summary>
	public override void Execute()
	{
		if (ShouldChangeIdleState())
		{
			obj.ChangeState(IMMOVABLE_MONSTER_STATE.IDLE);
			return;
		}
		m_timer += Time.deltaTime;

		// 画像の向きをターゲットがいる方向に合わせる
		// Fit the orientation of the image to the direction in which the target is located
		obj.SpriteFlipX(m_target.transform.position.x);

		//攻撃が終わったらもう一度攻撃する
		//Attack once again when the attack ends
		//if (obj.m_anime.GetCurrentAnimatorStateInfo(0).normalizedTime > 1.0f)
		if (m_timer > obj.GetStats().AtkInterval)
		{
			//obj.m_anime.SetTrigger("attack");

			if (m_robotStats != null && !(isTakedDamage))
			{
				m_robotStats.TakeDamage(obj.GetStats().ATK);
				CreateEffect();
				isTakedDamage = true;
			}
		}
		else
		{
			isTakedDamage = false;
		}
	}


	/// <summary>
	/// 終了処理
	/// End processing
	/// </summary>
	public override void Exit()
	{
		isTakedDamage = false;
	}



	/// <summary>
	/// 待機状態に戻るべきかどうか
	/// Whether to return to the Idle state or not
	/// </summary>
	private bool ShouldChangeIdleState()
	{
		if (m_target == null)
		{
			return true;
		}

		//ターゲットの存在する方向
		//Direction in which the target exists
		Vector3 direction = m_target.transform.position - obj.transform.position;

		//ターゲットに離れていたら追跡状態に移行する
		//If you are away from target, shift to chase state
		if (direction.magnitude >= 1.0f)
		{
			return true;
		}

		if (m_robotStats.health_point <= 0.0f)
		{
			return true;
		}

		return false;
	}

	private void CreateEffect()
	{
		//ターゲットの存在する方向
		//Direction in which the target exists
		Vector3 direction = m_target.transform.position - obj.transform.position;

		obj.GetStats().CreateEffect(obj.GetStats().m_attackEffect, (direction * 0.8f) + obj.transform.position);
	}
}
