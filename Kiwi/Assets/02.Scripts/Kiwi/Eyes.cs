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
    Animator anim;
    /*void Awake()
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
    }*/ // ����� �������� ����
    private void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Kiwi").GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if(GameManager.kiwi.maxExp <= GameManager.kiwi.KiwiExp) // ������ ��
        {
            eyeType = 5;
        }
        else if (anim.GetBool("Play") == true) // �
        {
            eyeType = 4;
        }
        else if(anim.GetBool("Eat") == true) // ������
        {
            eyeType = 6;
        }    
        else if(anim.GetBool("Clean") == true) // ������
        {
            eyeType = 7;
        }
        else
        {
            switch (GameManager.kiwi.count) // Ű���� ���¿� ����
            {
                case 0: // ��ġ 3�� 0�϶�
                    eyeType = 0;
                    break;
                case 1: // ��ġ 1�� 0�϶�
                    eyeType = 1;
                    break;
                case 2: // ��ġ 2�� 0�϶�
                    eyeType = 2;
                    break;
                case 3: // ��ġ 3�� 0�϶�
                    eyeType = 3;
                    break;
            }
        }
        blinkTimer -= Time.fixedDeltaTime; // �� Ÿ�̸�
        if(blinkTimer <= 0)
        {
            Blink(); //�� ������ ����
        }
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
                case 4:
                    eyes[3].gameObject.active = true;
                    break;
                case 5:
                    eyes[8].gameObject.active = true;
                    break;
                case 6:
                    eyes[2].gameObject.active = true;
                    break;
                case 7:
                    eyes[7].gameObject.active = true;
                    break;
            }
            isClose = false;
            blinkTimer = Random.Range(0.2f, 1.0f);
        } // ���� ���� ���� ������ �� �߱�

    }
}
