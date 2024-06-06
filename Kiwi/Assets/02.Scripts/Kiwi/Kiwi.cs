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

    public void GetFull(float amount) //���ļ�ġ �߰�(�߰���)
    {
        this.FullChange += amount; // ���ļ��� �߰�
        if (this.FullChange > this.MaxFull) // ���ϴ� ���ļ�ġ�� �ִ� ��ġ���� Ŭ���
        {
            this.FullChange = this.MaxFull; //�ִ��ġ�� ����
        }
        FullChack(); // ���ļ�ġ üũ
    }
    public void TakeFull(float amount) //���ļ�ġ ����(���ҷ�)
    {
        this.FullChange -= amount; // ���ļ�ġ ����
        if (this.FullChange < 0) // ���ļ�ġ�� 0���� �������
        {
            FullChange = 0; // 0���� ����
        }
        FullChack(); // ���ļ�ġ üũ
        ZeroCount(); // ��ġ�� 0���� üũ
    }
    public void FullChack() // ���ļ�ġ Ȯ��
    {
        if (this.FullChange >= this.MinLevelFull) //���ļ�ġ�� 70%�̻��� ���
        {
            this.isFull = true; //������ ���� ��
        }
        else
        {
            this.isFull = false; //�ƴҰ�� ����
        }
    }

    //Play=============================================================

    public void GetPlay(float amount) //���� ��ġ ����(������)
    {
        this.PlayChange += amount;
        if (this.PlayChange > this.MaxPlay)
        {
            this.PlayChange = this.MaxPlay;
        }
        PlayChack();
    }
    public void TakePlay(float amount) //���� ��ġ ����(���ҷ�)
    {
        this.PlayChange -= amount;
        if (this.PlayChange < 0)
        {
            PlayChange = 0;
        }
        PlayChack();
        ZeroCount();
    }
    public void PlayChack() //���� ��ġ Ȯ��
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

    public void GetClean(float amount) //û�� ��ġ ����(������)
    {
        this.CleanChange += amount;
        if (this.CleanChange > this.MaxClean)
        {
            this.CleanChange = this.MaxClean;
        }
        CleanChack();
    }
    public void TakeClean(float amount) //û�� ��ġ ����(���ҷ�)
    {
        this.CleanChange -= amount;
        if (this.CleanChange < 0)
        {
            CleanChange = 0;
        }
        CleanChack();
        ZeroCount();
    }
    public void CleanChack() //û�ᵵ Ȯ��
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

    public void GetHP(float amount) //ü���߰�(�߰���)
    {
        this.KiwiHP += amount; //ü���߰�
        if (this.KiwiHP > 30) //30���� Ŭ���
        {
            this.KiwiHP = 30; //30���� ����
        }
    }
    public void TakeHP(float amount) //ü�°���(���ҷ�)
    {
        this.KiwiHP -= amount; //ü�°���
        if (this.KiwiHP < 0) //ü���� 0���� �������
        {
            KiwiDie(); //Ű�� ���
        }
    }

    //=================================================================

    public void MinLevel() //�ּҷ����� ���� ��ġ ����
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
    public void LevelUp() //������
    {
        this.MaxClean += 10;
        this.MaxFull += 10;
        this.MaxPlay += 10;
        this.KiwiExp = 0; //����ġ �ʱ�ȭ
        this.KwiwLevel++;
        this.maxExp = this.KwiwLevel * 3 + 10; //���� ���� x 3 + 10(�ʱⰪ) 
    }
    public void ZeroCount() //��ġ�� 0�ΰ��� ����� Ȯ��
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

    public void NewKiwi() // ���ο� Ű�� ����
    {
        if (this.generation == 0) //ù��°�� �����Ҷ�
        {
            this.MaxFull = 10;
            this.MaxPlay = 10;
            this.MaxClean = 10;
            this.FullChange = 5;
            this.PlayChange = 5;
            this.CleanChange = 5;
            this.maxExp = 10.0f;
        }
        else //�������밡 �����Ҷ�
        {
            this.MaxFull = 10 + Mathf.Round(PastMaxF / 2);
            this.MaxPlay = 10 + Mathf.Round(PastMaxP / 2);
            this.MaxClean = 10 + Mathf.Round(PastMaxC / 2);
            this.FullChange = Mathf.Round(MaxFull / 2);
            this.PlayChange = Mathf.Round(MaxPlay / 2);
            this.CleanChange = Mathf.Round(MaxClean / 2);
        }
        this.KiwiHP = 30; //ü���� �׻� �ִ��
        this.KiwiExp = 0; //����ġ�� �׻� 0����
        this.generation++; //���� �߰�
        MinLevel(); //�ּҷ����� ��ġ ����
        ZeroCount(); // 0�� ����� Ȯ���ϴ°� �ѹ� 
    }
    public void KiwiDie() //Ű���� �������
    {
        PastMaxC = this.MaxClean;
        PastMaxF = this.MaxFull;
        PastMaxP = this.MaxPlay;
        NewKiwi(); // �׽�Ʈ�� ���߿� ����
    }
}
