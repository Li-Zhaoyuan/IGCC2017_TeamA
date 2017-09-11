using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {

    public GameObject item;
    // Use this for initialization

    public float spawn_intervals;

    private float timer;
    void Start()
    {
        timer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            GameObject tempItem = Instantiate(item, new Vector3(Random.Range(-5,5),Random.Range(-5, 5), 1), Quaternion.Euler(0, 0, 0)) as GameObject;
        }
        timer += Time.deltaTime;
        if(timer > spawn_intervals)
        {
            timer = 0f;
            if(Random.Range(0,2) == 0)
            {
                GameObject tempItem = Instantiate(item, new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 1), Quaternion.Euler(0, 0, 0)) as GameObject;
            }
        }
    }
}
