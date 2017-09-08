//************************************************/
//* @file  :Timer.cs
//* @brief :時間の計測と描画
//* @brief :Time measurement and drawing
//* @date  :2017/09/08
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

    // 経過時間
    private float m_elapsedTime = 0.0f;

	//計測を止めるかどうか
	private bool m_isStoped = false;

    void Start()
    {
        //m_text = GetComponent<Text>();
        m_elapsedTime = 0.0f;
    }


    // 更新処理
    void Update()
    {

        //プレイヤーが生きていてゴールしていない間カウントする
        if (!(m_isStoped))
        {
            m_elapsedTime += Time.deltaTime;
        }

		//時間描画
		m_text.text = ConvertStringTime(m_timeLimit - m_elapsedTime);
	}

	/// <summary>
	/// 経過時間を取得
	/// </summary>
	/// <returns>経過時間</returns>
	public float GetTime()
    {
        return m_elapsedTime;
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
