using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreTextScript : MonoBehaviour {
	// Use this for initialization
	void Start () {
	}

  // Update is called once per frame
  void Update() {

    TextUpdate();
  }
  public void TextUpdate() {
    GetComponent<Text>().text = "Score = " + MainObjectScript.Score;
  }
}
