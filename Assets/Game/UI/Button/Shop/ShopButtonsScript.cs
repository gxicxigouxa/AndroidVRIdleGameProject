using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Shop 내 각종 Button에 대한 Script.
/// </summary>
//TODO.
public class ShopButtonsScript : MonoBehaviour {
  public GameObject menu_canvas, shop_canvas, message_canvas;
    //각종 Item의 구매 비용.
    public static int price_of_increase_obtain_score_ = 1;
    public static int price_of_increase_maximum_object_ = 1;
    public static int price_of_increase_damage_ = 1;
    public static int price_of_reduce_generate_time_ = 1;
    public static int price_of_increase_object_scale_ = 1;
    public static int price_of_remove_all_objects_ = 1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
        price_of_increase_obtain_score_ = MainObjectScript.UnitScore * 2 ;
        price_of_increase_maximum_object_ = 100 * ( MainObjectScript.MaxObject - 5 );
        price_of_increase_damage_ = 100 * BossObject.appearCount * BossObject.appearCount;
        price_of_reduce_generate_time_ = 1600 - (int)(ObjectGenerator.GenerateDelay * 1000) ;
        price_of_increase_object_scale_ = (ObjectGenerator.ObjectScaleCount + 1 ) * 100;
        price_of_remove_all_objects_ = MainObjectScript.ObjectCount * ( MainObjectScript.UnitScore - 1 );
        
    }

  //Object에 따른 단위 점수 1 상승.
  public void IncreaseObtainScore() {
    Vibration.Vibrate(100L);
    if (IsCanPurchase(price_of_increase_obtain_score_)) {
      MainObjectScript.Score -= price_of_increase_obtain_score_;
      MainObjectScript.UnitScore += 1;
    } else {
      message_canvas.SetActive(!message_canvas.activeSelf);
      shop_canvas.SetActive(!shop_canvas.activeSelf);
    }
        DBmanager.storeUnitScore();
        DBmanager.storeScore();
        PlayingTimeTextScript.timeUpdate();
    }

  //Object의 최대 생성 갯수를 2 증가.
  public void IncreaseMaximumObject() {
    Vibration.Vibrate(100L);
    if (IsCanPurchase(price_of_increase_maximum_object_)) {
      MainObjectScript.Score -= price_of_increase_maximum_object_;
      MainObjectScript.MaxObject += 2;
    } else {
      message_canvas.SetActive(!message_canvas.activeSelf);
      shop_canvas.SetActive(!shop_canvas.activeSelf);
    }
        DBmanager.storeMaxObject();
        DBmanager.storeScore();
        PlayingTimeTextScript.timeUpdate();
    }
    

  //Object 공격 시 피해량을 0.2 증가.
  public void IncreaseDamage() {
    Vibration.Vibrate(100L);
    if (IsCanPurchase(price_of_increase_damage_)) {
      MainObjectScript.Score -= price_of_increase_damage_;
      ObjectRemover.Damage += 0.2F;
            DBmanager.storeDamage();
            PlayingTimeTextScript.timeUpdate();
        } else {
      message_canvas.SetActive(!message_canvas.activeSelf);
      shop_canvas.SetActive(!shop_canvas.activeSelf);
    }
  }

  //Object의 생성 시간을 0.03 감소.
  public void ReduceGenerateTime() {
    Vibration.Vibrate(100L);
    if (IsCanPurchase(price_of_reduce_generate_time_)) {
      MainObjectScript.Score -= price_of_reduce_generate_time_;
      ObjectGenerator.GenerateDelay -= 0.03F;
    } else {
      message_canvas.SetActive(!message_canvas.activeSelf);
      shop_canvas.SetActive(!shop_canvas.activeSelf);
    }
        DBmanager.storeGenerateDelay();
        DBmanager.storeScore();
        PlayingTimeTextScript.timeUpdate();
    }

  //Object 생성 시 크기에 대한 count를 1 증가.
  public void IncreaseObjectScale() {
    Vibration.Vibrate(100L);
    if (IsCanPurchase(price_of_increase_object_scale_)) {
      MainObjectScript.Score -= price_of_increase_object_scale_;
      ObjectGenerator.ObjectScaleCount += 3;
    } else {
      message_canvas.SetActive(!message_canvas.activeSelf);
      shop_canvas.SetActive(!shop_canvas.activeSelf);
    }
        DBmanager.storeScale();
        DBmanager.storeScore();
        PlayingTimeTextScript.timeUpdate();
    }

  public void RemoveAllObjects() {
    Vibration.Vibrate(100L);
    if (IsCanPurchase(price_of_remove_all_objects_)) {
      MainObjectScript.Score -= price_of_remove_all_objects_;
      ObjectRemover.RemoveAllObjects();
    } else {
      message_canvas.SetActive(!message_canvas.activeSelf);
      shop_canvas.SetActive(!shop_canvas.activeSelf);
    }
        DBmanager.storeScore();
        PlayingTimeTextScript.timeUpdate();
    }

  //Menu로 되돌아가기.
  public void ReturnMenu() {
    Vibration.Vibrate(100L);
    menu_canvas.SetActive(!menu_canvas.activeSelf);
    shop_canvas.SetActive(!shop_canvas.activeSelf);
  }

  //매개 변수로 전달받은 가격으로 구입 가능한지 확인.
  private bool IsCanPurchase(int price) {
    bool result = true;
    //예외 처리를 이용해서 Overflow가 발생할 시 구매 불가.
    if (MainObjectScript.Score - price < 0) {
      result = false;
    }
    return result;
  }
}
