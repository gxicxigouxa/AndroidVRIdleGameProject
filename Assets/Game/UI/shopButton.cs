using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class shopButton : MonoBehaviour, ICardboardGazeResponder
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void moveScene()
    {
        SceneManager.LoadScene(1);
    }

    public void OnGazeEnter()
    {
        moveScene();
    }

    public void OnGazeExit()
    {
        moveScene();
    }

    public void OnGazeTrigger()
    {
        moveScene();
    }
}
