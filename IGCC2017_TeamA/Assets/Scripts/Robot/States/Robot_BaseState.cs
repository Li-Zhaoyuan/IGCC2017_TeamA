using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot_BaseState : MonoBehaviour {

    //Area waypoints
// protected Vector3 disignated_area;
    protected GameObject state_holder;
    protected GameObject main_robot;
    protected State_Manager state_holder_stateManager;
    protected Robot_Status robot_status;

    protected float timer;

    protected Vector2 robot_direction;
    protected Vector2 robot_velocity;

    protected bool isDone;


    // Use this for initialization
    public virtual void Start()
    {
        state_holder = transform.parent.gameObject;
        main_robot = transform.root.gameObject;
        state_holder_stateManager = state_holder.GetComponent<State_Manager>();
        robot_status = main_robot.GetComponent<Robot_Status>();
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    public virtual void Update()
    {
        robot_status.MinusEnergyPoint(UsefulFunctions.ConstantValueToReplaceDT());
    }

    //Update is called once per frame manually
    public virtual void Execute()
    {

    }


    //setters
    //public void SetDisignatedArea(float x, float y, float z)
    //{
    //    disignated_area.Set(x, y, z);
    //}

    //public void SetDisignatedArea(Vector3 coord)
    //{
    //    disignated_area = coord;
    //}

    public bool GetIsDone()
    {
        return isDone;
    }

    public void SetMainRobot(GameObject go)
    {
        main_robot = go;
    }

    public void SetRobotStatus(Robot_Status status)
    {
        robot_status = status;
    }

    public void ToggleIsDone()
    {
        isDone = !isDone;
    }

    public virtual void SpawnParticles(GameObject go,Vector3 pos)
    {
        GameObject tempGO = Instantiate(go, pos, Quaternion.Euler(0, 0, 0)) as GameObject;
    }
}
