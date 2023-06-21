using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiManager : MonoBehaviour
{

    protected GameManager GameManager => GameManager.Instance;
    public TMP_Text text;
    void Start()
    {
        text = GetComponent<TMP_Text>();

    }

    // Update is called once per frame
    void Update()
    {
        text.text = GameManager.Coin.ToString();

    }
}
