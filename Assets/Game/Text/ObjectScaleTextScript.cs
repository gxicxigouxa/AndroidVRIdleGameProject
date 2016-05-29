using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Object Scale Text에 대한 Script.
/// </summary>
public class ObjectScaleTextScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

  // Update is called once per frame
  void Update() {
    TextUpdate();
  }

  //Text의 내용 Update.
  public void TextUpdate() {
    GetComponent<Text>().text = "물체 크기 증가치 : " + ObjectGenerator.ObjectScaleCount;
  }
}
