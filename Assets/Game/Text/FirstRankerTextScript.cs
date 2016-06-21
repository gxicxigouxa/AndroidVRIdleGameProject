using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FirstRankerTextScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        TextUpdate();
	}
    public void TextUpdate()
    {
        GetComponent<Text>().text = "서버에 등록한 1위의 점수 " + RankingButtonScript.FirstScore+"점";
    }
}
