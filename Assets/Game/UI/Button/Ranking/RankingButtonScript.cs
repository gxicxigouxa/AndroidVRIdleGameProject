using System;
using System.Data;
using UnityEngine;
using System.Collections;
using SimpleJSON;

using System.Collections.Generic;

public class RankingButtonScript : MonoBehaviour {
  public GameObject menu_canvas, ranking_canvas;

	// Use this for initialization
	void Start () {
        
        Submit(MainObjectScript.UserID, MainObjectScript.Score);
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
        Submit(MainObjectScript.UserID, MainObjectScript.Score);
    }

    private string Url = null;

    public void Submit(int id, long score)
    {
        Debug.Log(id);
       
        Url = "http://110.46.227.154:9090/term_proj/DBman.jsp?id=" + id.ToString() + "&score=" + score.ToString();
        StartCoroutine("ViewData");
    }

    IEnumerator ViewData()
    {

        WWW result = MySqlCon.instance.GET(Url);
        yield return result;
        if (result.isDone)
        {
            
            JSONNode jsonData = JSON.Parse(result.text);
            
            int flag;
            flag = Convert.ToInt32(jsonData["flag_getID"].Value);
            Debug.Log("result test");
            if (flag==1)
            {
                MainObjectScript.UserID = Convert.ToInt32(jsonData["gotID"].Value);

                DBmanager.storeUserID();
            }
            MainObjectScript.Rank = Convert.ToInt32(jsonData["rank"].Value);
            firstscore = Convert.ToInt32(jsonData["fr_score"].Value);
            MyScore =MainObjectScript.Score;
        }
    }
    private static int firstscore = 0;
    private static long myscore = 0;
    public static int FirstScore
    {
        get
        {
            return firstscore;
        }
        set
        {
            firstscore = value;
        }
    }
    public static long MyScore
    {
        get
        {
            return myscore;
        }
        set
        {
            myscore = value;
        }
    }


    

}
