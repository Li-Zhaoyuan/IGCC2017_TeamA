//************************************************/
//* @file  :RoamMonsterRoamState.cs
//* @brief :徘徊するモンスターの徘徊状態
//* @brief :Roam status of monster
//* @date  :2017/09/11
//* @author:S.Katou
//************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamMonsterRoamState : State<RoamMonster>
{
	public RoamMonsterRoamState(RoamMonster obj) : base(obj) { }

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
		m_timer = 0.0f;
		m_target = null;

		//obj.m_anime.SetBool("isWalked", true);

		if (m_stats == null)
		{
			m_stats = obj.GetStats();
		}

		if (m_area==null)
		{
			m_area = obj.GetStats().m_chargeArea.GetComponent<Collider2D>();
		}
	}

	/// <summary>
	/// 実行処理
	/// </summary>
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
			SetTarget();
		}
		else
		{
			obj.ChangeState(ROAM_MONSTER_STATE.ATTACK);
		}
	}


	/// <summary>
	/// 終了処理
	/// </summary>
	public override void Exit()
	{
		//obj.m_anime.SetBool("isWalked", false);
		//obj.m_anime.SetBool("isIdle", false);
	}

	private void SetTarget()
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

	private void SetSpd()
	{
		if (Random.Range(0, 19) < 2)//20% to not move
		{
			m_spd = Vector3.zero;
			//obj.m_anime.SetBool("isWalked", false);
			//obj.m_anime.SetBool("isIdle", true);
		}
		else
		{
			m_spd = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0.0f)* m_stats.SPD * Time.deltaTime;
			obj.SpriteFlipX(obj.transform.position.x + m_spd.x);
			//obj.m_anime.SetBool("isWalked", true);
			//obj.m_anime.SetBool("isIdle", false);
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
