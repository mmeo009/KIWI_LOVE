using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bbb : MonoBehaviour
{


    public Item scriptableObject; // �ҷ��� ScriptableObject
    //string Item = "GH, ��ä, ��Ӹ�,�����̱���, ����";



    private void Start()
    {
        scriptableObject = Resources.Load<Item>("GH"); // ScriptableObject 
        if (scriptableObject == null)
        {
            Debug.Log("�޶ѱ� ���ִ�");
        }
    }

   

  



}

