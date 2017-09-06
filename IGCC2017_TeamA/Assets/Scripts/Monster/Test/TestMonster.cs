using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TestMonsterState
{
	CHASE,  //追跡
	DEAD,   //死亡
}
public class TestMonster :MonsterBase<TestMonster, TestMonsterState>
{
	void Start () {
		stateList.Add(new TestState(this));
		stateList.Add(new TestDead(this));

		stateMachine = new StateMachine<TestMonster>();
		ChangeState(TestMonsterState.CHASE);
	}

	public override void Update()
	{
		if (stateMachine != null)
			stateMachine.Update();

	}

}
