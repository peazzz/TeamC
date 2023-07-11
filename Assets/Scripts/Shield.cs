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
    public GameObject ShieldBroken;
    public GameObject _Shield1;
    public GameObject _Shield2;
    public GameObject _Shield3;

    public static bool Defence1;
    public static bool Defence2;
    public static bool Defence3;


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
                ChargeBar.value += 0.02f * (1 + (PlayerDefense.Combo/20));
                PlayerDefense.Combo += 1;
                if (GameManager.Tutorial1 && !GameManager.Tutorial2)
                {
                    _Shield1.SetActive(false);
                    PlayerDefense.SpaceTime = 0;
                    GameManager.Tutorial2 = true;
                    Defence1 = true;
                }
            }
            else if (Shield2)
            {
                Destroy(other.gameObject);
                ChargeBar.value += 0.03f * (1 + (PlayerDefense.Combo / 20));
                PlayerDefense.Combo += 1;
                _Shield2.SetActive(false);
            }
            else if (Shield3)
            {
                Destroy(other.gameObject);
                ChargeBar.value += 0.05f * (1 + (PlayerDefense.Combo / 20));
                PlayerDefense.Combo += 1;
                _Shield3.SetActive(false);
            }
        }
        else if (other.gameObject.tag == "Bullet2")
        {
            if (Shield2)
            {
                Destroy(other.gameObject);
                ChargeBar.value += 0.03f * (1 + (PlayerDefense.Combo / 20));
                PlayerDefense.Combo += 1;
                if (GameManager.Tutorial2 && !GameManager.Tutorial3)
                {
                    PlayerDefense.SpaceTime = 0;
                    GameManager.Tutorial3 = true;
                    Defence2 = true;
                    _Shield2.SetActive(false);
                }
            }
            else if (Shield3)
            {
                Destroy(other.gameObject);
                ChargeBar.value += 0.05f * (1 + (PlayerDefense.Combo / 20));
                PlayerDefense.Combo += 1;
                _Shield3.SetActive(false);
            }
            else if (Shield1)
            {
                PlayerDefense.SpaceTime = 0;
                _Shield1.SetActive(false);
                _Shield2.SetActive(false);
                _Shield3.SetActive(false);
                Instantiate(ShieldBroken, transform.position, transform.rotation);
                PlayerDefense.Combo = 0;
                _Shield1.SetActive(false);
            }
        }
        else if (other.gameObject.tag == "Bullet3")
        {
            if (Shield3)
            {
                Destroy(other.gameObject);
                ChargeBar.value += 0.05f * (1 + (PlayerDefense.Combo / 20));
                PlayerDefense.Combo += 1;
                if (GameManager.Tutorial3 && !GameManager.Tutorial_Finish)
                {
                    PlayerDefense.SpaceTime = 0;
                    Defence3 = true;
                    _Shield3.SetActive(false);
                }
            }
            else if(Shield1 || Shield2)
            {
                PlayerDefense.SpaceTime = 0;
                _Shield1.SetActive(false);
                _Shield2.SetActive(false);
                _Shield3.SetActive(false);
                Instantiate(ShieldBroken, transform.position, transform.rotation);
                PlayerDefense.Combo = 0;
                _Shield1.SetActive(false);
                _Shield2.SetActive(false);
            }
        }
        else if (other.gameObject.tag == "Bullet1_Last")
        {
            if (Shield1)
            {
                Destroy(other.gameObject);
                ChargeBar.value += 0.02f * (1 + (PlayerDefense.Combo / 20));
                PlayerDefense.Combo += 1;
            }
            else if (Shield2)
            {
                Destroy(other.gameObject);
                ChargeBar.value += 0.03f * (1 + (PlayerDefense.Combo / 20));
                PlayerDefense.Combo += 1;
            }
            else if (Shield3)
            {
                Destroy(other.gameObject);
                ChargeBar.value += 0.05f * (1 + (PlayerDefense.Combo / 20));
                PlayerDefense.Combo += 1;
            }
            BossAttack.BulletCount = 0;
        }
        else if (other.gameObject.tag == "Bullet2_Last")
        {
            if (Shield2)
            {
                Destroy(other.gameObject);
                ChargeBar.value += 0.03f * (1 + (PlayerDefense.Combo / 20));
                PlayerDefense.Combo += 1;
            }
            else if (Shield3)
            {
                Destroy(other.gameObject);
                ChargeBar.value += 0.05f * (1 + (PlayerDefense.Combo / 20));
                PlayerDefense.Combo += 1;
            }
            else if(Shield1)
            {
                PlayerDefense.SpaceTime = 0;
                _Shield1.SetActive(false);
                _Shield2.SetActive(false);
                _Shield3.SetActive(false);
                Instantiate(ShieldBroken, transform.position, transform.rotation);
                PlayerDefense.Combo = 0;
            }
            BossAttack.BulletCount = 0;
        }
        else if (other.gameObject.tag == "Bullet3_Last")
        {
            if (Shield3)
            {
                Destroy(other.gameObject);
                ChargeBar.value += 0.05f * (1 + (PlayerDefense.Combo / 20));
                PlayerDefense.Combo += 1;
            }
            else if(Shield1 || Shield2)
            {
                PlayerDefense.SpaceTime = 0;
                _Shield1.SetActive(false);
                _Shield2.SetActive(false);
                _Shield3.SetActive(false);
                Instantiate(ShieldBroken, transform.position, transform.rotation);
                PlayerDefense.Combo = 0;
            }
            BossAttack.BulletCount = 0;
        }
    }
}
