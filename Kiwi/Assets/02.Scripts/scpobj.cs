using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scpobj : MonoBehaviour
{
    public Text scriptableObjectText; // ScriptableObject 값을 표시할 UI 텍스트
    private string scriptableObjectString; // ScriptableObject 값을 저장할 변수
    private Item loadedScriptableObject; // 로드된 ScriptableObject

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
