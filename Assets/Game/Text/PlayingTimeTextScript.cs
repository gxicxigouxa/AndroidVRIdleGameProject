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
    private static float preTime = 0.0F;
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

        timeUpdate();

        GetComponent<Text>().text = "플레이 시간 : \n" + Day + "일 " +
                                 Hour + "시간 " +
                                 Minute + "분 " +
                                 Second + "초";
  }

    public static void timeUpdate()
    {
        playTime = Time.realtimeSinceStartup;

        float temp = playTime;

        playSecond_ = (int)playTime % 60;
        playTime /= 60;
        playMinute_ = (int)playTime % 60;
        playTime /= 60;
        playHour_ = (int)playTime % 60;
        playTime /= 60;
        playDay_ = (int)playTime % 24;

        int tempSecond = (int)preTime % 60;
        preTime /= 60;
        int tempMinute = (int)preTime % 60;
        preTime /= 60;
        int tempHour = (int)preTime % 60;
        preTime /= 60;
        int tempDay = (int)preTime % 24;



        Day = Day + playDay - tempDay;
        Hour = Hour + playHour - tempHour;
        Minute = Minute + playMinute - tempMinute;
        Second = Second + playSecond - tempSecond;

        if (Second >= 60)
        {
            Minute++;
            Second = 0;
        }
        if (Minute >= 60)
        {
            Hour++;
            Minute = 0;
        }
        if (Hour >= 24)
        {
            Day++;
            Hour = 0;
        }

        preTime = temp;
        DBmanager.storeDate();

    }
}