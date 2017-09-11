using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour {

	SceneInstructor m_sceneInstructor = null;

	// Use this for initialization
	void Start () {
		m_sceneInstructor = SceneInstructor.instance;
	}


	public void LoadTitle()
	{
		m_sceneInstructor.LoadMainScene(GameScene.Title);
	}
	public void LoadMenu()
	{
		m_sceneInstructor.LoadMainScene(GameScene.Menu);
	}
	public void LoadPlay()
	{
		m_sceneInstructor.LoadMainScene(GameScene.Play);
	}
}
