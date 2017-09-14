using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//sorry
//bulldoze programming through

public class LeftClickMonster : MonoBehaviour
{

    //ゲットしたオブジェクト格納
    public GameObject _getObject = null;
    public GameObject target;
    public GameObject statusClone;
    public GameObject viewArea;
    //Monster
    public MonsterStats monster_status;
    public MonsterStats clone_status;
    public LeftClickMap baseUIcs;
    public LeftClickRobot robotUIcs;
    //表示画像　//普通にクローンすればアニメーションのままクローンする
    //専用アニメーション作ればそれ通りに動く
   // public GameObject[] viewUI;
    //objectの名前取得用
    private string objectName;
    private int MonsterNumber;

    Vector2 clonePotision;

    //ATK
    int atk_point;
    //SPD
    int spd_point;
    //INT
    int int_point;
    //DEF
    int def_point;
    //hp
    int hp_point;

    public GameObject[] viewUI;
    public Text[] statusText;
    private GameObject this_obj;
    enum STATUS
    {
        ATK,
        SPD,
        INT,
        DEF,
        HP
    }
    enum MONSTER
    {
        WASP,
        CITYROBOT,
        TURTLE,
        DESERT
    }

    // Use this for initialization
    void Start()
    {
        //取得
        baseUIcs = GetComponent<LeftClickMap>();
        robotUIcs = GetComponent<LeftClickRobot>();
        this_obj = GameObject.Find("MonsterUI");
        viewArea = GameObject.Find("UIArea");

        clonePotision.x = -20.0f;
        clonePotision.y = 0.0f;
        //
       MonsterNumber = 99;
    }

    // Update is called once per frame
    void Update()
    {


        if(baseUIcs.target!=null||robotUIcs.target!=null)
        {
            this_obj.SetActive(false);
        }
        else
        {
            this_obj.SetActive(true);
        }


        //MonsterNumber取得
        //CheckMonsterNumber();


        if (Input.GetMouseButtonDown(0))
        {
            Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D collition2d = Physics2D.OverlapPoint(tapPoint);
            if (collition2d && collition2d.gameObject.tag == "Monster")
            {
                
                //Name取得 MAPmonsterとは別用
                //objectName = collition2d.gameObject.name;

                if (baseUIcs.target!=null)
                {
                    Destroy(baseUIcs.target);
                }
               else if(robotUIcs.target!=null)
                {
                    Destroy(robotUIcs.target);
                }

                //すでにRobotのUIが表示されていたら消す
                if (target != null)
                {
                    Destroy(target);
                    Destroy(statusClone);
                    target = null;
                    _getObject = null;
                    statusClone = null;
                }

                _getObject = collition2d.transform.gameObject;
                //クリックしたロボットのcloneを作る
                objectName = collition2d.transform.name;
                if(objectName== "ChaseBeachTurtle(Clone)"||objectName== "ImmovableBeachTurtle(Clone)" || objectName== "RoamBeachTurtle(Clone)")
                {
                    MonsterNumber = (int)MONSTER.TURTLE;
                }
                else if(objectName== "ChaseCityRobot(Clone)" || objectName== "ImmovableCityRobot(Clone)" || objectName== "RoamCityRobot(Clone)")
                {
                    MonsterNumber = (int)MONSTER.CITYROBOT;
                }
                else if(objectName== "ChaseDeserthedge(Clone)" || objectName== "ImmovableDeserthedge(Clone)" || objectName== "RoamDeserthedge(Clone)")
                {
                    MonsterNumber = (int)MONSTER.DESERT;
                }
                else
                {
                    MonsterNumber = (int)MONSTER.WASP;
                }

                statusClone = Instantiate(_getObject, new Vector2(-10.0f, clonePotision.y), Quaternion.identity);
                monster_status = _getObject.GetComponent<MonsterStats>();
                target =Instantiate(viewUI[MonsterNumber], new Vector2(clonePotision.x, clonePotision.y), Quaternion.identity);

            }
        }
        if (_getObject != null)
        {
            monster_status = _getObject.GetComponent<MonsterStats>();
            if (target != null)
            {
                clone_status = statusClone.GetComponent<MonsterStats>();
                clone_status.m_chargeArea = viewArea;
                //target
                clone_status.SPD = 0.0f;
                //hp energy test
                
                hp_point = (int)monster_status.HP;
                clone_status.HP = hp_point; //monster_status.HP;
            }
        }
        //ステータスリアルタイム更新
        if (monster_status != null)
        {
            atk_point = (int)monster_status.ATK;
            spd_point = (int)monster_status.SPD;
            int_point = (int)monster_status.MAG;
            def_point = (int)monster_status.DEF;
            statusText[(int)STATUS.ATK].text = "ATK:" + atk_point.ToString();
            statusText[(int)STATUS.SPD].text = "SPD:" + spd_point.ToString();
            statusText[(int)STATUS.INT].text = "MAG:" + int_point.ToString();
            statusText[(int)STATUS.DEF].text = "DEF:" + def_point.ToString();
            statusText[(int)STATUS.HP].text = " HELTH  " + hp_point.ToString() +"/"+ (int)monster_status.MAX_HP;
            //_state = true;
        }
    }
}