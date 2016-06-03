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
  public class SimpleTime {
    //매개 변수로 전달받은 float형을 parsing하여 일, 시, 분, 초로 나누어 저장.
    public SimpleTime(float time_float) {
      long current_time = (long)time_float;
      second_ = (int)(current_time % 60);
      current_time /= 60;
      minute_ = (int)(current_time % 60);
      current_time /= 60;
      hour_ = (int)(current_time % 24);
      current_time /= 24;
      day_ = (int)current_time;
    }

    public int Day {
      get {
        return day_;
      } set {
      day_ = value;
    }
    }

    public int Hour {
      get {
        return hour_;
      }set {
      hour_ = value;
    }
    }

    public int Minute {
      get {
        return minute_;
      }set {
      minute_ = value;
    }
    }

    public int Second {
      get {
        return second_;
      }set {
      second_ = value;
    }
    }

    private static int day_ = 0;
    private static int hour_ = 0, minute_ = 0, second_ = 0;
  }

  // Use this for initialization
  void Start() {

  }

  // Update is called once per frame
  void Update() {
    TextUpdate();
  }

  //Text의 내용 Update.
  public void TextUpdate() {
    SimpleTime current_time = new SimpleTime(Time.realtimeSinceStartup);
    GetComponent<Text>().text = "플레이 시간 : \n" + current_time.Day + "일 " +
                                 current_time.Hour + "시간 " +
                                 current_time.Minute + "분 " +
                                 current_time.Second + "초";
  }
}