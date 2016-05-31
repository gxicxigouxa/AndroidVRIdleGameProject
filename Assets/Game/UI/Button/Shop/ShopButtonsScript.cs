using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Shop 내 각종 Button에 대한 Script.
/// </summary>
//TODO.
public class ShopButtonsScript : MonoBehaviour {
  public GameObject menu_canvas, shop_canvas;
  public Button increase_obtain_score_button;
  public GameObject increase_maximum_object_button;
  public GameObject reduce_remove_time_button;
  public GameObject reduce_generate_time_button;
  public GameObject increase_object_scale_button;
  //각종 Item의 구매 비용.
  private int price_of_increase_obtain_score_ = 1;
  private int price_of_increase_maximum_object_ = 1;
  private int price_of_reduce_remove_time_ = 1;
  private int price_of_reduce_generate_time_ = 1;
  private int increase_object_scale_ = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  //Object에 따른 단위 점수 1 상승.
  public void IncreaseObtainScore() {
    Vibration.Vibrate(50L);
    MainObjectScript.UnitScore += 1;

  }

  //Object의 최대 생성 갯수를 1 증가.
  public void IncreaseMaximumObject() {
    Vibration.Vibrate(50L);
    MainObjectScript.MaxObject += 1;
  }

  //Object의 제거 시간을 0.01 감소.
  public void ReduceRemoveTime() {
    Vibration.Vibrate(50L);
    ObjectRemover.RemoveTime -= 0.01F;
  }

  //Object의 생성 시간을 0.01 감소.
  public void ReduceGenerateTime() {
    Vibration.Vibrate(50L);
    ObjectGenerator.GenerateDelay -= 0.01F;
  }

  //Object 생성 시 크기에 대한 count를 1 증가.
  public void IncreaseObjectScale() {
    Vibration.Vibrate(50L);
    ObjectGenerator.ObjectScaleCount += 1;
  }

  //Menu로 되돌아가기.
  public void ReturnMenu() {
    Vibration.Vibrate(50L);
    menu_canvas.SetActive(!menu_canvas.activeSelf);
    shop_canvas.SetActive(!shop_canvas.activeSelf);
  }
}
