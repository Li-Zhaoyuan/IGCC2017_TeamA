//************************************************/
//* @file  :ChaseMonsterIdleState.cs
//* @brief :ロボットを追跡するモンスター待機状態
//* @brief :State to idle the robot
//* @date  :2017/09/11
//* @author:S.Katou
//************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseMonsterIdleState : State<ChaseMonster>
{
	public ChaseMonsterIdleState(ChaseMonster obj) : base(obj) { }

	//追跡するターゲット
	//Target to chase
	private GameObject m_target = null;

	private float m_timer = 0.0f;
	private Vector3 m_spd;
	private MonsterStats m_stats = null;
	private Collider2D m_area = null;

	/// <summary>
	/// 開始処理
	/// </summary>
	public override void Enter()
	{
		m_target = null;
		obj.m_anime.SetBool("isIdle", true);

		if (m_stats == null)
		{
			m_stats = obj.GetStats();
		}

		if (m_area == null)
		{
			m_area = obj.GetStats().m_chargeArea.GetComponent<Collider2D>();
		}
	}

	/// <summary>
	/// 実行処理
	public override void Execute()
	{
		m_timer += Time.deltaTime;

		obj.transform.position += m_spd;
		ClampPos();
		if (m_timer > 1.0f)
		{
			m_timer = 0.0f;
			SetSpd();
		}

		if (m_target == null)
		{
			m_target = obj.GetStats().m_robotList.GetTarget(obj.transform.position);
		}
		else
		{
			obj.ChangeState(CHASE_MONSTER_STATE.CHASE);
		}
	}


	/// <summary>
	/// 終了処理
	/// </summary>
	public override void Exit()
	{
		obj.m_anime.SetBool("isIdle", false);
		obj.m_anime.SetBool("isWalked", false);
	}


	private void SetSpd()
	{
		if (Random.Range(0, 19) < 6)//60% to not move
		{
			m_spd = Vector3.zero;

			obj.m_anime.SetBool("isIdle", true);
			obj.m_anime.SetBool("isWalked", false);

		}
		else
		{
			m_spd = new Vector3(Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f), 0.0f) * m_stats.SPD * Time.deltaTime;
			obj.SpriteFlipX(obj.transform.position.x + m_spd.x);

			obj.m_anime.SetBool("isIdle", false);
			obj.m_anime.SetBool("isWalked", true);
		}
	}


	private void ClampPos()
	{
		Vector3 objPos = obj.transform.position;
		Vector3 areaPos = obj.GetStats().m_chargeArea.transform.position;
		var size = m_area.bounds.size;
		float sizeX = size.x / 2.0f;
		float sizeY = size.y / 2.0f;

		objPos.x = Mathf.Clamp(objPos.x, areaPos.x - sizeX, areaPos.x + sizeX);
		objPos.y = Mathf.Clamp(objPos.y, areaPos.y - sizeY, areaPos.y + sizeY);


		obj.transform.position = objPos;
	}
}
