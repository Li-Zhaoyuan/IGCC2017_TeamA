using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDead : State<TestMonster>
{
	public TestDead(TestMonster obj) : base(obj) { }

	//このステートをオブジェクト
	private GameObject m_gameObject = null;

	private float m_cnt;
	private float m_time;


	/// <summary>
	/// 開始処理
	/// </summary>
	public override void Enter()
	{
		Debug.Log("Dead Enter");
		m_time = Time.time;
	}

	/// <summary>
	/// 実行処理
	/// </summary>
	public override void Execute()
	{
		Debug.Log("Dead Execute");
		m_cnt = Time.time - m_time;

		if (m_cnt > 5.0f)
		{
			obj.ChangeState(TestMonsterState.CHASE);
		}
	}


	/// <summary>
	/// 終了処理
	/// </summary>
	public override void Exit()
	{
		Debug.Log("Dead Exit");
	}
}
