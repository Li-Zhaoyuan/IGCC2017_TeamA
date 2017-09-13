//************************************************/
//* @file  :Timer.cs
//* @brief :時間の計測と描画
//* @brief :Time measurement and drawing
//* @date  :2017/09/12
//* @author:S.Katou
//************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
	//制限時間
	[SerializeField]
	private float m_timeLimit;

    //時間描画用
	[SerializeField]
    private Text m_text;

	[SerializeField]
	private ChangeScene m_changeScene;

    // 経過時間
    private float m_elapsedTime = 0.0f;

	//計測を止めるかどうか
	private bool m_isStop = false;

    void Start()
    {
        m_elapsedTime = 0.0f;
    }


    // 更新処理
    void Update()
    {
		//時間の計測
        if (!(m_isStop))
        {
            m_elapsedTime += Time.deltaTime;
        }

		//設定した時間が過ぎたら計測を止める
		if (m_elapsedTime > m_timeLimit)
		{
			m_elapsedTime = m_timeLimit;
			StopCount();
			m_changeScene.LoadMenu();
		}

		//時間描画
		m_text.text = ConvertStringTime(m_timeLimit - m_elapsedTime);
	}


	public void StopCount()
	{
		m_isStop = true;
	}

	public void StartCount()
	{
		m_isStop = false;
	}

	/// <summary>
	/// 経過時間を取得
	/// </summary>
	/// <returns>経過時間</returns>
	public float GetTime()
    {
        return m_elapsedTime;
    }

	public float GetRemainingTime()
	{
		return m_timeLimit - m_elapsedTime;
	}

	/// <summary>
	/// タイムを文字列に変換して返す
	/// </summary>
	static public string ConvertStringTime(float time)
    {
        //分・秒・ミリ秒
        int minute = (int)time / 60;
        int second = (int)time % 60;

        return (minute.ToString().PadLeft(2, '0') + ":" + second.ToString().PadLeft(2, '0'));
    }
}
