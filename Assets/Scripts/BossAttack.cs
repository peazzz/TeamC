using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject bullet3;
    public GameObject bullet1_Last;
    public GameObject bullet2_Last;
    public GameObject bullet3_Last;
    private int RandomBullet;
    private float interval;
    private bool isAttack;
    public static int BulletCount;

    //±Ð¾Ç
    private bool T1_bullet;
    private bool T2_bullet;
    private bool T3_bullet;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Starting && GameManager.Tutorial_Finish)
        {
            if (BulletCount < 3)
            {
                _Attack();
                isAttack = true;
            }
            else
            {
                isAttack = false;
                interval = 0;
            }
        }
        else if (GameManager.Starting && !GameManager.Tutorial_Finish && !T1_bullet)
        {
            if (GameManager.Tutorial1 && !T1_bullet)
            {
                Instantiate(bullet1, transform.position, transform.rotation);
                T1_bullet = true;
            }
        }
        else if (GameManager.Starting && !GameManager.Tutorial_Finish && !T2_bullet)
        {
            if (GameManager.Tutorial2 && !T2_bullet && PlayerDefense.SpaceTime == 2)
            {
                Instantiate(bullet2, transform.position, transform.rotation);
                T2_bullet = true;
            }
        }
        else if (GameManager.Starting && !GameManager.Tutorial_Finish && !T3_bullet)
        {
            if (GameManager.Tutorial3 && !T3_bullet && PlayerDefense.SpaceTime == 3)
            {
                Instantiate(bullet3, transform.position, transform.rotation);
                T3_bullet = true;
            }
        }
    }

    void _Attack()
    {
        interval -= Time.deltaTime;

        if (interval <= 0 && isAttack)
        {
            RandomBullet = Random.Range(1, 4);
            if (RandomBullet == 1)
            {
                if (BulletCount < 2)
                {
                    Instantiate(bullet1, transform.position, transform.rotation);
                }
                else
                {
                    Instantiate(bullet1_Last, transform.position, transform.rotation);
                }
                interval = 0.7f;
                BulletCount++;
            }
            else if (RandomBullet == 2)
            {
                if (BulletCount < 2)
                {
                    Instantiate(bullet2, transform.position, transform.rotation);
                }
                else
                {
                    Instantiate(bullet2_Last, transform.position, transform.rotation);
                }
                interval = 1.2f;
                BulletCount++;
            }
            else if (RandomBullet == 3)
            {
                if (BulletCount < 2)
                {
                    Instantiate(bullet3, transform.position, transform.rotation);
                }
                else
                {
                    Instantiate(bullet3_Last, transform.position, transform.rotation);
                }
                interval = 1.7f;
                BulletCount++;
            }
        }
    }
}
