using UnityEngine;
using System.Collections;

/// <summary>
/// Object 제거 Script. ICardboardGazeResponder를 상속받아
/// Object를 바라보고 있을 때의 동작을 처리하도록 작성.
/// </summary>
public class ObjectRemover : MonoBehaviour, ICardboardGazeResponder {
  // Use this for initialization
  void Start() {
  }

  // Update is called once per frame
  void Update() {

  }

  //Object 제거 함수.
  public void RemoveObject() {
    //gameObject를 없앤다.
    Destroy(gameObject);
    MainObjectScript.DecreaseObjectCount();
    MainObjectScript.Score += 1;
  }

  //Object를 바라보고 있을 때의 동작.
  public void OnGazeEnter() {
    //RemoveObject 함수를 0.2초 후에 호출.
    Invoke("RemoveObject", 0.2F);
  }

  //Object를 바라보고 있다가 보지 않을 때의 동작.
  public void OnGazeExit() {
    //RemoveObject에 대한 Invoke를 호출 대기 중이었다면 취소.
    CancelInvoke("RemoveObject");
  }

  //Object에 대해 버튼 입력을 했을 때의 동작.
  public void OnGazeTrigger() {

  }
}