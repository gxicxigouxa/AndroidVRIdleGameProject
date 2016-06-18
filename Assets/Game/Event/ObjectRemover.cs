using UnityEngine;
using System.Collections;

/// <summary>
/// Object 제거 Script. ICardboardGazeResponder를 상속받아
/// Object를 바라보고 있을 때의 동작을 처리하도록 작성.
/// </summary>
public class ObjectRemover : MonoBehaviour, ICardboardGazeResponder {
  //Object를 바라보고 있을 때의 주는 피해량.
  private static int damage_ = 1;
  private static float remove_time_ = 0.5F;
  // Use this for initialization
  void Start() {
  }

  // Update is called once per frame
  void Update() {

  }

  public static int Damage {
    get {
      return damage_;
    } set {
      damage_ = value;
    }
  }

  public static float RemoveTime {
    get {
      return remove_time_;
    } set {
      remove_time_ = value;
    }
  }

  //Object 제거 함수.
  public void RemoveObject() {
    //gameObject를 없앤다.
    MainObjectScript.GameObjects.Remove(gameObject);
    Destroy(gameObject);
    MainObjectScript.ObjectCount -= 1;
    MainObjectScript.Score += MainObjectScript.UnitScore;
       DBmanager.storeScore();
  }

  //호출 시 모든 Object 제거.
  public static void RemoveAllObjects() {
    uint number_of_object = (uint)MainObjectScript.GameObjects.Count;
    foreach (GameObject current_object in MainObjectScript.GameObjects) {
      Destroy(current_object);
    }
    MainObjectScript.ObjectCount = 0;
    MainObjectScript.Score += MainObjectScript.UnitScore * number_of_object;
    MainObjectScript.GameObjects.Clear();
  }

  //Object를 바라보고 있을 때의 동작.
  public void OnGazeEnter() {
    //현재 Object를 공격받고 있는 상태로 변경 후 체력 감소.
    gameObject.SendMessage("set_is_under_attack", true);
    gameObject.SendMessage("DecreaseHelthPoint", damage_);
  }

  //Object를 바라보고 있다가 보지 않을 때의 동작.
  public void OnGazeExit() {
    //현재 Object를 공격받고 있지 않는 상태로 변경.
    gameObject.SendMessage("set_is_under_attack", false);
  }

  //Object에 대해 버튼 입력을 했을 때의 동작.
  public void OnGazeTrigger() {

  }
}