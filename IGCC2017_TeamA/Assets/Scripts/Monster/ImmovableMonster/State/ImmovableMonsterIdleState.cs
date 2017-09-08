using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImmovableMonsterIdleState : State<ImmovableMonster>
{

	public ImmovableMonsterIdleState(ImmovableMonster obj) : base(obj) { }

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
			var target = obj.GetStats().m_robotList.GetTarget(obj.transform.position);
			if (target != null)
			{
				Vector3 direction = target.transform.position - obj.transform.position;

				if (direction.magnitude < 1.0f)
				{
					m_target = obj.GetStats().m_robotList.GetTarget(obj.transform.position);
				}
			}
		}
		else
		{
			obj.ChangeState(IMMOVABLE_MONSTER_STATE.ATTACK);
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
