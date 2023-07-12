using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditScroller : MonoBehaviour
{
    public float scrollSpeed = 100.0f;
    private RectTransform rectTransform;
    private Text creditText;

    private void Start()
    {
        
        rectTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        // Move the credit text upwards
        rectTransform.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;

        // Reset the position once the text goes off-screen
        // if (rectTransform.anchoredPosition.y > Screen.height)
        if (rectTransform.anchoredPosition.y > 5000f)
        {
            Application.Quit();
            //rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, -Screen.height);
        }
    }
}
