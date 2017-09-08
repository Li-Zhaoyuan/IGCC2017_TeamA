//************************************************/
//* @file  :ChaseMonster.cs
//* @brief :ロボットを追跡するモンスター
//* @brief :Monster to track the robot
//* @date  :2017/09/07
//* @author:S.Katou
//************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CHASE_MONSTER_STATE
{
	IDLE,
	CHASE,  //追跡
	ATTACK,	//攻撃
	DEAD,   //死亡
}

public class ChaseMonster : MonsterBase<ChaseMonster, CHASE_MONSTER_STATE>
{
	public override void Start () {
		base.Start();

		stateList.Add(new ChaseMonsterIdleState(this));
		stateList.Add(new ChaseMonsterChaseState(this));
		stateList.Add(new ChaseMonsterAttackState(this));
		stateList.Add(new ChaseMonsterDeadState(this));

		stateMachine = new StateMachine<ChaseMonster>();
		ChangeState(CHASE_MONSTER_STATE.CHASE);
	}

	public override void Update()
	{
		if (stateMachine != null)
		{
			stateMachine.Update();
		}

		if (m_stats.HP <= 0 && !(IsCurrentState(CHASE_MONSTER_STATE.DEAD)))
		{
			ChangeState(CHASE_MONSTER_STATE.DEAD);
		}
	}
}
