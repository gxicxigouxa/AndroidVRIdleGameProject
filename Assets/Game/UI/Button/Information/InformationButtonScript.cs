using UnityEngine;
using System.Collections;

public class InformationButtonScript : MonoBehaviour {
  public GameObject menu_canvas, information_canvas;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  //Menu로 되돌아가기
  public void ReturnMenu() {
    menu_canvas.SetActive(!menu_canvas.activeSelf);
    information_canvas.SetActive(!information_canvas.activeSelf);
  }
}
