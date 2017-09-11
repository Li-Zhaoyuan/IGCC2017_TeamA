//************************************************/
//* @file  :RoamMonster.cs
//* @brief :徘徊するモンスター
//* @brief :Wandering monster
//* @date  :2017/09/11
//* @author:S.Katou
//************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ROAM_MONSTER_STATE
{
	ROAM,   //徘徊する
	ATTACK, //攻撃
	DEAD,   //死亡
}

public class RoamMonster : MonsterBase<RoamMonster, ROAM_MONSTER_STATE>
{
	public override void Start()
	{
		base.Start();

		stateList.Add(new RoamMonsterRoamState(this));
		stateList.Add(new RoamMonsterAttackState(this));
		stateList.Add(new RoamMonsterDeadState(this));

		stateMachine = new StateMachine<RoamMonster>();
		ChangeState(ROAM_MONSTER_STATE.ROAM);
	}

	public override void Update()
	{
		if (stateMachine != null)
		{
			stateMachine.Update();
		}

		if (m_stats.HP <= 0 && !(IsCurrentState(ROAM_MONSTER_STATE.DEAD)))
		{
			ChangeState(ROAM_MONSTER_STATE.DEAD);
		}
	}
}
