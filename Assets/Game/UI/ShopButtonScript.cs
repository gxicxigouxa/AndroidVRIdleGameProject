using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class ShopButtonScript : MonoBehaviour {
    public GameObject buttonUI;
    public GameObject shopCanvas;
  // Use this for initialization
  void Start() {
  }

  // Update is called once per frame
  void Update() {

  }

  public void MoveScene() {
        //1번 Scene(shop) 호출.
        //SceneManager.LoadScene(1);
        buttonUI.SetActive(!buttonUI.activeSelf);
        shopCanvas.SetActive(!shopCanvas.activeSelf);

  }
}
