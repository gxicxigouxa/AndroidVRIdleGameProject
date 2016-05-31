using UnityEngine;
using System.Collections;

/// <summary>
/// Main Object에 대한 Script.
/// </summary>
public class MainObjectScript : MonoBehaviour {
  //제거한 Object에 따른 점수.
  private static int score_ = 0;
  //한 Object에 대한 단위 점수.
  private static int unit_score_ = 1;
  //현재 화면에 나타난 Object의 갯수.
  private static int object_count_ = 0;
  //최대 생성 가능한 Object의 갯수.
  private static int max_object_ = 10;

  // Use this for initialization
  void Start() {

  }

  // Update is called once per frame
  void Update() {

  }

  public static int Score {
    get {
      return score_;
    } set {
      score_ = value;
    }
  }

  public static int UnitScore {
    get {
      return unit_score_;
    } set {
      unit_score_ = value;
    }
  }

  public static int ObjectCount {
    get {
      return object_count_;
    }
  }

  public static int MaxObject {
    get {
      return max_object_;
    } set {
      max_object_ = value;
    }
  }

  public static void IncreaseObjectCount() {
    ++object_count_;
  }

  public static void DecreaseObjectCount() {
    --object_count_;
  }

  public static void IncreaseMaxCount() {
    ++max_object_;
  }

  public static void DecreaseMaxCount() {
    --max_object_;
  }
}
