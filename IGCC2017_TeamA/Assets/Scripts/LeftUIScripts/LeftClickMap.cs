using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftClickMap : MonoBehaviour
{

    //ゲットしたオブジェクト格納
    public GameObject _getObject = null;
    //clone draw position
    Vector2 clonePotision;
    public GameObject target;

    public GameObject viewUI;

    //LeftClickRobot.cs　と　相互関係
    //                Mutual relationship
    public LeftClickRobot robotUIcs;
    bool robotState;
    //state
    public bool _state;

    private GameObject this_obj;

    private void Awake()
    {
        clonePotision.x = -20.0f;
        clonePotision.y = 4.0f;
        //初回起動はHome画面にしておく。
        target = Instantiate(viewUI, new Vector2(clonePotision.x, clonePotision.y), Quaternion.identity);
    }
    // Use this for initialization
    void Start()
    {
        //取得
        robotUIcs = GetComponent<LeftClickRobot>();
        this_obj = GameObject.Find("LeftBaseUI");
        _state = true;

        //if _getObject null
        if (_getObject == null)
        {
            return;
        }

    }

    // Update is called once per frame
    void Update()
    {

        robotState = robotUIcs.GetState();
        //Object Active NoActive
        if (robotState == true)
        {
            this_obj.SetActive(false);
        }
        else
        {
            this_obj.SetActive(true);
        }

        // 左クリックされた場所のオブジェクトを取得
        // Left Click
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collition2d = Physics2D.OverlapPoint(tapPoint);
            if (collition2d && collition2d.gameObject.tag == "Base")
            {
                //robotUIStateがtrueだったらrobotUIを消す
                if (robotState == true)
                {
                    Destroy(robotUIcs.target);
                    robotUIcs._state = false;
                }

                //すでにRobotのUIが表示されていたら消す
                if (_getObject != null)
                {
                    Destroy(target);
                    _state = false;

                }

                _getObject = collition2d.transform.gameObject;
                //Make clone of robot clicked
                //クリックしたロボットのcloneを作る
                target = Instantiate(viewUI, new Vector2(clonePotision.x, clonePotision.y), Quaternion.identity);

                _state = true;
            }
        }
    }
    //9/11進捗
    //ロボットのUIはほとんどおわり。修正案まち
    //BaseUIの進行をスタート

    public bool GetState()
    {
        return _state;
    }
}