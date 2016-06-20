using UnityEngine;
using System.Collections;

/// <summary>
/// Object 제거 Script. ICardboardGazeResponder를 상속받아
/// Object를 바라보고 있을 때의 동작을 처리하도록 작성.
/// </summary>
public class ObjectRemover : MonoBehaviour, ICardboardGazeResponder
{
    //Object를 바라보고 있을 때의 주는 피해량.
    private static float damage_ = 1.0F;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public static float Damage
    {
        get
        {
            return damage_;
        }
        set
        {
            damage_ = value;
        }
    }

    //Object 제거 함수.
    public void RemoveObject()
    {
        //gameObject를 없앤다.
        MainObjectScript.GameObjects.Remove(gameObject);
        Destroy(gameObject);
        MainObjectScript.ObjectCount -= 1;
        MainObjectScript.Score += MainObjectScript.UnitScore;
        MainObjectScript.totalScore += MainObjectScript.UnitScore;
        DBmanager.storeScore();
        PlayingTimeTextScript.timeUpdate();
        sound.removeSound();
    }

    public void RemoveBossObject()
    {
        //BossObject를 없앤다.
        Destroy(gameObject);
        MainObjectScript.Score += BossObject.score;
        MainObjectScript.totalScore += BossObject.score;
        DBmanager.storeScore();
        PlayingTimeTextScript.timeUpdate();
    }

    //호출 시 모든 Object 제거.
    public static void RemoveAllObjects()
    {
        uint number_of_object = (uint)MainObjectScript.GameObjects.Count;
        foreach (GameObject current_object in MainObjectScript.GameObjects)
        {
            Destroy(current_object);
        }
        MainObjectScript.ObjectCount = 0;
        MainObjectScript.Score += MainObjectScript.UnitScore * number_of_object;
        MainObjectScript.GameObjects.Clear();
    }

    //Object를 바라보고 있을 때의 동작.
    public void OnGazeEnter()
    {
        //현재 Object를 공격받고 있는 상태로 변경 후 체력 감소.
        gameObject.SendMessage("set_is_under_attack", true);
        gameObject.SendMessage("DecreaseHelthPoint", damage_);
    }

    //Object를 바라보고 있다가 보지 않을 때의 동작.
    public void OnGazeExit()
    {
        //현재 Object를 공격받고 있지 않는 상태로 변경.
        gameObject.SendMessage("set_is_under_attack", false);
    }

    //Object에 대해 버튼 입력을 했을 때의 동작.
    public void OnGazeTrigger()
    {

    }
}