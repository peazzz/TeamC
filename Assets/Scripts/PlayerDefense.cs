using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public Slider PlayerHP;

    private bool Lock;

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
        Combo_Text.text = Combo.ToString() + " Guard";

        _Blue = new Color(_Blue_R, _Blue_G, 1, 1);
        SR.color = _Blue;

        if (Input.GetKeyDown(KeyCode.Space) && canDefense && GameManager.Starting && GameManager.Tutorial_Finish)
        {
            SpaceTime++;
            if (SpaceTime > 3)
            {
                SpaceTime = 1;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) && canDefense && GameManager.Starting && !GameManager.Tutorial_Finish && GameManager.Tutorial1 && !GameManager.Tutorial2)
        {
            if (SpaceTime < 1)
            {
                SpaceTime ++;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) && canDefense && GameManager.Starting && !GameManager.Tutorial_Finish && GameManager.Tutorial2 && !GameManager.Tutorial3)
        {
            if (SpaceTime < 2)
            {
                SpaceTime++;
            }
        }
        else if (Input.GetKeyDown(KeyCode.Space) && canDefense && GameManager.Starting && !GameManager.Tutorial_Finish && GameManager.Tutorial3)
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

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Bullet1" || other.gameObject.tag == "Bullet1_Last")
        {
            PlayerHP.value -= 0.1f;
        }
        else if (other.gameObject.tag == "Bullet2" || other.gameObject.tag == "Bullet2_Last")
        {
            PlayerHP.value -= 0.1f;
        }
        else if (other.gameObject.tag == "Bullet3" || other.gameObject.tag == "Bullet3_Last")
        {
            PlayerHP.value -= 0.1f;
        }

        if (other.gameObject.tag == "Bullet1_Last" || other.gameObject.tag == "Bullet2_Last" || other.gameObject.tag == "Bullet3_Last")
        {
            BossAttack.BulletCount = 0;
        }
    }
}
