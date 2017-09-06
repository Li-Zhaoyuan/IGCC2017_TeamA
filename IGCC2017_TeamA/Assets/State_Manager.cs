using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum STATES
{
    ROAM,
    ATTACK,
    DEAD,
    GATHER,
    HEAL,
    RETURN,
    ESCAPE,
    MOVETO,
    TOTAL,
}

public class State_Manager : MonoBehaviour {

    //public State roam_state;
    //public State attack_state;
    //public State dead_state;
    //public State gather_state;
    //public State heal_state;
    //public State return_state;
    //public State escape_state;
    //public State moveto_state;

    public State[] states;

    public State current_state;
    public STATES states_enum;

    // Use this for initialization
    void Start () {
        //SetCurrentState(roam_state);
        states_enum = STATES.MOVETO;
        SetCurrentState(states[(int)states_enum]);
        foreach(State state in states)
        {
            state.SetDisignatedArea(5, 5, 1);
            state.SetOwner(gameObject.transform.parent.gameObject);
        }
    }
	
	// Update is called once per frame
	void Update () {
		switch(states_enum)
        {
            case STATES.MOVETO:
            {
                    break;
            }
            
        }
	}

    public void SetCurrentState(State state)
    {
        if(current_state != null)
        {
            current_state.gameObject.SetActive(false);
        }
        current_state = state;
        current_state.gameObject.SetActive(true);
    }
}
