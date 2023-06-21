using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotSystem : MonoBehaviour
{
    public Item[] scriptableObject;
    public GameObject[] itemObject;
    public float timer = 3.0f;
    public bool button = false;
    protected GameManager GameManager => GameManager.Instance;

    private void Update()
    {
        if(button == true)
        {
            timer -= Time.deltaTime;
        }
        if(timer <= 0)
        {
            ByeGH();
        }
    }
    private void ByeGH()
    {
        for(int i = 0; i < scriptableObject.Length; i++)
        {
            itemObject[i].gameObject.active = false;
        }
        timer = 3.0f;
        button = false;
    }
    public void PressButton(int itemNum)
    {
        if (button == false)
        {
            itemObject[itemNum].gameObject.active = true;
            GameManager.UseCoin(scriptableObject[itemNum].itemCost);
            switch(itemNum)
            {
                case 0:
                    Debug.Log("�޶ѱ� ���ִ�");
                    break;

                case 1:
                    Debug.Log("���� ���ִ�");
                    break;

                case 2:
                    Debug.Log("��Ʃ ���ִ�");
                    break;

                case 3:
                    Debug.Log("3�� 500");
                    break;
                case 4:
                    Debug.Log("�ָ��� �Ŀ�");
                    break;
                case 5:
                    Debug.Log("�Ѿ~");
                    break;
                case 6:
                    Debug.Log("�ÿ�");
                    break;
                case 7:
                    Debug.Log("����");
                    break;
                case 8:
                    Debug.Log("����");
                    break;
                case 9:
                    Debug.Log("��ŭ�� ����");
                    break;
                case 10:
                    Debug.Log("������ �극��");
                    break;
                case 11:
                    Debug.Log("�ͻ�");
                    break;
                case 12:
                    Debug.Log("��޽����� �Ǹ�");
                    break;
                case 13:
                    Debug.Log("ġ������");
                    break;
                case 14:
                    Debug.Log("÷��÷��");
                    break;

            }
            if(scriptableObject[itemNum].itemType == 0)
            {
                GameManager.kiwi.GetFull(scriptableObject[itemNum].plusAmount);
            }
            else if(scriptableObject[itemNum].itemType == 1)
            {
                GameManager.kiwi.GetPlay(scriptableObject[itemNum].plusAmount);
            }
            else
            {
                GameManager.kiwi.GetClean(scriptableObject[itemNum].plusAmount);
            }
        }
            button = true;
    }
}


