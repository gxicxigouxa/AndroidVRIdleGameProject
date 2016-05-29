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
    menu_canvas.SetActive(!menu_canvas.activeSelf);
    shop_canvas.SetActive(!shop_canvas.activeSelf);
  }

  public void OpenInformation() {
    menu_canvas.SetActive(!menu_canvas.activeSelf);
    information_canvas.SetActive(!information_canvas.activeSelf);
  }

  public void OpenRanking() {
    menu_canvas.SetActive(!menu_canvas.activeSelf);
    ranking_canvas.SetActive(!ranking_canvas.activeSelf);
  }
}
