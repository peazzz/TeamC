using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlay : MonoBehaviour
{
    public AudioSource soundSource;
    void Start()
    {
       soundSource.Play(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
