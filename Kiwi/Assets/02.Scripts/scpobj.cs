using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scpobj : MonoBehaviour
{
    public Text scriptableObjectText; // ScriptableObject ���� ǥ���� UI �ؽ�Ʈ
    private string scriptableObjectString; // ScriptableObject ���� ������ ����
    private Item loadedScriptableObject; // �ε�� ScriptableObject

    public void SetScriptableObjectString(string value)
    {
        scriptableObjectString = value;
    }

    public void LoadScriptableObject()
    {
        loadedScriptableObject = Resources.Load<Item>(scriptableObjectString);
        if (loadedScriptableObject != null)
        {
            scriptableObjectText.text = loadedScriptableObject.ToString();
           
        }
      
    }
}
