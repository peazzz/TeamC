using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerDefense : MonoBehaviour
{
    public GameObject Shield1;
    public GameObject Shield2;
    public GameObject Shield3;
    public static int SpaceTime;
    private bool canDefense;
    public SpriteRenderer SR;
    private float _Blue_R;
    private float _Blue_G;
    private Color _Blue;

    public Text Combo_Text;
    public static float Combo;
    public GameObject Combo_object;

    public Slider PlayerHP;
    public Animator PlayerAnim;
    public Animator GameSceneAnim;
    public GameObject hit_audio;
    public GameObject Error_Audio;
    private bool Lock;
    public Animator Scene_anim;
    public GameObject _Space;
    public GameObject _Space2;
    public GameObject UIbar;
    private float EndAnimTime;
    public Animator Boss_anim;
    

    // Start is called before the first frame update
    void Start()
    {
        Shield1.SetActive(false);
        Shield2.SetActive(false);
        Shield3.SetActive(false);
        canDefense = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameManager.Win && Shield.ready && Input.GetKeyDown(KeyCode.Space))
        {
            GameManager.Win = true;
            _Space.SetActive(false);
            _Space2.SetActive(false);
            UIbar.SetActive(false);
            Shield1.SetActive(false);
            Shield2.SetActive(false);
            Shield3.SetActive(false);
            Combo_object.SetActive(false);
        }

        if (GameManager.Win)
        {
            End_Anim();
            EndAnimTime += Time.deltaTime;
        }

        if (!GameManager.Win)
        {
            if (Combo <= 0)
            {
                Combo_object.SetActive(false);
            }
            else
            {
                Combo_object.SetActive(true);
            }

            if (SpaceTime <= 0)
            {
                PlayerAnim.SetBool("defense", false);
            }
            else if (SpaceTime > 0)
            {
                PlayerAnim.SetBool("defense", true);
            }

            Combo_Text.text = Combo.ToString() + " Guard";

            _Blue = new Color(_Blue_R, _Blue_G, 1, 1);
            SR.color = _Blue;

            if (Input.GetKeyDown(KeyCode.Space) && canDefense && GameManager.Starting && GameManager.Tutorial_Finish)//正常運作
            {
                SpaceTime++;
                if (SpaceTime > 3)
                {
                    SpaceTime = 1;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Space) && canDefense && GameManager.Starting && !GameManager.Tutorial_Finish && GameManager.Tutorial1 && !GameManager.Tutorial2)//教學
            {
                if (SpaceTime < 1)
                {
                    SpaceTime++;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Space) && canDefense && GameManager.Starting && !GameManager.Tutorial_Finish && GameManager.Tutorial2 && !GameManager.Tutorial3)//教學
            {
                if (SpaceTime < 2)
                {
                    SpaceTime++;
                }
            }
            else if (Input.GetKeyDown(KeyCode.Space) && canDefense && GameManager.Starting && !GameManager.Tutorial_Finish && GameManager.Tutorial3)//教學
            {
                if (SpaceTime < 3)
                {
                    SpaceTime++;
                }
            }

            if (SpaceTime == 1)
            {
                Shield2.SetActive(false);
                Shield3.SetActive(false);
                Shield1.SetActive(true);
            }
            else if (SpaceTime == 2)
            {
                Shield2.SetActive(true);
                Shield1.SetActive(false);
                Shield3.SetActive(false);
            }
            else if (SpaceTime == 3)
            {
                Shield3.SetActive(true);
                Shield1.SetActive(false);
                Shield2.SetActive(false);
            }
        }
    }

    void End_Anim()
    {

        PlayerAnim.SetTrigger("boss1");
        if (EndAnimTime >= 3)
        {
            PlayerAnim.SetTrigger("boss2");
            GameSceneAnim.SetTrigger("end");
        }

        if (EndAnimTime >= 5.5f)
        {
            PlayerAnim.SetTrigger("boss3");
        }

        if (EndAnimTime >= 6)
        {
            Boss_anim.SetTrigger("dead");
        }

        if (EndAnimTime >= 8f)
        {
            SceneManager.LoadScene("EndScene");
        }
    }

    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!GameManager.Win)
        {
            if (other.gameObject.tag == "Bullet1" || other.gameObject.tag == "Bullet1_Last")
            {
                Destroy(other.gameObject);
                Instantiate(hit_audio, transform.position, transform.rotation);
                PlayerHP.value -= 0.1f;
                if (!Shield.Error)
                {
                    Instantiate(Error_Audio, transform.position, transform.rotation);
                    Shield.Error = true;
                }
                Scene_anim.SetBool("error", true);
            }
            else if (other.gameObject.tag == "Bullet2" || other.gameObject.tag == "Bullet2_Last")
            {
                Destroy(other.gameObject);
                Instantiate(hit_audio, transform.position, transform.rotation);
                PlayerHP.value -= 0.1f;
                if (!Shield.Error)
                {
                    Instantiate(Error_Audio, transform.position, transform.rotation);
                    Shield.Error = true;
                }
                Scene_anim.SetBool("error", true);
            }
            else if (other.gameObject.tag == "Bullet3" || other.gameObject.tag == "Bullet3_Last")
            {
                Destroy(other.gameObject);
                Instantiate(hit_audio, transform.position, transform.rotation);
                PlayerHP.value -= 0.1f;
                if (!Shield.Error)
                {
                    Instantiate(Error_Audio, transform.position, transform.rotation);
                    Shield.Error = true;
                }
                Scene_anim.SetBool("error", true);
            }
        }

        if (other.gameObject.tag == "Bullet1_Last" || other.gameObject.tag == "Bullet2_Last" || other.gameObject.tag == "Bullet3_Last")
        {
            BossAttack.BulletCount = 0;
        }
    }
}
