using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiwiStatsChange : MonoBehaviour
{
    protected GameManager GameManager => GameManager.Instance;
    public float timer = 1.0f;
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            TakeStats(0.2f, 0.3f, 0.1f, 0.0f);
            timer = 1.0f;
            Debug.Log(GameManager.kiwi.CleanChange);
            Debug.Log(GameManager.kiwi.FullChange);
        }
    }
    void TakeStats(float P, float F, float C, float H)
    {
        GameManager.kiwi.TakePlay(P);
        GameManager.kiwi.TakeFull(F);
        GameManager.kiwi.TakeClean(C);
        GameManager.kiwi.TakeHP(H);
    }
}
