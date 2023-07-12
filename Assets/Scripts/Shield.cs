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

    public static bool Defence1;
    public static bool Defence2;
    public static bool Defence3;

    public GameObject Sheld1;
    public GameObject Sheld2;
    public GameObject Sheld3;

    public static bool Error;
    public Animator Scene_anim;
    public Animator Combo_anim;
    public GameObject UIbar;

    public GameObject Good_Audio;
    public GameObject Good2_Audio;
    public GameObject Error_Audio;
    public GameObject Shield_Audio;
    public Animator PlayerAnim;
    private int RandomAudio;
    public GameObject _Space;
    public GameObject _Space2;
    public static bool ready;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _Win();
        RandomAudio = Random.Range(1, 3);
    }

    void _Win()
    {
        if (ChargeBar.value >= 1 && !ready)
        {
            _Space.SetActive(true);
            _Space2.SetActive(true);
            ready = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!GameManager.Win)
        {
            if (other.gameObject.tag == "Bullet1" || other.gameObject.tag == "Bullet2" || other.gameObject.tag == "Bullet3" || other.gameObject.tag == "Bullet1_Last" || other.gameObject.tag == "Bullet2_Last" || other.gameObject.tag == "Bullet3_Last")
            {
                Sheld1.SetActive(false);
                Sheld2.SetActive(false);
                Sheld3.SetActive(false);
                PlayerDefense.SpaceTime = 0;
            }


            if (other.gameObject.tag == "Bullet1")
            {
                if (Shield1)
                {
                    Instantiate(Shield_Audio, transform.position, transform.rotation);
                    if (!Error)
                    {
                        if (RandomAudio == 1)
                        {
                            Instantiate(Good_Audio, transform.position, transform.rotation);
                        }
                        else if (RandomAudio == 2)
                        {
                            Instantiate(Good2_Audio, transform.position, transform.rotation);
                        }
                        Scene_anim.SetTrigger("good");
                    }
                    else
                    {
                        Error = false;
                        Scene_anim.SetBool("error", false);
                    }
                    Destroy(other.gameObject);
                    ChargeBar.value += 0.04f * (1 + (PlayerDefense.Combo / 20));
                    PlayerDefense.Combo += 1;
                    if (PlayerDefense.Combo >= 5 && PlayerDefense.Combo < 10)
                    {
                        Combo_anim.SetTrigger("combo1");
                    }
                    else if (PlayerDefense.Combo >= 10)
                    {
                        Combo_anim.SetTrigger("combo2");
                    }

                    if (GameManager.Tutorial1 && !GameManager.Tutorial2)
                    {
                        GameManager.Tutorial2 = true;
                        Defence1 = true;
                    }
                }
                else if (Shield2 || Shield3)
                {
                    if (!Error)
                    {
                        Instantiate(Error_Audio, transform.position, transform.rotation);
                    }
                    Scene_anim.SetBool("error", true);
                    Error = true;
                    PlayerDefense.Combo = 0;
                }
            }
            else if (other.gameObject.tag == "Bullet2")
            {
                if (Shield2)
                {
                    Instantiate(Shield_Audio, transform.position, transform.rotation);
                    if (!Error)
                    {
                        if (RandomAudio == 1)
                        {
                            Instantiate(Good_Audio, transform.position, transform.rotation);
                        }
                        else if (RandomAudio == 2)
                        {
                            Instantiate(Good2_Audio, transform.position, transform.rotation);
                        }
                        Scene_anim.SetTrigger("good");
                    }
                    else
                    {
                        Error = false;
                        Scene_anim.SetBool("error", false);
                    }
                    Destroy(other.gameObject);
                    ChargeBar.value += 0.04f * (1 + (PlayerDefense.Combo / 20));
                    PlayerDefense.Combo += 1;
                    if (PlayerDefense.Combo >= 5 && PlayerDefense.Combo < 10)
                    {
                        Combo_anim.SetTrigger("combo1");
                    }
                    else if (PlayerDefense.Combo >= 10)
                    {
                        Combo_anim.SetTrigger("combo2");
                    }

                    if (GameManager.Tutorial2 && !GameManager.Tutorial3)
                    {
                        GameManager.Tutorial3 = true;
                        Defence2 = true;
                    }
                }
                else if (Shield3 || Shield1)
                {
                    if (!Error)
                    {
                        Instantiate(Error_Audio, transform.position, transform.rotation);
                    }
                    Scene_anim.SetBool("error", true);
                    Error = true;
                    PlayerDefense.Combo = 0;
                }
            }
            else if (other.gameObject.tag == "Bullet3")
            {
                if (Shield3)
                {
                    Instantiate(Shield_Audio, transform.position, transform.rotation);
                    if (!Error)
                    {
                        if (RandomAudio == 1)
                        {
                            Instantiate(Good_Audio, transform.position, transform.rotation);
                        }
                        else if (RandomAudio == 2)
                        {
                            Instantiate(Good2_Audio, transform.position, transform.rotation);
                        }
                        Scene_anim.SetTrigger("good");
                    }
                    else
                    {
                        Error = false;
                        Scene_anim.SetBool("error", false);
                    }
                    Destroy(other.gameObject);
                    ChargeBar.value += 0.04f * (1 + (PlayerDefense.Combo / 20));
                    PlayerDefense.Combo += 1;
                    if (PlayerDefense.Combo >= 5 && PlayerDefense.Combo < 10)
                    {
                        Combo_anim.SetTrigger("combo1");
                    }
                    else if (PlayerDefense.Combo >= 10)
                    {
                        Combo_anim.SetTrigger("combo2");
                    }

                    if (GameManager.Tutorial3 && !GameManager.Tutorial_Finish)
                    {
                        Defence3 = true;
                        UIbar.SetActive(true);
                    }
                }
                else if (Shield1 || Shield2)
                {
                    if (!Error)
                    {
                        Instantiate(Error_Audio, transform.position, transform.rotation);
                    }
                    Scene_anim.SetBool("error", true);
                    Error = true;
                    PlayerDefense.Combo = 0;
                }
            }
            else if (other.gameObject.tag == "Bullet1_Last")
            {
                if (Shield1)
                {
                    Instantiate(Shield_Audio, transform.position, transform.rotation);
                    if (!Error)
                    {
                        if (RandomAudio == 1)
                        {
                            Instantiate(Good_Audio, transform.position, transform.rotation);
                        }
                        else if (RandomAudio == 2)
                        {
                            Instantiate(Good2_Audio, transform.position, transform.rotation);
                        }
                        Scene_anim.SetTrigger("good");
                    }
                    else
                    {
                        Error = false;
                        Scene_anim.SetBool("error", false);
                    }
                    Destroy(other.gameObject);
                    ChargeBar.value += 0.04f * (1 + (PlayerDefense.Combo / 20));
                    PlayerDefense.Combo += 1;
                    if (PlayerDefense.Combo >= 5 && PlayerDefense.Combo < 10)
                    {
                        Combo_anim.SetTrigger("combo1");
                    }
                    else if (PlayerDefense.Combo >= 10)
                    {
                        Combo_anim.SetTrigger("combo2");
                    }
                }
                else if (Shield2 || Shield3)
                {
                    if (!Error)
                    {
                        Instantiate(Error_Audio, transform.position, transform.rotation);
                    }
                    Scene_anim.SetBool("error", true);
                    Error = true;
                    PlayerDefense.Combo = 0;
                }
                BossAttack.BulletCount = 0;
            }
            else if (other.gameObject.tag == "Bullet2_Last")
            {
                if (Shield2)
                {
                    Instantiate(Shield_Audio, transform.position, transform.rotation);
                    if (!Error)
                    {
                        if (RandomAudio == 1)
                        {
                            Instantiate(Good_Audio, transform.position, transform.rotation);
                        }
                        else if (RandomAudio == 2)
                        {
                            Instantiate(Good2_Audio, transform.position, transform.rotation);
                        }
                        Scene_anim.SetTrigger("good");
                    }
                    else
                    {
                        Error = false;
                        Scene_anim.SetBool("error", false);
                    }
                    Destroy(other.gameObject);
                    ChargeBar.value += 0.04f * (1 + (PlayerDefense.Combo / 20));
                    PlayerDefense.Combo += 1;
                    if (PlayerDefense.Combo >= 5 && PlayerDefense.Combo < 10)
                    {
                        Combo_anim.SetTrigger("combo1");
                    }
                    else if (PlayerDefense.Combo >= 10)
                    {
                        Combo_anim.SetTrigger("combo2");
                    }
                }
                else if (Shield3 || Shield1)
                {
                    if (!Error)
                    {
                        Instantiate(Error_Audio, transform.position, transform.rotation);
                    }
                    Scene_anim.SetBool("error", true);
                    Error = true;
                    PlayerDefense.Combo = 0;
                }
                BossAttack.BulletCount = 0;
            }
            else if (other.gameObject.tag == "Bullet3_Last")
            {
                if (Shield3)
                {
                    Instantiate(Shield_Audio, transform.position, transform.rotation);
                    if (!Error)
                    {
                        if (RandomAudio == 1)
                        {
                            Instantiate(Good_Audio, transform.position, transform.rotation);
                        }
                        else if (RandomAudio == 2)
                        {
                            Instantiate(Good2_Audio, transform.position, transform.rotation);
                        }
                        Scene_anim.SetTrigger("good");
                    }
                    else
                    {
                        Error = false;
                        Scene_anim.SetBool("error", false);
                    }
                    Destroy(other.gameObject);
                    ChargeBar.value += 0.04f * (1 + (PlayerDefense.Combo / 20));
                    PlayerDefense.Combo += 1;
                    if (PlayerDefense.Combo >= 5 && PlayerDefense.Combo < 10)
                    {
                        Combo_anim.SetTrigger("combo1");
                    }
                    else if (PlayerDefense.Combo >= 10)
                    {
                        Combo_anim.SetTrigger("combo2");
                    }
                }
                else if (Shield1 || Shield2)
                {
                    if (!Error)
                    {
                        Instantiate(Error_Audio, transform.position, transform.rotation);
                    }
                    Scene_anim.SetBool("error", true);
                    Error = true;
                    PlayerDefense.Combo = 0;
                }
                BossAttack.BulletCount = 0;
            }
        }
    }
}
