using UnityEngine;
using System.Collections;

/// <summary>
/// Canvas에 관한 Script.
/// </summary>
public class CanvasScript : MonoBehaviour {
  //메인 카메라.
  public Camera main_camera;
  //카메라 회전에 대한 내용을 저장하는 객체.
  private Transform camera_rotation;
  //회전하기 전 원래 위치에 대한 내용.
  private static Quaternion kOriginalRotation;
  
	// Use this for initialization
	void Start () {
    kOriginalRotation = transform.rotation;
    camera_rotation = main_camera.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
    Rotate();
	}

  //카메라의 Z축 회전에 따라 해당 Object(Canvas)도 같이 회전.
  public void Rotate() {
    transform.rotation = Quaternion.Euler(kOriginalRotation.eulerAngles.x, camera_rotation.eulerAngles.y, kOriginalRotation.eulerAngles.z);
        //Debug.Log(Mathf.Cos(90 / 180 * Mathf.PI));
        float temp ;
        temp = camera_rotation.eulerAngles.y;
        float x = Mathf.Cos((temp - 90) / 180 * Mathf.PI);
        float z = Mathf.Sqrt(1 - x * x);
        if (camera_rotation.eulerAngles.y > 90 && camera_rotation.eulerAngles.y < 270)
        {
            transform.position = new Vector3(x * 3, 0, - z * 3);
        }
        else
        {
            transform.position = new Vector3(x * 3, 0, z * 3);
        }
    }
}
