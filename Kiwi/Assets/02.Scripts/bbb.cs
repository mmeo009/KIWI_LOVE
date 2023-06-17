using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bbb : MonoBehaviour
{


    public Item scriptableObject; // 불러올 ScriptableObject
    //string Item = "GH, 부채, 양머리,지렁이구이, 새총";



    private void Start()
    {
        scriptableObject = Resources.Load<Item>("GH"); // ScriptableObject 
        if (scriptableObject == null)
        {
            Debug.Log("메뚜기 맛있다");
        }
    }

   

  



}

