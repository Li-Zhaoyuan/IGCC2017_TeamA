using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftClickMap : MonoBehaviour {

    //ゲットしたオブジェクト格納
    public GameObject _getObject = null;
    //clone draw position
    Vector2 clonePotision;
    private GameObject target;


    // Use this for initialization
    void Start () {

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
            if (collition2d&& collition2d.gameObject.tag != "Robot")
            {
                Debug.Log("hit");
            }
        }

    }

}
