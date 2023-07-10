using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shield : MonoBehaviour
{
    public Slider ChargeBar;
    public bool Shield1;
    public bool Shield2;
    public bool Shield3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet1")
        {
            if (Shield1)
            {
                Destroy(other.gameObject);
                PlayerDefense.CD = 0.2f;
                ChargeBar.value += 0.02f;
            }
            else if (Shield2)
            {
                Destroy(other.gameObject);
                PlayerDefense.CD = 0.7f;
                ChargeBar.value += 0.03f;
            }
            else if (Shield3)
            {
                Destroy(other.gameObject);
                PlayerDefense.CD = 1.2f;
                ChargeBar.value += 0.05f;
            }
        }
        else if (other.gameObject.tag == "Bullet2")
        {
            if (Shield2)
            {
                Destroy(other.gameObject);
                PlayerDefense.CD = 0.7f;
                ChargeBar.value += 0.03f;
            }
            else if (Shield3)
            {
                Destroy(other.gameObject);
                PlayerDefense.CD = 1.2f;
                ChargeBar.value += 0.05f;
            }
        }
        else if (other.gameObject.tag == "Bullet3")
        {
            if (Shield3)
            {
                Destroy(other.gameObject);
                PlayerDefense.CD = 1.2f;
                ChargeBar.value += 0.05f;
            }
        }
        else if (other.gameObject.tag == "Bullet1_Last")
        {
            if (Shield1)
            {
                Destroy(other.gameObject);
                PlayerDefense.CD = 0.2f;
                ChargeBar.value += 0.02f;
            }
            else if (Shield2)
            {
                Destroy(other.gameObject);
                PlayerDefense.CD = 0.7f;
                ChargeBar.value += 0.03f;
            }
            else if (Shield3)
            {
                Destroy(other.gameObject);
                PlayerDefense.CD = 1.2f;
                ChargeBar.value += 0.05f;
            }
            BossAttack.BulletCount = 0;
        }
        else if (other.gameObject.tag == "Bullet2_Last")
        {
            if (Shield2)
            {
                Destroy(other.gameObject);
                PlayerDefense.CD = 0.7f;
                ChargeBar.value += 0.03f;
            }
            else if (Shield3)
            {
                Destroy(other.gameObject);
                PlayerDefense.CD = 1.2f;
                ChargeBar.value += 0.05f;
            }
            BossAttack.BulletCount = 0;
        }
        else if (other.gameObject.tag == "Bullet3_Last")
        {
            if (Shield3)
            {
                Destroy(other.gameObject);
                PlayerDefense.CD = 1.2f;
                ChargeBar.value += 0.05f;
            }
            BossAttack.BulletCount = 0;
        }
    }
}
