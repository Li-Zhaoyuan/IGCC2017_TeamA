using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ROBOT_STATES
{
    ROAM,
    ATTACK,
    DEAD,
    GATHER,
    HEAL,
    RETURN,
    ESCAPE,
    MOVETO,
    RESCUE,
    OUTOFENERGY,
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

    //State stuff
    public Robot_BaseState[] states;
    public Robot_BaseState current_state;
    public ROBOT_STATES states_enum;

    //Assigned position to go towards
    public Vector3 disignated_position;

    //the Main robot body
    public GameObject parent_object;

    //size of the sprite.
    public Vector2 robot_sprite_size;
    public Vector2 robot_local_sprite_size;
    public float robot_sprite_across_length;
    public Sprite robot_sprite;


    public TempScripts[] waypoints;
    public Vector3 mainWaypoint;

    // Use this for initialization
    void Start () {
        //SetCurrentState(roam_state);
        parent_object = transform.parent.gameObject;
        states_enum = ROBOT_STATES.MOVETO;
        SetCurrentState(states[(int)states_enum]);
        disignated_position = new Vector3(Random.Range(-4,5), Random.Range(-4, 5), 1);

        //get the sprite size
        robot_sprite = parent_object.GetComponent<SpriteRenderer>().sprite;
        robot_sprite_size = robot_sprite.rect.size;
        robot_local_sprite_size = robot_sprite_size / robot_sprite.pixelsPerUnit;
        robot_sprite_across_length = Mathf.Sqrt(robot_local_sprite_size.x * robot_local_sprite_size.x + robot_local_sprite_size.y * robot_local_sprite_size.y);


        waypoints = FindObjectsOfType<TempScripts>();
        mainWaypoint = Vector3.zero;
        if(waypoints.Length > 0)
            mainWaypoint = waypoints[Random.Range(0, waypoints.Length)].transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        current_state.gameObject.SetActive(true);
        //current_state.Execute();
        StateTransitions();

    }
    public void StateTransitions()
    {
        switch (states_enum)
        {
            case ROBOT_STATES.ROAM:
                {
                    if (ChangeStateToDead()) return;
                    if (ChangeStateToOutOfEnergy()) return;
                    break;
                }
            case ROBOT_STATES.ATTACK:
                {
                    if (ChangeStateToDead()) return;
                    if (ChangeStateToOutOfEnergy()) return;
                    break;
                }
            case ROBOT_STATES.DEAD:
                {
                    break;
                }
            case ROBOT_STATES.GATHER:
                {
                    if (ChangeStateToDead()) return;
                    if (ChangeStateToOutOfEnergy()) return;
                    break;
                }
            case ROBOT_STATES.HEAL:
                {
                    if (ChangeStateToDead()) return;
                    if (ChangeStateToOutOfEnergy()) return;
                    break;
                }
            case ROBOT_STATES.RETURN:
                {
                    if (ChangeStateToDead()) return;
                    if (ChangeStateToOutOfEnergy()) return;
                    break;
                }
            case ROBOT_STATES.ESCAPE:
                {
                    if (ChangeStateToDead()) return;
                    if (ChangeStateToOutOfEnergy()) return;
                    break;
                }
            case ROBOT_STATES.MOVETO:
                {
                    if (ChangeStateToDead()) return;
                    if (ChangeStateToOutOfEnergy()) return;
                    ChangeStateFromMoveToRoam();
                    
                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    public void ChangeStateFromMoveToRoam()
    {
        if (UsefulFunctions.GetDistanceOfTwoPoints(parent_object.transform.position, mainWaypoint) < robot_local_sprite_size.x * 0.5f)
        {
            states_enum = ROBOT_STATES.ROAM;
            SetCurrentState(states[(int)states_enum]);
        }
    } 

    public bool ChangeStateToDead()
    {
        if(parent_object.GetComponent<Robot_Status>().health_point <= 0)
        {
            states_enum = ROBOT_STATES.DEAD;
            SetCurrentState(states[(int)states_enum]);
            return true;
        }
        return false;
    }

    public bool ChangeStateToOutOfEnergy()
    {
        if (parent_object.GetComponent<Robot_Status>().energy_point <= 0)
        {
            states_enum = ROBOT_STATES.OUTOFENERGY;
            SetCurrentState(states[(int)states_enum]);
            return true;
        }
        return false;
    }

    //setter
    public void SetCurrentState(Robot_BaseState state)
    {
        parent_object.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        if (current_state != null)
        {
            current_state.gameObject.SetActive(false);
        }
        current_state = state;
        current_state.gameObject.SetActive(true);
    }

    //Getter
    public GameObject GetParentObject()
    {
        return parent_object;
    }

    public Vector3 GetDisignatedPosition()
    {
        return disignated_position;
    }
}
