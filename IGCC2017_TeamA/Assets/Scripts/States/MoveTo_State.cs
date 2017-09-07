using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTo_State : State {

    // Use this for initialization
    public override void Start()
    {

    }

    // Update is called once per frame
    public override void Update()
    {
        //TODO: move to the disignated area
        if(disignated_area != null)
        {
            Vector2 temp = (disignated_area - owner.transform.position).normalized;
            owner.GetComponent<Rigidbody2D>().velocity = new Vector2(temp.x,temp.y);
        }
    }
}
