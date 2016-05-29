using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Remove Time Text에 대한 Script.
/// </summary>
public class RemoveTimeTextScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

  // Update is called once per frame
  void Update() {
    TextUpdate();
  }

  //Text의 내용 Update.
  public void TextUpdate() {
    GetComponent<Text>().text = "제거 시간 : " + ObjectRemover.RemoveTime + "초";
  }
}
