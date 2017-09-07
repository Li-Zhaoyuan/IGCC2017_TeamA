//************************************************/
//* @file  :StateMachine.cs
//* @brief :状態を管理する
//* @brief :Manage state
//* @date  :2017/09/06
//* @author:S.Katou
//************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StateMachine<T>
{
	// 実行中のステート
	// Running State
	private State<T> m_currentState;

    public StateMachine()
    {
        m_currentState = null;
    }

    public State<T> CurrentState
    {
        get { return m_currentState; }
    }


    // ステートの切り替え
	// Change State
    public void ChangeState(State<T> state)
    {
		// 終了処理
		// Finalize
		if (m_currentState != null)
        {
            m_currentState.Exit();
        }

		// ステート切替
		// Change State
		m_currentState = state;

		// 開始処理
		// Initialize
		m_currentState.Enter();
    }

    // ステートの実行
	// Update State
    public void Update()
    {
        if (m_currentState != null)
        {
            m_currentState.Execute();
        }
    }
}