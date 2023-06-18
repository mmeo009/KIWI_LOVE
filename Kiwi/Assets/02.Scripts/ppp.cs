using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ppp : MonoBehaviour
{
    // Reference to the Prefab. Drag a Prefab into this field in the Inspector.
    public GameObject Foods;

    private void Start()
    {
        // 버튼 클릭 시 호출될 함수를 연결합니다.
        UnityEngine.UI.Button button = GetComponent<UnityEngine.UI.Button>();
        button.onClick.AddListener(GetClick);
    }

    // This script will simply instantiate the Prefab when the game starts.
    public void GetClick()
    {
        // Instantiate at position (0, 0, 0) and zero rotation.
        Instantiate(Foods, new Vector3(0, 0, 0), Quaternion.identity);
    }

}
