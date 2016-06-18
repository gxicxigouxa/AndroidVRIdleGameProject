using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Playing Time Text에 대한 Script.
/// </summary>
public class PlayingTimeTextScript : MonoBehaviour {
  /// <summary>
  /// 시간에 대한 정보를 나타내기 위한 Class.
  /// </summary>

    public static int Day {
      get {
        return day_;
      } set {
      day_ = value;
    }
    }

    public static int Hour {
      get {
        return hour_;
      }set {
      hour_ = value;
    }
    }

    public static int Minute {
      get {
        return minute_;
      }set {
      minute_ = value;
    }
    }

    public static int Second {
      get {
        return second_;
      }set {
      second_ = value;
    }
    }
    public static int playDay
    {
        get
        {
            return playDay_;
        }
    }
    public static int playHour
    {
        get
        {
            return playHour_;
        }
    }
    public static int playMinute
    {
        get
        {
            return playMinute_;
        }
    }
    public static int playSecond
    {
        get
        {
            return playSecond_;
        }
    }

    private static int day_ = 0;
    private static int hour_ = 0, minute_ = 0, second_ = 0; // DB 불러올때 셋팅되는값

    private static int playDay_ = 0;
    private static int playHour_ = 0;
    private static int playMinute_ = 0;
    private static int playSecond_ = 0;

    private static int counter = 0;

    private static float playTime = 0.0F;
    // Use this for initialization
    void Start() {
    }

  // Update is called once per frame
  void Update() {
        counter++;
        if (counter >= 60)
        {
            TextUpdate();
            counter = 0;
        }
  }

  //Text의 내용 Update.
  public void TextUpdate() {

        playTime = Time.realtimeSinceStartup;

        playSecond_ = (int)playTime % 60;
        playTime /= 60;
        playMinute_ = (int)playTime % 60;
        playTime /= 60;
        playHour_ = (int)playTime % 60;
        playTime /= 60;
        playDay_ = (int)playTime % 24;

        int tempDay = Day + playDay;
        int tempHour = Hour + playHour;
        int tempMinute = Minute + playMinute;
        int tempSecond = Second + playSecond;



        if (tempSecond >= 60)
        {
            tempMinute++;
            tempSecond = 0;
        }
        if (tempMinute >= 60)
        {
            tempHour++;
            tempMinute = 0;
        }
        if (tempHour >= 24)
        {
            tempDay++;
            tempHour = 0;
        }
        

        GetComponent<Text>().text = "플레이 시간 : \n" + tempDay + "일 " +
                                 tempHour + "시간 " +
                                 tempMinute + "분 " +
                                 tempSecond + "초";

        DBmanager.storeDate(tempDay , tempHour, tempMinute, tempSecond);
  }
}