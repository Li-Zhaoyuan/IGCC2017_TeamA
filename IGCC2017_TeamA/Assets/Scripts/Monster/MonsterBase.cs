//************************************************/
//* @file  :MonsterBase.cs
//* @brief :モンスターに共通する処理
//* @brief :Process common to monsters
//* @date  :2017/09/06
//* @author:S.Katou
//************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterBase<T, TEnum> : MonoBehaviour
	where T : class where TEnum : System.IConvertible
{
	protected List<State<T>> stateList = new List<State<T>>();


	// ステートの管理用クラス
	// State management class
	protected StateMachine<T> stateMachine;

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
}
