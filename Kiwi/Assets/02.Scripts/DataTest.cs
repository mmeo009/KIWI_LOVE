using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTest : MonoBehaviour
{
    protected GameManager GameManager => GameManager.Instance;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(GameManager.MaxFull);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
