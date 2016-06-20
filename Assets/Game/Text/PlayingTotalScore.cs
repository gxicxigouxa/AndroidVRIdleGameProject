using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayingTotalScore : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        TextUpdate();
	
	}

    public void TextUpdate()
    {
        GetComponent<Text>().text = "총 획득 점수 : " + MainObjectScript.totalScore;
    }
}
