using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bbb : MonoBehaviour
{
    public Item scriptableObject;
    public GameObject GH;
    public float timer = 3.0f;
    public bool button = false;

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
        GH.gameObject.active = false;
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

                if (GH.gameObject.active == false)
                {
                    GH.gameObject.active = true;
                }

                Debug.Log("¸Þ¶Ñ±â ¸ÀÀÖ´Ù");
            }
            button = true;
        }
        
    }
}

