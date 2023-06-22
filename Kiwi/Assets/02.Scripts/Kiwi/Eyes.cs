using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    protected GameManager GameManager => GameManager.Instance;
    public GameObject[] eyes;
    public float blinkTimer = 0.2f;
    public int eyeType = 0;
    public bool isClose = false;
    Animator anim;
    /*void Awake()
    {
        eyes = GameObject.FindGameObjectsWithTag("Eyes"); //눈 테그가 있는 친구들을 모두 찾아 넣음
        GameObject[] temp = eyes;
        for (int i = 0; i < eyes.Length; i++)
        {
            string name = temp[i].name.ToString();
            if (name.Contains(i.ToString()))
            {
                eyes[i] = temp[i];
            }
        }
        // 눈알 순서 정렬 혹시 몰라서

        for(int j = 1; j < eyes.Length; j++)
        {
            eyes[j].gameObject.active = false;
        }
        // 눈 하나빼고 다 끄기
    }*/ // 빌드시 오류나서 삭제
    private void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Kiwi").GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        if(GameManager.kiwi.maxExp <= GameManager.kiwi.KiwiExp) // 레벨업 시
        {
            eyeType = 5;
        }
        else if (anim.GetBool("Play") == true) // 놀때
        {
            eyeType = 4;
        }
        else if(anim.GetBool("Eat") == true) // 먹을때
        {
            eyeType = 6;
        }    
        else if(anim.GetBool("Clean") == true) // 씻을때
        {
            eyeType = 7;
        }
        else
        {
            switch (GameManager.kiwi.count) // 키위의 상태에 따라
            {
                case 0: // 수치 3개 0일때
                    eyeType = 0;
                    break;
                case 1: // 수치 1개 0일때
                    eyeType = 1;
                    break;
                case 2: // 수치 2개 0일때
                    eyeType = 2;
                    break;
                case 3: // 수치 3개 0일때
                    eyeType = 3;
                    break;
            }
        }
        blinkTimer -= Time.fixedDeltaTime; // 눈 타이머
        if(blinkTimer <= 0)
        {
            Blink(); //눈 깜빡이 실행
        }
    }
    public void Blink()
    {
        for (int i = 0; i < eyes.Length; i++) 
        {
            eyes[i].gameObject.active = false;
        } //일단 눈 다 끄기
        if (isClose == false)
        {
            eyes[1].gameObject.active = true;
            isClose = true;
            blinkTimer = 0.1f;
        } // 만약 눈이 떠있으면 눈 감기
        else
        {
            switch (eyeType)
            {
                case 0:
                    eyes[0].gameObject.active = true;
                    break;
                case 1:
                    eyes[4].gameObject.active = true;
                    break;
                case 2:
                    eyes[5].gameObject.active = true;
                    break;
                case 3:
                    eyes[6].gameObject.active = true;
                    break;
                case 4:
                    eyes[3].gameObject.active = true;
                    break;
                case 5:
                    eyes[8].gameObject.active = true;
                    break;
                case 6:
                    eyes[2].gameObject.active = true;
                    break;
                case 7:
                    eyes[7].gameObject.active = true;
                    break;
            }
            isClose = false;
            blinkTimer = Random.Range(0.2f, 1.0f);
        } // 만약 눈을 감고 있으면 눈 뜨기

    }
}
