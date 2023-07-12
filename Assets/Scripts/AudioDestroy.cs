using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioDestroy : MonoBehaviour
{
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlaySoundEffect();
    }

    private void PlaySoundEffect()
    {
        Invoke("DestroySoundEffect", audioSource.clip.length);
    }

    private void DestroySoundEffect()
    {
        Destroy(gameObject);
    }
}
