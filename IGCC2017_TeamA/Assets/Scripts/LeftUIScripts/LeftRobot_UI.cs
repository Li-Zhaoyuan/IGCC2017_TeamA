using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //UIImage

public class LeftRobot_UI : MonoBehaviour {

    //RobotImage
    Image robotUI;
    //GameObject
    GameObject gameObj;
    //参照Scripts
    LeftClickRobot robotInfo;

    // Use this for initialization
    void Start () {
       robotUI = GetComponent<Image>();
       robotInfo = GetComponent<LeftClickRobot>();
       
    }

    // Update is called once per frame
    void Update () {
        
    }
}
