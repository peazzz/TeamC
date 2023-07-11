using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool Starting;
    public static bool Tutorial1;
    public static bool Tutorial2;
    public static bool Tutorial3;
    public static bool Tutorial_Finish;
    public GameObject StartButton;
    public GameObject StartScene;
    public GameObject Tutorial1_Text;
    public GameObject Tutorial1_Text_O;
    public Animator anim;
    private float AnimTime;
    private bool Anim_start;
    private bool Anim_next;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Starting && !Anim_next)
        {
            AnimTime += Time.deltaTime;
            if (!Anim_start)
            {
                anim.SetTrigger("start");
                Anim_start = true;
            }

            if (AnimTime > 3 && !Anim_next)
            {
                anim.SetTrigger("next");
                Anim_next = true;
                Tutorial1_Text.SetActive(true);
                Tutorial1_Text_O.SetActive(true);
            }
        }

        if (Anim_next)//教學開始
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Tutorial1 = true;
                Tutorial1_Text.SetActive(false);
                Tutorial1_Text_O.SetActive(false);
            }
        }
    }

    public void _Start()
    {
        Starting = true;
        StartButton.SetActive(false);
        StartScene.SetActive(false);
    }
}
