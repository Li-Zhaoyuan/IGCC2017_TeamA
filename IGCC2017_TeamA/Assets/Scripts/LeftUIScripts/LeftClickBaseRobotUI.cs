using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftClickBaseRobotUI : MonoBehaviour {

    //ゲットしたオブジェクト格納
    public GameObject _getObject = null;
    public GameObject target;
    public GameObject statusClone;

    Vector2 clonePotision;
    public Robot_Status robot_status;
    public Robot_Status clone_status;

    public GameObject[] viewUI;
    public GameObject viewArea;

    //PERSONALITY
    PERSONALITY personality_point;
    //MOOD
    PERSONALITY mood_point;

    string textDead;
    public Text[] statusText;
    bool deadState;

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

    float hp_point;
    float energy_point;
    int uihp_point;
    int uienergy_point;
    int viewNum = 0;

    enum STATUS
    {
        PERSONALITY,
        MOOD,
        ATK,
        SPD,
        INT,
        LUK,
        DEF,
        HP,
        ENERGY
    }
    // Use this for initialization
    void Start () {
        clonePotision.x = -20.0f;
        clonePotision.y = 0.0f;
        deadState = false;
        viewArea = GameObject.Find("UIArea");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collition2d = Physics2D.OverlapPoint(tapPoint);
            if (collition2d && collition2d.gameObject.tag == "Robot")
            {
                if (statusClone != null)
                {
                    Destroy(target);
                    Destroy(statusClone);
                }
                _getObject = collition2d.transform.gameObject;
                statusClone = Instantiate(_getObject, new Vector2(-40.0f, clonePotision.y), Quaternion.identity);
                statusClone.gameObject.tag = "clone";
                robot_status = _getObject.GetComponent<Robot_Status>();

                if (!deadState)
                {
                    viewNum = (int)robot_status.GetMood();
                }
                else
                {
                    viewNum = 6;
                }
                target = Instantiate(viewUI[viewNum], new Vector2(clonePotision.x, clonePotision.y), Quaternion.identity);
            }
        }
        //scripts取得
        //HP Energyリアルタイム更新
        //cloneのスピード0
        if (_getObject != null)
        {
            robot_status = _getObject.GetComponent<Robot_Status>();

            if (statusClone != null)
            {
                clone_status = statusClone.GetComponent<Robot_Status>();
                //target
                clone_status.speed_point = 0.0f;
                //hp energy test
                clone_status.SetHealthPoint(robot_status.GetHealthPoint());
                clone_status.SetEnergyPoint(robot_status.GetEnergyPoint());
            }
        }
        //ステータスリアルタイム更新
        if (robot_status != null)
        {
            //Get Status Here
            hp_point = robot_status.GetHealthPoint();
            energy_point = robot_status.GetEnergyPoint();
            personality_point = robot_status.GetPersonality();
            mood_point = robot_status.GetMood();
            atk_point = robot_status.GetAttackPoint();
            spd_point = robot_status.GetSpeedPoint();
            int_point = robot_status.GetMagicPoint();
            luk_point = robot_status.GetLuckPoint();
            def_point = robot_status.GetDefencePoint();

            uihp_point = (int)hp_point;
            uienergy_point = (int)robot_status.GetEnergyPoint();

            if ((hp_point <= 0 || energy_point <= 0))
            {
                textDead = "DEAD";
                viewNum = 6;
                deadState = true;
            }
            else
            {
                textDead = personality_point.ToString();
                deadState = false;
            }
            Debug.Log(viewNum);
            //Text
            statusText[(int)STATUS.PERSONALITY].text = ":" + textDead;
            statusText[(int)STATUS.MOOD].text = ":" + mood_point;
            statusText[(int)STATUS.ATK].text = "ATK: " + atk_point.ToString();
            statusText[(int)STATUS.SPD].text = "SPD: " + spd_point.ToString();
            statusText[(int)STATUS.INT].text = "MAG: " + int_point.ToString();
            statusText[(int)STATUS.LUK].text = "LCK: " + luk_point.ToString();
            statusText[(int)STATUS.DEF].text = "DEF: " + def_point.ToString();
            statusText[(int)STATUS.HP].text = "HP: " + uihp_point.ToString();
            statusText[(int)STATUS.ENERGY].text = "ENE: " + uienergy_point.ToString();
        }
    }
}
