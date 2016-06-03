using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Playing Time Text에 대한 Script.
/// </summary>
public class PlayingTimeTextScript : MonoBehaviour {
  private class SimpleTime {
    public SimpleTime(float time_float) {
      ulong current_time = (ulong)time_float;
      second_ = (byte)(current_time % 60);
      current_time /= 60;
      minute_ = (byte)(current_time % 60);
      current_time /= 60;
      hour_ = (byte)(current_time % 24);
      current_time /= 24;
      day_ = (uint)current_time;
    }

    public uint Day {
      get {
        return day_;
      }
    }

    public byte Hour {
      get {
        return hour_;
      }
    }

    public byte Minute {
      get {
        return minute_;
      }
    }

    public byte Second {
      get {
        return second_;
      }
    }

    private uint day_ = 0;
    private byte hour_ = 0, minute_ = 0, second_ = 0;
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