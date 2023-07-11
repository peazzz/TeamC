using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    private string BTag;
    // Start is called before the first frame update
    void Start()
    {
        BTag = gameObject.tag;
        if(BTag == "Bullet1_Last") BTag = "Bullet1";
        else if(BTag == "Bullet2_Last") BTag = "Bullet2";
        else if(BTag == "Bullet3_Last") BTag = "Bullet3";
        // Debog.Log(BTag);
    }

    // Update is called once per frame
    void Update()
    {
    }
    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("collide");
        int col_type=0;
        if(other.CompareTag("Shield1")){
            col_type=1;
        }
        else if(other.CompareTag("Shield2")){
            col_type=2;
        }
        else if(other.CompareTag("Shield3")){
            col_type=3;
        }
        else if(other.CompareTag("Player")){
            col_type=4;
        }
        if(BTag == "Bullet1"){
            if(col_type>=1) Destroy(gameObject);
        }
        else if(BTag == "Bullet2"){
            if(col_type>=2) Destroy(gameObject);
        }
        else if(BTag == "Bullet3"){
            if(col_type>=3) Destroy(gameObject);
        }
    }
}
