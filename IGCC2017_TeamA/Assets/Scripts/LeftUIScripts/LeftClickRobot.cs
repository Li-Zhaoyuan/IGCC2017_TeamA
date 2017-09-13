using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftClickRobot : MonoBehaviour
{
    //ゲットしたオブジェクト格納
    public GameObject _getObject = null;
    //clone draw position
    Vector2 clonePotision;
    public GameObject target;
    //情報取得
    //Get status
    public Robot_Status robot_status;
    public Robot_Status target_status;
    //LeftClickMap.cs　と　相互関係
    //                Mutual relationship
    public LeftClickMap baseUIcs;
    bool baseState;
    //state
    public bool _state;

    private GameObject this_obj;

    //PERSONALITY
    PERSONALITY personality_point;
    //MOOD
    PERSONALITY mood_point;
    //ATK
    float atk_point;
    //SPD
    float spd_point;
    //INT
    float int_point;
    //LUK
    float luk_point;
    //DEF
    float def_point;

    //draw status Text
    public Text[] statusText;
    enum STATUS
    {
        PERSONALITY,
        MOOD,
        ATK,
        SPD,
        INT,
        LUK,
        DEF
    }

    // Use this for initialization
    void Start()
    {
        //取得
        baseUIcs = GetComponent<LeftClickMap>();
        this_obj = GameObject.Find("StatusUI");


        clonePotision.x = -20.0f;
        clonePotision.y = 4.0f;
        
        //if _getObject null
        if (_getObject == null)
        {
            return;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //scripts取得
        //HP Energyリアルタイム更新
        //cloneのスピード0
        if (_getObject != null)
        {
            robot_status = _getObject.GetComponent<Robot_Status>();
            target_status = target.GetComponent<Robot_Status>();
            //target
            target_status.speed_point = 0.0f;
            //hp energy test
            target_status.SetHealthPoint(robot_status.GetHealthPoint());
            target_status.SetEnergyPoint(robot_status.GetEnergyPoint());
        }
        //Status取得
        baseState = baseUIcs.GetState();
        //Object Active NoActive
        if (baseState == true)
        {
            this_obj.SetActive(false);
        }
        else
        {
            this_obj.SetActive(true);
        }

        //左クリックした奴を顔を拡大して出す。
        // 左クリックされた場所のオブジェクトを取得
        // Left Click
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collition2d = Physics2D.OverlapPoint(tapPoint);
            if (collition2d && collition2d.gameObject.tag == "Robot")
            {
                //BaseUIStateがtrueだったらBaseUIを消す
                if (baseState == true)
                {
                    Destroy(baseUIcs.target);
                    baseUIcs._state = false;
                }

                //すでにRobotのUIが表示されていたら消す
                if (_getObject!=null)
                {
                    Destroy(target);
                    _state = false;
                }

                _getObject = collition2d.transform.gameObject;
                //Make clone of robot clicked
                //クリックしたロボットのcloneを作る
                target = Instantiate(_getObject, new Vector2(clonePotision.x, clonePotision.y), Quaternion.identity);

               // target.GetComponentInChildren<State_Manager>().enabled = false;
                if (robot_status != null)
                {
                    _state = true;
                }
            }
        }
        //ステータスリアルタイム更新
        if (robot_status != null)
        {

            //Get Status Here
            personality_point = robot_status.GetPersonality();
            mood_point = robot_status.GetMood();
            atk_point = robot_status.GetAttackPoint();
            spd_point = robot_status.GetSpeedPoint();
            int_point = robot_status.GetMagicPoint();
            luk_point = robot_status.GetLuckPoint();
            def_point = robot_status.GetDefencePoint();

            //Text
            statusText[(int)STATUS.PERSONALITY].text = "" + personality_point;
            statusText[(int)STATUS.MOOD].text = "" + mood_point;
            statusText[(int)STATUS.ATK].text = "ATK:" + atk_point.ToString();
            statusText[(int)STATUS.SPD].text = "SPD:" + spd_point.ToString();
            statusText[(int)STATUS.INT].text = "INT:" + int_point.ToString();
            statusText[(int)STATUS.LUK].text = "LUK:" + luk_point.ToString();
            statusText[(int)STATUS.DEF].text = "DEF:" + def_point.ToString();
        }
    }
    public bool GetState()
    {
        return _state;
    }


    //HPをカメラで追従する
}