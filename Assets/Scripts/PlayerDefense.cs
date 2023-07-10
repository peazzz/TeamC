using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDefense : MonoBehaviour
{
    public GameObject Shield1;
    public GameObject Shield2;
    public GameObject Shield3;
    private int SpaceTime;
    public static float CD;
    private bool canDefense;
    public SpriteRenderer SR;
    private float _Red_G;
    private float _Red_B;
    private Color _Red;

    public Slider PlayerHP;

    // Start is called before the first frame update
    void Start()
    {
        Shield1.SetActive(false);
        Shield2.SetActive(false);
        Shield3.SetActive(false);
        canDefense = true;
        CD = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _Red_G = 1-(CD/1.2f);
        _Red_B = 1-(CD/1.2f);
        _Red = new Color(1, _Red_G, _Red_B, 1);
        SR.color = _Red;

        if (CD <= 0)
        {
            canDefense = true;
            CD = 0;
        }
        else
        {
            CD -= Time.deltaTime;
            canDefense = false;

            SpaceTime = 0;
            Shield1.SetActive(false);
            Shield2.SetActive(false);
            Shield3.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && canDefense)
        {
            SpaceTime++;
        }

        if (SpaceTime == 1)
        {
            Shield1.SetActive(true);
        }
        else if (SpaceTime == 2)
        {
            Shield2.SetActive(true);
            Shield1.SetActive(false);
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
            PlayerHP.value -= 0.05f;
        }
        else if (other.gameObject.tag == "Bullet2" || other.gameObject.tag == "Bullet2_Last")
        {
            PlayerHP.value -= 0.1f;
        }
        else if (other.gameObject.tag == "Bullet3" || other.gameObject.tag == "Bullet3_Last")
        {
            PlayerHP.value -= 0.15f;
        }
    }
}
