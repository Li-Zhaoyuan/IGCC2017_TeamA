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
    public SpriteRenderer robot_sprite_renderer;


    //public TempScripts[] waypoints;
    //public Vector3 mainWaypoint;

    // the time interval for the robots to make a decision
    public float decision_timer  = 0f;

    //attack state
    public GameObject enemy_target = null;
    public GameObject ally_target = null;
    public GameObject item_target = null;

    public GameObject home_base = null;
    Vector3 home_base_pos;

    BoxCollider2D max_bounds;

    // Use this for initialization
    void Start () {
        //SetCurrentState(roam_state);
        parent_object = transform.parent.gameObject;
        states_enum = ROBOT_STATES.ROAM;
        SetCurrentState(states[(int)states_enum]);
        disignated_position = new Vector3(Random.Range(-4,5), Random.Range(-4, 5), 1);

        //get the sprite size
        robot_sprite_renderer = parent_object.GetComponent<SpriteRenderer>();
        robot_sprite = robot_sprite_renderer.sprite;
        robot_sprite_size = robot_sprite.rect.size;
        robot_local_sprite_size = robot_sprite_size / robot_sprite.pixelsPerUnit;
        robot_sprite_across_length = Mathf.Sqrt(robot_local_sprite_size.x * robot_local_sprite_size.x + robot_local_sprite_size.y * robot_local_sprite_size.y);

        //parent_object.GetComponent<SpriteRenderer>().ma
        //waypoints = FindObjectsOfType<TempScripts>();
        //mainWaypoint = Vector3.zero;

        //max_bounds = GameObject.FindGameObjectWithTag("Robot_MaxArea").GetComponent<BoxCollider2D>();
        max_bounds = UsefulFunctions.GetNearbyRobotMaxAreaWithBoxCollider(parent_object.transform.position, robot_local_sprite_size).GetComponent<BoxCollider2D>();
        //get the home base that is in the game scene
        home_base = GameObject.FindGameObjectWithTag("Base");
    }

	// Update is called once per frame
	void Update () {
        current_state.gameObject.SetActive(true);// just to make sure the main state is active
        //current_state.Execute();
        StateTransitions();
        if(max_bounds == null)
        {
            max_bounds = UsefulFunctions.GetNearbyRobotMaxAreaWithBoxCollider(parent_object.transform.position, robot_local_sprite_size).GetComponent<BoxCollider2D>();
        }
        else
        {
            Vector3 current_pos = parent_object.transform.position;
            Vector3 area_pos = max_bounds.transform.position;

            current_pos.x = Mathf.Clamp(current_pos.x, area_pos.x - max_bounds.bounds.size.x / 2, area_pos.x + max_bounds.bounds.size.x / 2);
            current_pos.y = Mathf.Clamp(current_pos.y, area_pos.y - max_bounds.bounds.size.y / 2, area_pos.y + max_bounds.bounds.size.y / 2);

            parent_object.transform.position = current_pos;
        }
    }

    public void ChangeSpriteOnMood(Sprite sprite)
    {
        robot_sprite_renderer.sprite = sprite;

        robot_sprite = robot_sprite_renderer.sprite;
        robot_sprite_size = robot_sprite.rect.size;
        robot_local_sprite_size = robot_sprite_size / robot_sprite.pixelsPerUnit;
        robot_sprite_across_length = Mathf.Sqrt(robot_local_sprite_size.x * robot_local_sprite_size.x + robot_local_sprite_size.y * robot_local_sprite_size.y);

    }

    public void StateTransitions()
    {
        if(states_enum != ROBOT_STATES.DEAD)
            if (ChangeStateToDead()) return;
        else if (states_enum != ROBOT_STATES.OUTOFENERGY)
            if (ChangeStateToOutOfEnergy()) return;
        decision_timer += Time.deltaTime;
        switch (states_enum)
        {
            case ROBOT_STATES.ROAM:
                {
                    if (decision_timer > 1f)
                    {
                        decision_timer = 0f;
                        
                        if (ChangeStateToEscape()) break;
                        if (ChangeStateToRescue()) break;
                        if (ChangeStateToAttack()) break;
                        
                        if (ChangeStateToHeal()) break;
                        if (ChangeStateToGather()) break;
                        if (ChangeStateToReturn()) break;
                    }
                    break;
                }
            case ROBOT_STATES.ATTACK:
                {
                    if (ChangeStateToEscape()) break;
                    ChangeStateToRoamIfDone();
                    break;
                }
            case ROBOT_STATES.DEAD:
                {
                    ChangeStateToRoamIfDone();
                    break;
                }
            case ROBOT_STATES.GATHER:
                {
                    ChangeStateToRoamIfDone();
                    break;
                }
            case ROBOT_STATES.HEAL:
                {
                    ChangeStateToRoamIfDone();
                    break;
                }
            case ROBOT_STATES.RETURN:
                {
                    if (decision_timer > 1f && (UsefulFunctions.GetPercentageInFloat(parent_object.GetComponent<Robot_Status>().GetEnergyPoint(), parent_object.GetComponent<Robot_Status>().GetBaseEnergyPoint()) > 0.5f && UsefulFunctions.GetPercentageInFloat(parent_object.GetComponent<Robot_Status>().GetHealthPoint(), parent_object.GetComponent<Robot_Status>().GetBaseHealthPoint()) > 0.5f))
                    {
                        decision_timer = 0f;
                        //if (ChangeStateToReturn()) break;
                        if (ChangeStateToEscape()) break;
                        if (ChangeStateToRescue()) break;
                        if (ChangeStateToAttack()) break;

                        if (ChangeStateToHeal()) break;
                        if (ChangeStateToGather()) break;
                        if (ChangeStateToReturn()) break;

                    }
                    ChangeStateToRoamIfDone();
                    break;
                }
            case ROBOT_STATES.ESCAPE:
                {
                    ChangeStateToRoamIfDone();
                    break;
                }
            case ROBOT_STATES.MOVETO:
                {

                    ChangeStateFromMoveToRoam();

                    break;
                }
            case ROBOT_STATES.RESCUE:
                {

                    ChangeStateToRoamIfDone();

                    break;
                }
            case ROBOT_STATES.OUTOFENERGY:
                {

                    ChangeStateToRoamIfDone();

                    break;
                }
            default:
                {
                    break;
                }
        }
    }

    public bool ChangeStateFromMoveToRoam()
    {
       
        if (UsefulFunctions.GetDistanceOfTwoPoints((Vector2)parent_object.transform.position, (Vector2)disignated_position) < robot_local_sprite_size.x )
        {
            SetCurrentState(ROBOT_STATES.ROAM);
            return true;
        }
        return false;
    }

    public bool ChangeStateToRoamIfDone()
    {
        if (current_state.GetIsDone())
        {
            current_state.ToggleIsDone();
            SetCurrentState(ROBOT_STATES.ROAM);
            return true;
        }
        return false;
    }

    public bool ChangeStateToReturn()
    {
        if (home_base != null)
        {
            if (UsefulFunctions.GetPercentageInFloat(parent_object.GetComponent<Robot_Status>().GetEnergyPoint(), parent_object.GetComponent<Robot_Status>().GetBaseEnergyPoint()) < 0.2f
                || (UsefulFunctions.GetPercentageInFloat(parent_object.GetComponent<Robot_Status>().GetEnergyPoint(), parent_object.GetComponent<Robot_Status>().GetBaseEnergyPoint()) < 1f && UsefulFunctions.GetDistanceOfTwoPoints((Vector2)parent_object.transform.position, (Vector2)home_base.transform.position) < robot_local_sprite_size.x *1.5f))
            {
                SetCurrentState(ROBOT_STATES.RETURN);
                return true;
            }
        }
        return false;
    }

    public bool ChangeStateToDead()
    {
        if(parent_object.GetComponent<Robot_Status>().health_point <= 0)
        {
            SetCurrentState(ROBOT_STATES.DEAD);
            return true;
        }
        return false;
    }

    public bool ChangeStateToOutOfEnergy()
    {
        if (parent_object.GetComponent<Robot_Status>().energy_point <= 0)
        {
            SetCurrentState(ROBOT_STATES.OUTOFENERGY);
            return true;
        }
        return false;
    }

    public bool ChangeStateToAttack()
    {
        enemy_target = UsefulFunctions.GetNearbyEnemyWithBoxCollider(parent_object.transform.position, robot_local_sprite_size * 2);
        if(enemy_target != null && Random.Range(1,101) < parent_object.GetComponent<Robot_Status>().GetChanceToAttack())
        {
            SetCurrentState(ROBOT_STATES.ATTACK);
            return true;
        }
        return false;
    }

    public bool ChangeStateToRescue()
    {
        State_Manager temptarget = null;
        foreach(GameObject go in UsefulFunctions.GetNearbyRobotWithBoxColliderArray(parent_object.transform.position, robot_local_sprite_size * 4))
        {
            temptarget = go.GetComponent<Robot_Status>().GetStateManager();
            if (temptarget == null)
            {
                ally_target = null;
            }
            else
            {
                if (temptarget.GetRobotCurrentState() == ROBOT_STATES.DEAD || temptarget.GetRobotCurrentState() == ROBOT_STATES.OUTOFENERGY)
                {
                    ally_target = go;
                    break;
                }
                else
                {
                    ally_target = null;
                }
            }
        }
        if(ally_target != null && Random.Range(1, 101) < parent_object.GetComponent<Robot_Status>().GetChanceToRescue())
        {
            SetCurrentState(ROBOT_STATES.RESCUE);
            return true;
        }
        return false;
    }

    public bool ChangeStateToHeal()
    {
        Robot_Status temptarget = null;
        foreach (GameObject go in UsefulFunctions.GetNearbyRobotWithBoxColliderArray(parent_object.transform.position, robot_local_sprite_size * 4))
        {
            if (go != parent_object)
            {
                temptarget = go.GetComponent<Robot_Status>();
                if (temptarget.GetHealthPoint() < temptarget.GetBaseHealthPoint() && (temptarget.state_manager.states_enum != ROBOT_STATES.DEAD && temptarget.state_manager.states_enum != ROBOT_STATES.OUTOFENERGY))
                {
                    ally_target = go;
                    break;
                }
                else
                {
                    ally_target = null;
                }
            }
        }
        if (ally_target != null && Random.Range(1, 101) < parent_object.GetComponent<Robot_Status>().GetChanceToHeal())
        {
            SetCurrentState(ROBOT_STATES.HEAL);
            return true;
        }
        return false;
    }

    public bool ChangeStateToEscape()
    {
        enemy_target = UsefulFunctions.GetNearbyEnemyWithBoxCollider(parent_object.transform.position, robot_local_sprite_size * 2);
        if (enemy_target != null && UsefulFunctions.GetPercentageInFloat(parent_object.GetComponent<Robot_Status>().GetHealthPoint(), parent_object.GetComponent<Robot_Status>().GetBaseHealthPoint()) < 0.2f)
        {
            SetCurrentState(ROBOT_STATES.ESCAPE);
            return true;
        }
        return false;
    }
    public bool ChangeStateToGather()
    {
        item_target = UsefulFunctions.GetNearbyItemWithBoxCollider(parent_object.transform.position, robot_local_sprite_size * 2);
        if (item_target != null && Random.Range(1, 101) < parent_object.GetComponent<Robot_Status>().GetChanceToGather())
        {
            SetCurrentState(ROBOT_STATES.GATHER);
            return true;
        }
        return false;
    }
    //setter
    public void SetCurrentState(ROBOT_STATES state)
    {
        states_enum = state;
        parent_object.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        if (current_state != null)
        {
            current_state.gameObject.SetActive(false);
        }
        current_state = states[(int)states_enum];
        current_state.gameObject.SetActive(true);
    }

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

    public void SetMoveToLocation(Vector3 pos)
    {
        item_target = null;
        ally_target = null;
        enemy_target = null;
        disignated_position = pos;
        SetCurrentState(ROBOT_STATES.MOVETO);
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

    public GameObject GetEnemyTarget()
    {
        return enemy_target;
    }
    public GameObject GetAllyTarget()
    {
        return ally_target;
    }
    public GameObject GetItemTaget()
    {
        return item_target;
    }
    public ROBOT_STATES GetRobotCurrentState()
    {
        return states_enum;
    }
}
