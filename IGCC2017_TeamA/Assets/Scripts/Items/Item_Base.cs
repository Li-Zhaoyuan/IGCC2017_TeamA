using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ITEM_TYPE
{
    RESOURCE_BATTERY,
    RESOURCE_SPRING,
    RESOURCE_COG,
    RESOURCE_SCRAPMETAL,
    TOTAL_RESOURCE,
    USABLE_ONE,
    USABLE_TWO,
    USABLE_THREE,
    USABLE_FOUR,
    TOTAL_USABLE,
}

public class Item_Base : MonoBehaviour {
    protected int number_resources;
    public GameObject main_gather;
    private ITEM_TYPE item_type;
    //size of the sprite.
    public Vector2 item_sprite_size;
    public Vector2 item_local_sprite_size;
    public float item_sprite_across_length;
    public Sprite item_sprite;
    // Use this for initialization
    public virtual void Start () {
        item_sprite = GetComponent<SpriteRenderer>().sprite;
        item_sprite_size = item_sprite.rect.size;
        item_local_sprite_size = item_sprite_size / item_sprite.pixelsPerUnit;
        item_sprite_across_length = Mathf.Sqrt(item_local_sprite_size.x * item_local_sprite_size.x + item_local_sprite_size.y * item_local_sprite_size.y);
    }

    public virtual void Update()
    {
        if(main_gather != null)
        {
            if(UsefulFunctions.GetDistanceOfTwoPoints(main_gather.transform.position, transform.position) > item_local_sprite_size.x * 2)
            {
                main_gather = null;
            }
        }
    }

    public virtual int GetNumberOfResourcesWorth()
    {
        return number_resources;
    }

    public virtual void SetMainGather(GameObject go)
    {
        main_gather = go;
    }

    public virtual void SetItemType(ITEM_TYPE type)
    {
        item_type = type;
    }

    public virtual ITEM_TYPE GetItemType()
    {
        return item_type;
    }

    public virtual void Initialize(ITEM_TYPE type)
    {
        SetItemType(type);
    }

    public virtual GameObject GetMainGather()
    {
        return main_gather;
    }
    //// Update is called once per frame
    //public virtual void Update () {

    //}
}
