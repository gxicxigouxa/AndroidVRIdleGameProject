using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Maximum Object Text에 대한 Script.
/// </summary>
public class MaximumObjectTextScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

  // Update is called once per frame
  void Update() {
        TextUpdate();
  }

  //Text의 내용 Update.
  public void TextUpdate() {
    GetComponent<Text>().text = "최대 갯수 : " + MainObjectScript.MaxObject + "개";
  }
}
