using UnityEngine;
using UnityEngine.UI;
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
  //Object의 기본 최대 체력.
  private int max_helth_point_ = 100;
  //Object의 현재 체력.
  public int current_helth_point_;
  //Object의 체력이 전부 떨어졌는지 판단.
  private bool is_under_attack_ = false;
  //Object의 체력을 나타낼 체력 게이지.
  public Slider helth_bar_slider;
  // Use this for initialization
  void Start() {
    current_helth_point_ = max_helth_point_;

  }

  // Update is called once per frame
  void Update() {
    if (is_under_attack_) {
      DecreaseHelthPoint(ObjectRemover.Damage);
    }
  }

  //매개 변수로 전달된 피해량만큼 체력을 감소시킴.
  private void DecreaseHelthPoint(int damage) {
    current_helth_point_ -= damage;
    //만일 체력이 모두 소진됐을 경우 Object 제거를 위한 함수 호출.
    if (current_helth_point_ <= 0) {
      SendMessage("RemoveObject");
    }
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

  public void set_is_under_attack(bool current_is_under_attack) {
    is_under_attack_ = current_is_under_attack;
  }

  public static HashSet<GameObject> GameObjects {
    get {
      return game_objects_;
    }
  }
}
