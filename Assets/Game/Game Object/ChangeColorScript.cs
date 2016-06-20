using UnityEngine;
using System.Collections;

/// <summary>
/// Object의 색을 변경하기 위한 Script.
/// </summary>
public class ChangeColorScript : MonoBehaviour {
  //현재 Object의 Material.
  private Material object_material_;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

  }
  //매개 변수로 현재 Object, 최대 체력, 현재 체력을 받아 비율을 계산해 체력에 대한 색 변경.
  public static void ChangeColorByHelthPoint(GameObject current_object, float max_helth_point, float current_helth_point, bool is_boss_object) {
    //새로운 Green, Blue값 설정(점차 붉은 색으로 바꾸기 위해).
    Material object_material = current_object.GetComponent<Renderer>().material;
    float new_r_color, new_g_color, new_b_color;
    if (is_boss_object) {
      new_r_color = 1 - (current_helth_point / max_helth_point);
      new_g_color = 1 - new_r_color;
      new_b_color = current_object.GetComponent<Renderer>().material.GetColor("_EmissionColor").b;
    } else {
      new_r_color = current_object.GetComponent<Renderer>().material.GetColor("_EmissionColor").r;
      new_g_color = (current_helth_point / max_helth_point);
      new_b_color = new_g_color;
    }
    Color new_color = new Color(new_r_color, new_g_color, new_b_color);
    current_object.GetComponent<Renderer>().material.SetColor("_EmissionColor", new_color);
  }
}
