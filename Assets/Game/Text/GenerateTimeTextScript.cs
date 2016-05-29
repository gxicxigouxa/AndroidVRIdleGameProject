using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Generate Time Text에 대한 Script.
/// </summary>
public class GenerateTimeTextScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

  // Update is called once per frame
  void Update() {
    TextUpdate();
  }

  //Text의 내용 Update.
  public void TextUpdate() {
    GetComponent<Text>().text = "생성 시간 : " + ObjectGenerator.GenerateDelay + "초";
  }
}
