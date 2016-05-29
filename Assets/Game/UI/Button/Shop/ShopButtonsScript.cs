using UnityEngine;
using System.Collections;

/// <summary>
/// Shop 내 각종 Button에 대한 Script.
/// </summary>
public class ShopButtonsScript : MonoBehaviour {
  public GameObject menu_canvas, shop_canvas;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  //Object에 따른 단위 점수 1 상승.
  public void IncreaseObtainScore() {
    MainObjectScript.UnitScore += 1;
  }

  //Object의 최대 생성 갯수를 1 증가.
  public void IncreaseMaximumObject() {
    MainObjectScript.MaxObject += 1;
  }

  //Object의 제거 시간을 0.01 감소.
  public void ReduceRemoveTime() {
    ObjectRemover.RemoveTime -= 0.01F;
  }

  //Object의 생성 시간을 0.01 감소.
  public void ReduceGenerateTime() {
    ObjectGenerator.GenerateDelay -= 0.01F;
  }

  //Object 생성 시 크기에 대한 count를 1 증가.
  public void IncreaseObjectScale() {
    ObjectGenerator.ObjectScaleCount += 1;
  }

  //Menu로 되돌아가기.
  public void ReturnMenu() {
    menu_canvas.SetActive(!menu_canvas.activeSelf);
    shop_canvas.SetActive(!shop_canvas.activeSelf);
  }
}
