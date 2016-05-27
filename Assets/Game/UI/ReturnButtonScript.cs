using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReturnButtonScript : MonoBehaviour {

  // Use this for initialization
  void Start() {

  }

  // Update is called once per frame
  void Update() {

  }

  public void MoveScene() {
    //0번 Scene(Main Game) 호출.
    SceneManager.LoadScene(0);

  }
}
