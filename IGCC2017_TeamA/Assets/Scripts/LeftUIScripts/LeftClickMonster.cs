using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeftClickMonster : MonoBehaviour
{

    //ゲットしたオブジェクト格納
    public GameObject _getObject = null;
    public GameObject target;
    //Monster
    public MonsterStats monster_status;
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
    float atk_point;
    //SPD
    float spd_point;
    //INT
    float int_point;
    //DEF
    float def_point;
    public Text[] statusText;
    private GameObject this_obj;
    enum STATUS
    {
        ATK,
        SPD,
        INT,
        DEF
    }

    // Use this for initialization
    void Start()
    {
        //取得
        baseUIcs = GetComponent<LeftClickMap>();
        robotUIcs = GetComponent<LeftClickRobot>();
        this_obj = GameObject.Find("MonsterUI");

        clonePotision.x = -20.0f;
        clonePotision.y = 4.0f;
        //
       //MonsterNumber = 99;
    }

    // Update is called once per frame
    void Update()
    {

        /*
        if (baseState==true || robotState==true)
        {
            this_obj.SetActive(false);
        }
        else if ((baseState==true && robotState==false) || (baseState==false&& robotState==true))
        {
            this_obj.SetActive(false);
        }
        else
        {
            this_obj.SetActive(true);
        }
        */
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

        //scripts取得
        //HP Energyリアルタイム更新
        //cloneのスピード0
        if (_getObject != null)
        {
            monster_status = _getObject.GetComponent<MonsterStats>();
        }

        //ステータスリアルタイム更新
        if (monster_status != null)
        {
            atk_point = monster_status.ATK;
            spd_point = monster_status.SPD;
            int_point = monster_status.MAG;
            def_point = monster_status.DEF;
            statusText[(int)STATUS.ATK].text = "ATK:" + atk_point.ToString();
            statusText[(int)STATUS.SPD].text = "SPD:" + spd_point.ToString();
            statusText[(int)STATUS.INT].text = "INT:" + int_point.ToString();
            statusText[(int)STATUS.DEF].text = "DEF:" + def_point.ToString();
            //_state = true;
        }


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
                if (_getObject != null)
                {
                    Destroy(target);
                }
                _getObject = collition2d.transform.gameObject;
                //クリックしたロボットのcloneを作る
                target = Instantiate(_getObject, new Vector2(clonePotision.x, clonePotision.y), Quaternion.identity);
            }
        }
    }
    /*
    void CheckMonsterNumber()
    {
        //名前とUIを照らし合わせる
        if (objectName == "ChaseMonster")
        {
            MonsterNumber = 0;
        }
        else if (objectName == "ImmovableMonster")
        {
            MonsterNumber = 1;
        }
        else if (objectName == "RoamMonster")
        {
            MonsterNumber = 2;
        }
    }
    */
}