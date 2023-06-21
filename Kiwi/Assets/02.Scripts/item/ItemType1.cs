using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemType1 : MonoBehaviour
{
    bool kick = false;
    float timer = 0.3f;
    void OnEnable()
    {
        Kick();
    }
    private void FixedUpdate()
    {
        if (kick == true)
        {
            timer -= Time.fixedDeltaTime;
        }
    }
    private void Update()
    {
        if(kick == true && timer < 0)
        {
            transform.Rotate(new Vector3(0, 0, 400) * Time.deltaTime);
        }
    }
    void Kick()
    {
        this.transform.DOMoveX(-5, 2.0f).SetDelay(0.3f);
        kick = true;
    }
    private void OnDisable()
    {
        this.transform.DOMoveX(0, 0.0f);
        kick = false;
        timer = 0.3f;
    }
}
