using UnityEngine;
using System.Collections;

public class ChangeColorScript : MonoBehaviour {
  private Material object_material_;
	// Use this for initialization
	void Start () {
    object_material_ = GetComponent<Renderer>().material;
    gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", Color.yellow);
	}
	
	// Update is called once per frame
	void Update () {

  }
}
