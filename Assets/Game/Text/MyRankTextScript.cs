using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MyRankTextScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        TextUpdate();
    }
    public void TextUpdate()
    {
        GetComponent<Text>().text = "현재 나의 순위/점수\n" + MainObjectScript.Rank + "위/"+MySqlCon.MyScore+"점";
    }
}
