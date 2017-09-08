//************************************************/
//* @file  :MonsterBase.cs
//* @brief :モンスターに共通する処理
//* @brief :Process common to monsters
//* @date  :2017/09/08
//* @author:S.Katou
//************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBase<T, TEnum> : MonoBehaviour
	where T : class where TEnum : System.IConvertible
{
	protected MonsterStats m_stats;

	[System.NonSerialized]
	public Animator m_anime;

	//左右反転用
	//For horizontal flip
	[System.NonSerialized]
	public SpriteRenderer m_spriteRenderer;

	//状態一覧
	//stateList
	protected List<State<T>> stateList = new List<State<T>>();

	// ステートの管理用クラス
	// State management class
	protected StateMachine<T> stateMachine;

	public virtual void Start()
	{
		m_stats = GetComponent<MonsterStats>();
		m_anime = GetComponentInChildren<Animator>();
		m_spriteRenderer = GetComponentInChildren<SpriteRenderer>();
	}

	public virtual void Update()
	{
		if (stateMachine != null)
			stateMachine.Update();
	}


	// ステート切替
	// Change State
	public virtual void ChangeState(TEnum state)
	{
		if (stateMachine == null)
		{
			return;
		}

		stateMachine.ChangeState(stateList[state.ToInt32(null)]);
	}


	// 現在のステートと一致していたらtrueを返す
	// Returns true if it matches the current state
	public virtual bool IsCurrentState(TEnum state)
	{
		if (stateMachine == null)
		{
			return false;
		}

		return stateMachine.CurrentState == stateList[state.ToInt32(null)];
	}


	public MonsterStats GetStats()
	{
		return m_stats;
	}


	public void TakeDamage(float damage)
	{
		float d = (damage - m_stats.DEF);
		if (d > 0.0f)
		{
			m_stats.HP -= damage;
		}
	}


	/// <summary>
	/// 画像の向きをターゲットがいる方向に合わせる
	/// Fit the orientation of the image to the direction in which the target is located
	/// </summary>
	/// <param name="targetPosX">ターゲットのX座標</param>
	/// <param name="targetPosX">X coordinate of the target</param>
	public void SpriteFlipX(float targetPosX)
	{
		if (targetPosX < transform.position.x)
		{
			m_spriteRenderer.flipX = true;
		}
		else
		{
			m_spriteRenderer.flipX = false;
		}
	}
}
