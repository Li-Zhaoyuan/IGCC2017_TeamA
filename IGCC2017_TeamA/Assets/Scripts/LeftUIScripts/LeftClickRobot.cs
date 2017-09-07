using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftClickRobot : MonoBehaviour
{
    //ゲットしたオブジェクト格納
    public GameObject _getObject = null;
    //clone draw position
    Vector2 clonePotision;
    private GameObject target;


    // Use this for initialization
    void Start()
    {
        clonePotision.x = -11.0f;
        clonePotision.y = 4.0f;
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
            }
        }
    }
}