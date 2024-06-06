using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiwiStatsChange : MonoBehaviour
{
    protected GameManager GameManager => GameManager.Instance;
    public float timer = 1.0f;
    void Update()
    {
        if(GameManager.kiwi.count == 0) // 수치 0이 0개 일경우
        {
            if(GameManager.kiwi.KiwiHP == 30.0f) // 풀피일 경우
            {
                TakeStats(0.1f * Time.deltaTime, 0.15f * Time.deltaTime, 0.1f * Time.deltaTime, 0.0f);
            }
            else // 아닐경우
            {
                TakeStats(0.2f * Time.deltaTime, 0.3f * Time.deltaTime, 0.2f * Time.deltaTime, -0.2f * Time.deltaTime);
            }
        }
        else if (GameManager.kiwi.count == 1) // 수치 0이 1개 일경우
        {
            if (GameManager.kiwi.KiwiHP == 30.0f) // 풀피일 경우
            {
                TakeStats(0.17f * Time.deltaTime, 0.2f * Time.deltaTime, 0.13f * Time.deltaTime, 0.0f);
            }
            else // 아닐경우
            {
                TakeStats(0.2f * Time.deltaTime, 0.3f * Time.deltaTime, 0.2f * Time.deltaTime, -0.1f * Time.deltaTime);
            }
        }
        else if(GameManager.kiwi.count == 2) // 수치 0이 2개 일경우
        {
            TakeStats(0.2f * Time.deltaTime, 0.2f * Time.deltaTime, 0.2f * Time.deltaTime, 0.1f * Time.deltaTime);
        }
        else if(GameManager.kiwi.count == 3) // 수치 0이 3개 일경우
        {
            TakeStats(0.1f * Time.deltaTime, 0.1f * Time.deltaTime, 0.1f * Time.deltaTime, 0.2f * Time.deltaTime);
        }

        if(GameManager.kiwi.canIGrow == true)
        {
            GameManager.kiwi.GetExp(0.5f * Time.deltaTime);
        }
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
/*            Debug.Log("세대 : " + GameManager.kiwi.generation);
            Debug.Log("Play : " + GameManager.kiwi.PlayChange);
            Debug.Log("Full : " + GameManager.kiwi.FullChange);
            Debug.Log("Clean : " + GameManager.kiwi.CleanChange);
            Debug.Log("HP : " + GameManager.kiwi.KiwiHP);*/
            timer = 1.0f;
        }

        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(Input.GetKey(KeyCode.R))
            {
                TakeStats(-10,0,0,0);
            }
            else
            {
                TakeStats(10, 0, 0, 0);
            }
        }
        if( Input.GetKeyDown(KeyCode.W))
        {
            if(Input.GetKey(KeyCode.R))
            {
                TakeStats(0, -10, 0, 0);
            }
            else
            {
                TakeStats(0, 10, 0, 0);
            }
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(Input.GetKey(KeyCode.R)) 
            {
                TakeStats(0, 0, -10, 0);
            }
            else
            {
                TakeStats(0, 0, 10, 0);
            }
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            GameManager.GetCoin(1000);
        }
    }
    void TakeStats(float P, float F, float C, float H) // 놀이, 음식, 청결, 체력(음수일경우 체력추가)
    {
        if(P > 0)
        {
            GameManager.kiwi.TakePlay(P);
        }
        else if(P < 0)
        {
            GameManager.kiwi.GetPlay(-P);
        }
        if(F > 0)
        {
            GameManager.kiwi.TakeFull(F);
        }
        else if(F < 0)
        {
            GameManager.kiwi.GetFull(-F);
        }
        if(C > 0)
        {
            GameManager.kiwi.TakeClean(C);
        }
        else if(C < 0)
        {
            GameManager.kiwi.GetClean(-C);
        }
        if (H > 0)
        {
            GameManager.kiwi.TakeHP(H);
        }
        else if (H < 0)
        {
            GameManager.kiwi.GetHP(-H);
        }

    }
}
