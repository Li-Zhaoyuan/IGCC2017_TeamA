using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterList : MonoBehaviour {

	private List<GameObject> m_monsterList = new List<GameObject>();

	[SerializeField]
	private int m_maxMonster = 10;

	public int MaxMonster
	{
		get { return m_maxMonster; }
	}

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (m_monsterList.Contains(null))
		{
			m_monsterList.Remove(null);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.gameObject.tag == "Monster")
		{
			m_monsterList.Add(col.gameObject);
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.gameObject.tag == "Monster")
		{
			m_monsterList.Remove(col.gameObject);
		}
	}

	public int GetListLength()
	{
		return m_monsterList.Count;
	}
}
