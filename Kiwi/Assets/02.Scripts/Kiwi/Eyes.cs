using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    public GameObject[] eyes;
    public float blinkTimer = 0.2f;
    public bool isClose = false;
    void Awake()
    {
        eyes = GameObject.FindGameObjectsWithTag("Eyes");
        GameObject[] temp = eyes;
        for (int i = 0; i < eyes.Length; i++)
        {
            string name = temp[i].name.ToString();
            if (name.Contains(i.ToString()))
            {
                eyes[i] = temp[i];
            }
        }
        // ���� ���� ���� Ȥ�� ����

        for(int j = 1; j < eyes.Length; j++)
        {
            eyes[j].gameObject.active = false;
        }
        // �� �ϳ����� �� ����
    }
    private void FixedUpdate()
    {
        blinkTimer -= Time.fixedDeltaTime;
        if(blinkTimer <= 0)
        {
            Blink();
        }
    }
    void Update()
    {
        
    }
    public void Blink()
    {
        for (int j = 0; j < eyes.Length; j++)
        {
            eyes[j].gameObject.active = false;
        }
        if (isClose == false)
        {
            eyes[1].gameObject.active = true;
            isClose = true;
            blinkTimer = 0.1f;
        }
        else
        {
            eyes[0].gameObject.active = true;
            isClose = false;
            blinkTimer = Random.Range(0.2f, 1.0f);
        }

    }
}
