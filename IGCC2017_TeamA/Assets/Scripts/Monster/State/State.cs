//************************************************/
//* @file  :State.cs
//* @brief :状態
//* @brief :state
//* @date  :2017/09/06
//* @author:S.Katou
//************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State<T> {

	// このステートを利用するインスタンス
	// Instances that use this state
	protected T obj;

    public State(T obj)
    {
        this.obj = obj;
    }

	// このステートに遷移する時に一度だけ呼ばれる
	// Called only once when transitioning to this state
	public virtual void Enter() { }

	// このステートである間、毎フレーム呼ばれる
	// it is called every frame
	public virtual void Execute() { }

	// このステートから他のステートに遷移するときに一度だけ呼ばれる
	// Called only once when transitioning from this state to another state
	public virtual void Exit() { }
}
