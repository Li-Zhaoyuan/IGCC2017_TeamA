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
    private GameObject target;
    //情報取得
    //Get status
    public Robot_Status robot_status;
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
        clonePotision.x = -11.0f;
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
        // 左クリックされた場所のオブジェクトを取得
        // Left Click
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collition2d = Physics2D.OverlapPoint(tapPoint);
            if (collition2d)
            {
                if(_getObject!=null)
                {
                    Destroy(target);
                    
                }
                _getObject = collition2d.transform.gameObject;
                //Make clone of robot clicked
                //クリックしたロボットのcloneを作る
                target = Instantiate(_getObject, new Vector2(clonePotision.x, clonePotision.y), Quaternion.identity);
                //scripts取得
                robot_status = _getObject.GetComponent<Robot_Status>();

                if(robot_status!=null)
                {

                    //Get Status Here
                    personality_point = robot_status.GetPersonality();
                    mood_point = robot_status.GetPersonality();
                    atk_point = robot_status.GetAttackPoint();
                    spd_point = robot_status.GetSpeedPoint();
                    int_point = robot_status.GetMagicPoint();
                    luk_point = robot_status.GetLuckPoint();
                    def_point = robot_status.GetDefencePoint();

                    //Text
                    statusText[(int)STATUS.PERSONALITY].text = "" + personality_point;
                  //  statusText[(int)STATUS.MOOD].text = "" + mood_point;
                    statusText[(int)STATUS.ATK].text = "ATK:" + atk_point.ToString();
                    statusText[(int)STATUS.SPD].text = "SPD:" + spd_point.ToString();
                    statusText[(int)STATUS.INT].text = "INT:" + int_point.ToString();
                    statusText[(int)STATUS.LUK].text = "LUK:" + luk_point.ToString();
                    statusText[(int)STATUS.DEF].text = "DEF:" + def_point.ToString();
                }
            }
        }
    }
}