using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bbb : MonoBehaviour
{
    public Item scriptableObject;
    public GameObject itemObject;
    public float timer = 3.0f;
    public bool button = false;
    public GameManager gameManager;
    public int itemCost;

    private void Start()
    {
        itemCost = scriptableObject.itemCost;
    }

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
        itemObject.gameObject.active = false;
        timer = 3.0f;
        button = false;
    }
    public void PressButton()
    {
        if (button == false)
        {
            Debug.Log(scriptableObject.itemName);
            if (scriptableObject.itemName == "GH")
            {
                if (itemObject.gameObject.active == false)
                {
                    itemObject.gameObject.active = true;
                }
                Debug.Log("�޶ѱ� ���ִ�");
                //gameManager.Coin -= itemCost; 
            }
            button = true;
        }
      

    }
    public void PressButton1()
    {
        if (button == false)
        {
            Debug.Log(scriptableObject.itemName);
            if (scriptableObject.itemName == "������")
            {
                if (itemObject.gameObject.active == false)
                {
                    itemObject.gameObject.active = true;
                }
                Debug.Log("������ ���ִ�");
                //gameManager.Coin -= itemCost; 
            }
            button = true;
        }
    }
    public void PressButton2()
    {
        if (button == false)
        {
            Debug.Log(scriptableObject.itemName);
            if (scriptableObject.itemName == "stew")
            {
                if (itemObject.gameObject.active == false)
                {
                    itemObject.gameObject.active = true;
                }
                Debug.Log("��Ʃ ���ִ�");
                //gameManager.Coin -= itemCost; 
            }
            button = true;
        }
    }
    public void PressButton3()
    {
        if (button == false)
        {
            Debug.Log(scriptableObject.itemName);
            if (scriptableObject.itemName == "������")
            {
                if (itemObject.gameObject.active == false)
                {
                    itemObject.gameObject.active = true;
                }
                Debug.Log("���� ���ִ�");
                //gameManager.Coin -= itemCost; 
            }
            button = true;
        }
    }
    public void PressClick()
    {
        if (button == false)
        {
            Debug.Log(scriptableObject.itemName);
            if (scriptableObject.itemName == "����")
            {
                if (itemObject.gameObject.active == false)
                {
                    itemObject.gameObject.active = true;
                }
                Debug.Log("3�� 500");
                //gameManager.Coin -= itemCost; 
            }
            button = true;
        }
    }
    public void PressClick1()
    {
        if (button == false)
        {
            Debug.Log(scriptableObject.itemName);
            if (scriptableObject.itemName == "����")
            {
                if (itemObject.gameObject.active == false)
                {
                    itemObject.gameObject.active = true;
                }
                Debug.Log("����");
                //gameManager.Coin -= itemCost; 
            }
            button = true;
        }
    }
    public void PressClick2()
    {
        if (button == false)
        {
            Debug.Log(scriptableObject.itemName);
            if (scriptableObject.itemName == "��Ӹ�")
            {
                if (itemObject.gameObject.active == false)
                {
                    itemObject.gameObject.active = true;
                }
                Debug.Log("����~");
                //gameManager.Coin -= itemCost; 
            }
            button = true;
        }
    }
    public void PressClick3()
    {
        if (button == false)
        {
            Debug.Log(scriptableObject.itemName);
            if (scriptableObject.itemName == "fan")
            {
                if (itemObject.gameObject.active == false)
                {
                    itemObject.gameObject.active = true;
                }
                Debug.Log("�ƽÿ���");
                //gameManager.Coin -= itemCost; 
            }
            button = true;
        }
    }
    public void PressClick4()
    {
        if (button == false)
        {
            Debug.Log(scriptableObject.itemName);
            if (scriptableObject.itemName == "brush")
            {
                if (itemObject.gameObject.active == false)
                {
                    itemObject.gameObject.active = true;
                }
                Debug.Log("����");
                //gameManager.Coin -= itemCost; 
            }
            button = true;
        }
    }
}

