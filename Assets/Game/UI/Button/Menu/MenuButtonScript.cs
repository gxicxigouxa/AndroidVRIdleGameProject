using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// 각종 Menu Button에 대한 Script.
/// </summary>
public class MenuButtonScript : MonoBehaviour {
  public GameObject menu_canvas, shop_canvas, information_canvas, ranking_canvas;
  // Use this for initialization
  void Start() {
  }

  // Update is called once per frame
  void Update() {
  }

  //menu_canvas와 shop_canvas의 active 전환.
  public void OpenShop() {
    Vibration.Vibrate(100L);
    menu_canvas.SetActive(!menu_canvas.activeSelf);
    shop_canvas.SetActive(!shop_canvas.activeSelf);
  }

  //menu_canvas와 information_canvas의 active 전환.
  public void OpenInformation() {
    Vibration.Vibrate(100L);
    menu_canvas.SetActive(!menu_canvas.activeSelf);
    information_canvas.SetActive(!information_canvas.activeSelf);
  }

  //menu_canvas와 ranking_canvas의 active 전환.
  public void OpenRanking() {
    Vibration.Vibrate(100L);
    menu_canvas.SetActive(!menu_canvas.activeSelf);
    ranking_canvas.SetActive(!ranking_canvas.activeSelf);
  }

  //게임 종료.
  public void ExitGame() {
    Vibration.Vibrate(100L);
    Application.Quit();
  }
}
