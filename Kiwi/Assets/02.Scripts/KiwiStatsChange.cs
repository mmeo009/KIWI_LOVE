using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiwiStatsChange : MonoBehaviour
{
    protected GameManager GameManager => GameManager.Instance;
    public float timer = 1.0f;
    void Update()
    {
        if(GameManager.kiwi.count == 0) // ��ġ 0�� 0�� �ϰ��
        {
            if(GameManager.kiwi.KiwiHP == 30.0f) // Ǯ���� ���
            {
                TakeStats(0.1f * Time.deltaTime, 0.15f * Time.deltaTime, 0.1f * Time.deltaTime, 0.0f);
            }
            else // �ƴҰ��
            {
                TakeStats(0.2f * Time.deltaTime, 0.3f * Time.deltaTime, 0.2f * Time.deltaTime, -0.2f * Time.deltaTime);
            }
        }
        else if (GameManager.kiwi.count == 1) // ��ġ 0�� 1�� �ϰ��
        {
            if (GameManager.kiwi.KiwiHP == 30.0f) // Ǯ���� ���
            {
                TakeStats(0.17f * Time.deltaTime, 0.2f * Time.deltaTime, 0.13f * Time.deltaTime, 0.0f);
            }
            else // �ƴҰ��
            {
                TakeStats(0.2f * Time.deltaTime, 0.3f * Time.deltaTime, 0.2f * Time.deltaTime, -0.1f * Time.deltaTime);
            }
        }
        else if(GameManager.kiwi.count == 2) // ��ġ 0�� 2�� �ϰ��
        {
            TakeStats(0.2f * Time.deltaTime, 0.2f * Time.deltaTime, 0.2f * Time.deltaTime, 0.1f * Time.deltaTime);
        }
        else if(GameManager.kiwi.count == 3) // ��ġ 0�� 3�� �ϰ��
        {
            TakeStats(0.1f * Time.deltaTime, 0.1f * Time.deltaTime, 0.1f * Time.deltaTime, 0.2f * Time.deltaTime);
        }

        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Debug.Log("���� : " + GameManager.kiwi.generation);
            Debug.Log("Play : " + GameManager.kiwi.PlayChange);
            Debug.Log("Full : " + GameManager.kiwi.FullChange);
            Debug.Log("Clean : " + GameManager.kiwi.CleanChange);
            Debug.Log("HP : " + GameManager.kiwi.KiwiHP);
            timer = 1.0f;
        }
    }
    void TakeStats(float P, float F, float C, float H) // ����, ����, û��, ü��(�����ϰ�� ü���߰�)
    {
        GameManager.kiwi.TakePlay(P);
        GameManager.kiwi.TakeFull(F);
        GameManager.kiwi.TakeClean(C);
        if (H > 0)
            GameManager.kiwi.TakeHP(H);
        else if (H < 0)
            GameManager.kiwi.GetHP(-H);
    }
}
