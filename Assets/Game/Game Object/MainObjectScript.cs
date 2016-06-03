using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Main Object에 대한 Script.
/// </summary>
public class MainObjectScript : MonoBehaviour {
  //제거한 Object에 따른 점수.
  private static long score_ = 0;
  //한 Object에 대한 단위 점수.
  private static int unit_score_ = 1;
  //현재 화면에 나타난 Object의 갯수.
  private static int object_count_ = 0;
  //최대 생성 가능한 Object의 갯수.
  private static int max_object_ = 10;
  //object를 저장하기 위한 HashSet;
  private static HashSet<GameObject> game_objects_ = new HashSet<GameObject>();
  // Use this for initialization
  void Start() {

  }

  // Update is called once per frame
  void Update() {
    

  }

  public static long Score {
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
    } set {
      object_count_ = value;
    }
  }

  public static int MaxObject {
    get {
      return max_object_;
    } set {
      max_object_ = value;
    }
  }

  public static HashSet<GameObject> GameObjects {
    get {
      return game_objects_;
    }
  }
}
