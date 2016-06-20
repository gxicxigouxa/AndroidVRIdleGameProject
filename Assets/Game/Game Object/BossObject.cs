using UnityEngine;
using System.Collections;

public class BossObject : MonoBehaviour {
    // 일정 점수 이상이 되면 보스가 등장하고 보스가 등장하면 일반 물체들은 더이상 생성되지 않는다.
    // 보스를 잡고 나면 일반 물체들이 생성된다.
    // 보스는 일반 물체의 ** 배 의 비율로 값을 정했다.

    public static int score = MainObjectScript.UnitScore * 7;   // 보스를 잡으면 얻는 점수
    private float max_helth_point_ = MainObjectScript.MaxHelth * 10 * appearCount;    // 보스의 최대 체력
    public float current_helth_point_;      // 보스의 현재 체력
    private bool is_under_attack_ = false;      
    public static int appearCount;     // 보스가 몇번 등장했는지 카운트 하는 변수
    public static int appearScore = int.MaxValue;      // 보스의 등장 조건을 나타내기 위한 변수 ( 일정 점수 이상이면 보스 등장)
    public static bool isAppear = false;
    

    // Use this for initialization
    void Start () {
        
        current_helth_point_ = max_helth_point_;
        
    }
	
	// Update is called once per frame
	void Update () {
        appearScore = 100 * appearCount * appearCount;
        if (is_under_attack_) {
      DecreaseHelthPoint(ObjectRemover.Damage);
      ChangeColorScript.ChangeColorByHelthPoint(gameObject, max_helth_point_, current_helth_point_, is_boss_object : true);
    }
	
	}

    private void DecreaseHelthPoint(float damage)
    {
        current_helth_point_ -= damage;
        //만일 체력이 모두 소진됐을 경우 Object 제거를 위한 함수 호출.
        if (current_helth_point_ <= 0)
        {
            // 보스가 죽으면 보스 잡은 카운트(appearCount) 를 증가 시키고 현재 보스가 맵상에 존재 하지 않기 때문에 isAppear 과 isInBoss 가 false 가 된다.
            score = MainObjectScript.UnitScore * 7;
            appearCount++;
            appearScore = 100 * appearCount * appearCount ;
            ObjectGenerator.isInBoss = false;
            isAppear = false;
            SendMessage("RemoveBossObject");
            DBmanager.storeBossCount();
        }
    }

    public void set_is_under_attack(bool current_is_under_attack)
    {
        is_under_attack_ = current_is_under_attack;
    }
}
