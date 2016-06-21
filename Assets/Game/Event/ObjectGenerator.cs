using UnityEngine;
using System.Collections;

/// <summary>
/// Object 생성 Script.
/// </summary>
public class ObjectGenerator : MonoBehaviour
{

    //게임에 등장하는 Object. Game Object와 연결한다.
    public GameObject main_object;
    public GameObject boss_object;
    private GameObject Boss;
    //Object가 생성되는 주기.
    private static float generate_delay_ = 1.5F;
    //Object의 크기 증가에 대한 count.
    private static int object_scale_count_ = 0;
    private float current_generate_delay_ = generate_delay_;
    public static bool isInBoss = false;
    private int moveCount = 0;
    // Use this for initialization
    void Start()
    {
        
    }

    void Update()
    {
        BossObject.appearScore = 100 * BossObject.appearCount * BossObject.appearCount;
        current_generate_delay_ -= Time.deltaTime;

        if (current_generate_delay_ <= 0)
        {
            //Debug.Log(BossObject.appearScore);
            if (BossObject.appearScore < MainObjectScript.totalScore)
            {
                isInBoss = true;
            }
            if (!isInBoss)
            {
                GenerateObject();
            }
            else
            {
                GenerateBoss();
            }
            current_generate_delay_ = generate_delay_;
        }
        //Debug.Log(isInBoss);
        if (isInBoss)
        {   // 보스가 순간이동 하게 만드는 부분
            moveCount++;
            //Debug.Log(moveCount);
            if (moveCount >= 100)
            {
                float position_x = Boss.transform.position.x + Random.Range(-1.0F, 1.0F);
                float position_z = Boss.transform.position.z + Random.Range(-1.0F, 1.0F);

                //지정된 범위 내에서는 생성되지 않도록 처리.
                while (position_x * position_x + position_z * position_z < 16)
                {
                    position_x = Boss.transform.position.x + Random.Range(-1.0F, 1.0F);
                    position_z = Boss.transform.position.z + Random.Range(-1.0F, 1.0F);
                }
                //x, z좌표를 이용해 y좌표 생성.
                float position_y = Random.Range(1.0F, Mathf.Sqrt(position_x * position_x +
                                                                 position_z * position_z)
                                                                 / Mathf.Sqrt(3.0F));
                //결정된 좌표들을 이용해 이동.
                Boss.transform.position = new Vector3(position_x, position_y + 2,
                                                             position_z);
                moveCount = 0;
            }
        }

    }

    public static float GenerateDelay
    {
        get
        {
            return generate_delay_;
        }
        set
        {
            if (generate_delay_ > 0.01F)
            {
                generate_delay_ = value;
            }
        }
    }

    public static int ObjectScaleCount
    {
        get
        {
            return object_scale_count_;
        }
        set
        {
            object_scale_count_ = value;
        }
    }

    public void GenerateObject()
    {
        if (MainObjectScript.ObjectCount < MainObjectScript.MaxObject)
        {
            //main_object를 복제.
            GameObject new_object = Instantiate(main_object);

            new_object.transform.localScale += new Vector3(0.01F * object_scale_count_,
                                                            0.01F * object_scale_count_,
                                                            0.01F * object_scale_count_);
            //x, z좌표 설정.
            float position_x = Random.Range(-10.0F, 10.0F);
            float position_z = Random.Range(-10.0F, 10.0F);
            //지정된 범위 내에서는 생성되지 않도록 처리.
            while (position_x * position_x + position_z * position_z < 16)
            {
                position_x = Random.Range(-10.0F, 10.0F);
                position_z = Random.Range(-10.0F, 10.0F);
            }
            //x, z좌표를 이용해 y좌표 생성.
            float position_y = Random.Range(1.0F, Mathf.Sqrt(position_x * position_x +
                                                             position_z * position_z)
                                                             / Mathf.Sqrt(3.0F));
            //결정된 좌표들을 이용해 이동.
            new_object.transform.position = new Vector3(position_x, position_y + 2,
                                                         position_z);
            //Object set에 추가.
            MainObjectScript.GameObjects.Add(new_object);
            MainObjectScript.ObjectCount += 1;
        }
    }
    public void GenerateBoss()
    {   // 보스의 생성을 담당하는 함수
        if (!BossObject.isAppear)
        {   // 보스가 맵에 없는 경우 생성
            GameObject new_object = Instantiate(boss_object);
            Boss = new_object;
            new_object.transform.localScale += new Vector3(0.01F * object_scale_count_,
                                                            0.01F * object_scale_count_,
                                                            0.01F * object_scale_count_);
            //x, z좌표 설정.
            float position_x = Random.Range(-10.0F, 10.0F);
            float position_z = Random.Range(-10.0F, 10.0F);
            //지정된 범위 내에서는 생성되지 않도록 처리.
            while (position_x * position_x + position_z * position_z < 16)
            {
                position_x = Random.Range(-10.0F, 10.0F);
                position_z = Random.Range(-10.0F, 10.0F);
            }
            //x, z좌표를 이용해 y좌표 생성.
            float position_y = Random.Range(1.0F, Mathf.Sqrt(position_x * position_x +
                                                             position_z * position_z)
                                                             / Mathf.Sqrt(3.0F));
            //결정된 좌표들을 이용해 이동.
            new_object.transform.position = new Vector3(position_x, position_y + 2,
                                                         position_z);
            //Object set에 추가.

            BossObject.isAppear = true;
        }
    }

}