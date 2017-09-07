using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyBar : MovingBar {

  

    // Update is called once per frame
    public override void Update()
    {
        fill.transform.localScale = new Vector3(robot_status.GetEnergyPoint() / robot_status.GetBaseEnergyPoint(), fill.transform.localScale.y, fill.transform.localScale.z);
    }
}
