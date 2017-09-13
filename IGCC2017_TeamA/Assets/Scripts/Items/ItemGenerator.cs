using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour {

    public GameObject item;
    public GameObject item_usable;
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
            SpawnRandowmItem(new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 1));
        }
        //timer += Time.deltaTime;
        //if(timer > spawn_intervals)
        //{
        //    timer = 0f;
        //    if(Random.Range(0,2) == 0)
        //    {
        //        if(Random.Range(1,101) < 10)
        //        {
        //            SpawnRandomUsable(new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 1));
        //        }
        //        else
        //        {
        //            SpawnRandomResource(new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), 1));
        //        }
               
        //    }
        //}
    }

    public void SpawnRandomResource(Vector3 pos)
    {
        GameObject tempItem = Instantiate(item, pos, Quaternion.Euler(0, 0, 0)) as GameObject;
        tempItem.GetComponent<Item_Base>().Initialize((ITEM_TYPE)Random.Range(0, (int)ITEM_TYPE.TOTAL_RESOURCE));
    }

    public void SpawnRandomUsable(Vector3 pos)
    {
        GameObject tempItem = Instantiate(item_usable, pos, Quaternion.Euler(0, 0, 0)) as GameObject;
        tempItem.GetComponent<Item_Base>().Initialize((ITEM_TYPE)Random.Range((int)ITEM_TYPE.TOTAL_RESOURCE + 1, (int)ITEM_TYPE.TOTAL_USABLE));
    }

    public void SpawnRandowmItem(Vector3 pos)
    {
        if (Random.Range(1, 101) < 0)
        {
            SpawnRandomUsable(pos);
        }
        else
        {
            SpawnRandomResource(pos);
        }
    }
}
