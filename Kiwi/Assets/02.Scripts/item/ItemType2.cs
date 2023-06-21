using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using DG.Tweening;
using Random = UnityEngine.Random;

public class ItemType2 : MonoBehaviour
{
    float timer = 0.3f;
    void OnEnable()
    {
        if(this.gameObject.tag == "Brush")
        {
            Brush(Random.Range(0.3f, 1f));
        }
        else if(this.gameObject.tag == "Water")
        {
            Water();
        }
        else if(this.gameObject.tag == "Fan")
        {
            Fan(Random.Range(-180,180));
        }
    }
    void Brush(float speed)
    {
        float loopTime = 3 / speed;
        this.transform.DOMove(new Vector3(1, 1, 0), speed).SetLoops((int)loopTime, LoopType.Yoyo);
    }    
    void Water()
    {
        this.transform.DOMoveY(0, 2);
    }
    void Fan(int amount)
    {
            this.transform.DORotate(new Vector3(0, 0, amount), 2.8f);
    }
    void Back()
    {
        if (this.gameObject.tag == "Water")
        {
            this.transform.DOMoveY(-5, 0);
        }
        else if(this.gameObject.tag == "Brush")
        {
            this.transform.DOMove(new Vector3(1.62f,-0.17f,0f), 0);
        }
        else if(this.gameObject.tag == "Fan")
        {
            this.transform.DORotate(new Vector3(0, 0, 0), 0);
        }
    }
    private void OnDisable()
    {
        Back();
        timer = 0.3f;
    }
}
