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
        if(button == false)
        {
            Debug.Log(scriptableObject.itemName);
            if (scriptableObject.itemName == "GH")
            {
                if (itemObject.gameObject.active == false)
                {
                    itemObject.gameObject.active = true;
                }
                Debug.Log("¸Þ¶Ñ±â ¸ÀÀÖ´Ù");
                gameManager.UseCoin(scriptableObject.itemCost);
            }
            button = true;
        }
        
    }
}

