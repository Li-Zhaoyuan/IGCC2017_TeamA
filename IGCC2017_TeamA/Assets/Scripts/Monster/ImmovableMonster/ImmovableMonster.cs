//************************************************/
//* @file  :ImmovableMonster.cs
//* @brief :動かないモンスター
//* @brief :A monster that does not move
//* @date  :2017/09/08
//* @author:S.Katou
//************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum IMMOVABLE_MONSTER_STATE
{
	IDLE,   //不動なり
	ATTACK, //攻撃
	DEAD,   //死亡
}

public class ImmovableMonster : MonsterBase<ImmovableMonster, IMMOVABLE_MONSTER_STATE>
{
	public override void Start()
	{
		base.Start();

		stateList.Add(new ImmovableMonsterIdleState(this));
		stateList.Add(new ImmovableMonsterAttackState(this));
		stateList.Add(new ImmovableMonsterDeadState(this));

		stateMachine = new StateMachine<ImmovableMonster>();
		ChangeState(IMMOVABLE_MONSTER_STATE.IDLE);
	}

	public override void Update()
	{
		if (stateMachine != null)
		{
			stateMachine.Update();
		}

		if (m_stats.HP <= 0 && !(IsCurrentState(IMMOVABLE_MONSTER_STATE.DEAD)))
		{
			ChangeState(IMMOVABLE_MONSTER_STATE.DEAD);
		}
	}
}
