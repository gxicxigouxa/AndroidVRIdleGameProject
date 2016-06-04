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

    private static int day_ = 0;
    private static int hour_ = 0, minute_ = 0, second_ = 0;
        private static int ms = 0;
  
    // Use this for initialization
    void Start() {
    }

  // Update is called once per frame
  void Update() {
    TextUpdate();
  }

  //Text의 내용 Update.
  public void TextUpdate() {
    
    GetComponent<Text>().text = "플레이 시간 : \n" + Day + "일 " +
                                 Hour + "시간 " +
                                 Minute + "분 " +
                                 Second + "초";
        ms += 1;
        if ( ms >= 100 )
        {
            Second++;
            ms = 0;
        }
        if ( Second >= 60)
        {
            Minute++;
            Second = 0;
        }
        if ( Minute >= 60)
        {
            Hour++;
            Minute = 0;
        }
        if ( Hour >= 24)
        {
            Day++;
            Hour = 0;
        }
        ms++;
        DBmanager.storeDate();
  }
}