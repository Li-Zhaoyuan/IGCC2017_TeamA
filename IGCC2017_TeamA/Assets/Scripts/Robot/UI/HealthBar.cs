﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MovingBar
{

    // Update is called once per frame
    public override void Update()
    {
        fill.transform.localScale = new Vector3(robot_status.GetHealthPoint() / robot_status.GetBaseHealthPoint(), fill.transform.localScale.y, fill.transform.localScale.z);
    }
}
