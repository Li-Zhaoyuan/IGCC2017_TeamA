using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestState : State<TestMonster>
{
	public TestState(TestMonster obj) : base(obj) { }

	private float m_cnt;
	private float m_time;

	/// <summary>
	/// 開始処理
	/// </summary>
	public override void Enter()
	{
		Debug.Log("Test Enter");
		m_time = Time.time;
	}

	/// <summary>
	/// 実行処理
	/// </summary>
	public override void Execute()
	{
		Debug.Log("Test Execute");
		obj.transform.position += (new Vector3(0, obj.GetComponent<MonsterStats>().SPD,0.0f));
		m_cnt = Time.time - m_time;

		if (m_cnt > 2.0f)
		{
			obj.ChangeState(TestMonsterState.DEAD);
		}
	}


	/// <summary>
	/// 終了処理
	/// </summary>
	public override void Exit()
	{
		Debug.Log("Test Exit");
	}
}

