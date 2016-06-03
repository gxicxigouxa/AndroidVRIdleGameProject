using UnityEngine;
using System.Collections;

/// <summary>
/// Message내 Button에 대한 Script.
/// </summary>
public class MessageButtonScript : MonoBehaviour {
  public GameObject message_canvas, shop_canvas;
  // Use this for initialization
  void Start() {

  }

  // Update is called once per frame
  void Update() {

  }

  //상점으로 되돌아가기.
  public void ReturnShop() {
    Vibration.Vibrate(100L);
    message_canvas.SetActive(!message_canvas.activeSelf);
    shop_canvas.SetActive(!shop_canvas.activeSelf);
  }
}
