using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool Starting;
    public static bool Tutorial1;
    public static bool Tutorial2;
    public static bool Tutorial3;
    public static bool Tutorial_Finish;
    public GameObject StartScene;
    public GameObject Traning_Text;
    public GameObject Hint_Text;
    public GameObject Tutorial1_Text;
    public GameObject Tutorial2_Text;
    public GameObject Tutorial3_Text;
    public Animator anim;
    private float AnimTime;
    private bool Anim_start;
    private bool Anim_next;
    private bool menu;
    private float menuTime;
    public GameObject MenuScene;
    public GameObject MenuStart;

    private Color _Black;
    public Image EndScene;
    public GameObject _TobeContinue;
    private float EndTime;
    public GameObject PlayerModel;
    public GameObject Fire1;
    public GameObject Fire2;
    // Start is called before the first frame update
    void Start()
    {
        _Black = new Color(0, 0, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Space) && !menu)
        {
            _MenuStart();
        }

        if (menu)//算是Debug用
        {
            menuTime += Time.deltaTime;
            if (menuTime > 0.2f)
            {
                menuTime = 0.2f;
            }
        }

        _Start();
        _End();

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
            }
        }

        if (Anim_next)//教學開始
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Tutorial1 = true;
                Tutorial1_Text.SetActive(false);
                if (PlayerDefense.SpaceTime < 1)
                {
                    PlayerDefense.SpaceTime++;
                }
            }

            if (Shield.Defence1 && Tutorial1 && !Shield.Defence2)
            {                              
                if (PlayerDefense.SpaceTime == 2)
                {
                    Tutorial2_Text.SetActive(false);
                }
                else
                {
                    Tutorial2_Text.SetActive(true);
                }
            }

            if (Shield.Defence2 && Tutorial2 && !Shield.Defence3)
            {
                if (PlayerDefense.SpaceTime == 3)
                {
                    Tutorial3_Text.SetActive(false);
                }
                else
                {
                    Tutorial3_Text.SetActive(true);
                }
            }
        }
    }

    public void _MenuStart()
    {       
        menu = true;
        MenuScene.SetActive(false);
        MenuStart.SetActive(false);
    }

    public void _Start()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !Starting && menuTime>=0.2f)
        {
            Starting = true;
        }
    }

    public void StartAnim()
    {
        StartScene.SetActive(false);
        Traning_Text.SetActive(false);
        Hint_Text.SetActive(false);
    }

    void _End()
    {
        if (Shield.Defence3)
        {
            EndScene.color = Color.Lerp(EndScene.color, _Black, 0.05f);
            EndTime += Time.deltaTime;
            if (EndTime > 1)
            {
                _TobeContinue.SetActive(true);
                PlayerModel.SetActive(true);
                Fire1.SetActive(false);
                Fire2.SetActive(false);
            }
        }
    }
}
