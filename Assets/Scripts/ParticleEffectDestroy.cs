using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffectDestroy : MonoBehaviour
{
    private float particleSystemTime;

    private void Start()
    {
        particleSystemTime = 3;
    }

    private void Update()
    {
        particleSystemTime -= Time.deltaTime;
        if (particleSystemTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
