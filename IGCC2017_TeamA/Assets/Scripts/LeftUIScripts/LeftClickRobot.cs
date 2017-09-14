using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//sorry
//bulldoze programming through

public class LeftClickRobot : MonoBehaviour
{
    //ゲットしたオブジェクト格納
    public GameObject _getObject = null;
    //clone draw position
    Vector2 clonePotision;
    public GameObject target;
    public GameObject statusClone;
    //情報取得
    //Get status
    public Robot_Status robot_status;
    public Robot_Status clone_status;
    //LeftClickMap.cs　と　相互関係
    //LeftMonster
    //                Mutual relationship
    public LeftClickMap baseUIcs;
    public LeftClickMonster monsterUIcs;

    public GameObject[] viewUI;


    private GameObject this_obj;

    string textDead;

    //PERSONALITY
    PERSONALITY personality_point;
    //MOOD
    PERSONALITY mood_point;
    //Icon
    ROBOT_ICON robotUIicon;
    //HP NE
    float hp_point;
    float energy_point;
    int uihp_point;
    int uienergy_point;
    int viewNum = 0;
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

    bool deadState;
    bool healState;

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
        DEF,
        HP,
        ENERGY
    }

    // Use this for initialization
    void Start()
    {
        //取得
        baseUIcs = GetComponent<LeftClickMap>();
        monsterUIcs = GetComponent<LeftClickMonster>();
        this_obj = GameObject.Find("StatusUI");


        clonePotision.x = -20.0f;
        clonePotision.y = 0.0f;

        textDead = "DEAD";
        deadState = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (baseUIcs.target!=null||monsterUIcs.target!=null)
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
                if (baseUIcs.target!=null)
                {
                    Destroy(baseUIcs.target);
                }
                else if (monsterUIcs.target!=null)
                {
                    Destroy(monsterUIcs.target);
                }
                //すでにRobotのUIが表示されていたら消す
                if (statusClone!= null)
                {
                    Destroy(target);
                    Destroy(statusClone);
                }

                _getObject = collition2d.transform.gameObject;
                //Make clone of robot clicked
                //クリックしたロボットのcloneを作る

                //ロボットの性格を読み取る
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

            if ((hp_point<=0||energy_point<=0))
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
            statusText[(int)STATUS.ATK].text = "ATK:" + atk_point.ToString();
            statusText[(int)STATUS.SPD].text = "SPD:" + spd_point.ToString();
            statusText[(int)STATUS.INT].text = "MAG:" + int_point.ToString();
            statusText[(int)STATUS.LUK].text = "LCK:" + luk_point.ToString();
            statusText[(int)STATUS.DEF].text = "DEF:" + def_point.ToString();
            statusText[(int)STATUS.HP].text ="HELTH" +uihp_point.ToString() + "/"+robot_status.GetBaseHealthPoint();
            statusText[(int)STATUS.ENERGY].text ="ENERGY"+ uienergy_point.ToString() + "/"+robot_status.GetBaseEnergyPoint();
        }

    }

}