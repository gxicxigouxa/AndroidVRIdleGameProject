using UnityEngine;
using System.Collections;

public class SpinObjectScript : MonoBehaviour {
  public static float kSpinSpeed = 0.5F;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    transform.Rotate(0.0F, kSpinSpeed, 0.0F);
	}
}
