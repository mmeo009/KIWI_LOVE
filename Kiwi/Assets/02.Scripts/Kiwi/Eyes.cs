using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    protected GameManager GameManager => GameManager.Instance;
    public GameObject[] eyes;
    public float blinkTimer = 0.2f;
    public int eyeType = 0;
    public bool isClose = false;
    void Awake()
    {
        eyes = GameObject.FindGameObjectsWithTag("Eyes"); //�� �ױװ� �ִ� ģ������ ��� ã�� ����
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
        switch(GameManager.kiwi.count)
        {
            case 0:
                eyeType = 0; 
                break;
            case 1:
                eyeType = 1; 
                break;
            case 2:
                eyeType = 2;
                break;
        }
        blinkTimer -= Time.fixedDeltaTime; // �� Ÿ�̸�
        if(blinkTimer <= 0)
        {
            Blink(); //�� ������ ����
        }
    }
    void Update()
    {
        
    }
    public void Blink()
    {
        for (int i = 0; i < eyes.Length; i++) 
        {
            eyes[i].gameObject.active = false;
        } //�ϴ� �� �� ����
        if (isClose == false)
        {
            eyes[1].gameObject.active = true;
            isClose = true;
            blinkTimer = 0.1f;
        } // ���� ���� �������� �� ����
        else
        {
            switch (eyeType)
            {
                case 0:
                    eyes[0].gameObject.active = true;
                    break;
                case 1:
                    eyes[4].gameObject.active = true;
                    break;
                case 2:
                    eyes[5].gameObject.active = true;
                    break;
                case 3:
                    eyes[6].gameObject.active = true;
                    break;
            }
            isClose = false;
            blinkTimer = Random.Range(0.2f, 1.0f);
        } // ���� ���� ���� ������ �� �߱�

    }
}
