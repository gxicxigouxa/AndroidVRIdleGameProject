using UnityEngine;
using System.Collections;

public class RankingButtonScript : MonoBehaviour {
  public GameObject menu_canvas, ranking_canvas;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

  //Menu로 되돌아가기
  public void ReturnMenu() {
    Vibration.Vibrate(100L);
    menu_canvas.SetActive(!menu_canvas.activeSelf);
    ranking_canvas.SetActive(!ranking_canvas.activeSelf);
  }
    public void RefreshRank()
    {
        Vibration.Vibrate(100L);
        MySqlCon.startroutine(MainObjectScript.UserID, MainObjectScript.Score);
    }
}
