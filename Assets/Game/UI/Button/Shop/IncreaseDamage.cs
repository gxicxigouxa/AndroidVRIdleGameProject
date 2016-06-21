using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IncreaseDamage : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<Text>().text = "구매 (" + ShopButtonsScript.price_of_increase_damage_ + ")";
    }
}
