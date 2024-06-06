using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Kiwi
{
    public float MaxFull, MinLevelFull, FullChange = 5;
    public float MaxPlay, MinLevelPlay, PlayChange = 5;
    public float MaxClean, MinLevelClean, CleanChange = 5;
    public float KiwiHP;
    public bool isFull, isPlay, isClean, canIGrow;
    public int KwiwLevel;
    public int generation;
    public float KiwiExp, maxExp;
    public static float PastMaxF, PastMaxP, PastMaxC;
    public int count;

    //Full=============================================================

    public void GetFull(float amount) //음식수치 추가(추가량)
    {
        this.FullChange += amount; // 음식수지 추가
        if (this.FullChange > this.MaxFull) // 변하는 음식수치가 최대 수치보다 클경우
        {
            this.FullChange = this.MaxFull; //최대수치로 변경
        }
        FullChack(); // 음식수치 체크
    }
    public void TakeFull(float amount) //음식수치 감수(감소량)
    {
        this.FullChange -= amount; // 음식수치 감소
        if (this.FullChange < 0) // 음식수치가 0보다 작을경우
        {
            FullChange = 0; // 0으로 변경
        }
        FullChack(); // 음식수치 체크
        ZeroCount(); // 수치가 0인지 체크
    }
    public void FullChack() // 음식수치 확인
    {
        if (this.FullChange >= this.MinLevelFull) //음식수치가 70%이상일 경우
        {
            this.isFull = true; //레벨업 조건 참
        }
        else
        {
            this.isFull = false; //아닐경우 거짓
        }
    }

    //Play=============================================================

    public void GetPlay(float amount) //놀이 수치 증가(증가량)
    {
        this.PlayChange += amount;
        if (this.PlayChange > this.MaxPlay)
        {
            this.PlayChange = this.MaxPlay;
        }
        PlayChack();
    }
    public void TakePlay(float amount) //놀이 수치 감소(감소량)
    {
        this.PlayChange -= amount;
        if (this.PlayChange < 0)
        {
            PlayChange = 0;
        }
        PlayChack();
        ZeroCount();
    }
    public void PlayChack() //놀이 수치 확인
    {
        if (this.PlayChange >= this.MinLevelPlay)
        {
            this.isPlay = true;
        }
        else
        {
            this.isPlay = false;
        }
    }

    //Clean============================================================

    public void GetClean(float amount) //청결 수치 증가(증가량)
    {
        this.CleanChange += amount;
        if (this.CleanChange > this.MaxClean)
        {
            this.CleanChange = this.MaxClean;
        }
        CleanChack();
    }
    public void TakeClean(float amount) //청결 수치 감소(감소량)
    {
        this.CleanChange -= amount;
        if (this.CleanChange < 0)
        {
            CleanChange = 0;
        }
        CleanChack();
        ZeroCount();
    }
    public void CleanChack() //청결도 확인
    {
        if (this.CleanChange >= this.MinLevelClean)
        {
            this.isClean = true;
        }
        else
        {
            this.isClean = false;
        }
    }
    //HP===============================================================

    public void GetHP(float amount) //체력추가(추가량)
    {
        this.KiwiHP += amount; //체력추가
        if (this.KiwiHP > 30) //30보다 클경우
        {
            this.KiwiHP = 30; //30으로 설정
        }
    }
    public void TakeHP(float amount) //체력감소(감소량)
    {
        this.KiwiHP -= amount; //체력감소
        if (this.KiwiHP < 0) //체력이 0보다 적을경우
        {
            KiwiDie(); //키위 사망
        }
    }

    //=================================================================

    public void MinLevel() //최소레벨업 조건 수치 설정
    {
        this.MinLevelClean = Mathf.Round(this.MaxClean / 100 * 70);
        this.MinLevelPlay = Mathf.Round(this.MaxPlay / 100 * 70);
        this.MinLevelFull = Mathf.Round(this.MaxPlay / 100 * 70);
    }
    public void LevelUpChack()
    {
        if ((this.isClean == true && this.isFull == true) || (this.isFull == true && this.isPlay == true) || (this.isPlay == true && this.isClean == true) || (this.isClean == true && this.isFull == true && this.isPlay == true))
        {
            this.canIGrow = true;
        }
        else
        {
            this.canIGrow = false;
        }
    }
    public void GetExp(float amount)
    {
        this.KiwiExp += amount;
        if (KiwiExp >= maxExp)
        {
            LevelUp();
        }
    }
    public void LevelUp() //레벨업
    {
        this.MaxClean += 10;
        this.MaxFull += 10;
        this.MaxPlay += 10;
        this.KiwiExp = 0; //경험치 초기화
        this.KwiwLevel++;
        this.maxExp = this.KwiwLevel * 3 + 10; //지금 레벨 x 3 + 10(초기값) 
    }
    public void ZeroCount() //수치가 0인것이 몇개인지 확인
    {
        if (this.PlayChange == 0 && this.FullChange == 0 && this.CleanChange == 0)
        {
            this.count = 3;
        }
        else if ((this.CleanChange == 0 && this.FullChange == 0) || (this.PlayChange == 0 && this.CleanChange == 0) || (this.FullChange == 0 && this.PlayChange == 0))
        {
            this.count = 2;
        }
        else if (this.PlayChange == 0 || this.FullChange == 0 || this.CleanChange == 0)
        {
            this.count = 1;
        }
        else
        {
            this.count = 0;
        }

    }

    public void NewKiwi() // 새로운 키위 생성
    {
        if (this.generation == 0) //첫번째로 생성할때
        {
            this.MaxFull = 10;
            this.MaxPlay = 10;
            this.MaxClean = 10;
            this.FullChange = 5;
            this.PlayChange = 5;
            this.CleanChange = 5;
            this.maxExp = 10.0f;
        }
        else //이전세대가 존재할때
        {
            this.MaxFull = 10 + Mathf.Round(PastMaxF / 2);
            this.MaxPlay = 10 + Mathf.Round(PastMaxP / 2);
            this.MaxClean = 10 + Mathf.Round(PastMaxC / 2);
            this.FullChange = Mathf.Round(MaxFull / 2);
            this.PlayChange = Mathf.Round(MaxPlay / 2);
            this.CleanChange = Mathf.Round(MaxClean / 2);
        }
        this.KiwiHP = 30; //체력은 항상 최대로
        this.KiwiExp = 0; //경험치는 항상 0으로
        this.generation++; //세대 추가
        MinLevel(); //최소레벨업 수치 설정
        ZeroCount(); // 0이 몇개인지 확인하는것 한번 
    }
    public void KiwiDie() //키위가 죽을경우
    {
        PastMaxC = this.MaxClean;
        PastMaxF = this.MaxFull;
        PastMaxP = this.MaxPlay;
        NewKiwi(); // 테스트용 나중에 삭제
    }
}
