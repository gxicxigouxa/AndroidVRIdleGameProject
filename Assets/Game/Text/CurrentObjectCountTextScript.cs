using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Current Object Count Text에 대한 Script.
/// </summary>
public class CurrentObjectCountTextScript : MonoBehaviour {

  // Use this for initialization
  void Start() {

  }

  // Update is called once per frame
  void Update() {
    TextUpdate();
  }

  //Text의 내용 Update.
  public void TextUpdate() {
    GetComponent<Text>().text = "현재 갯수 : " + MainObjectScript.ObjectCount + "개";
  }
}

