using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               // UI �߰� 
using System;                       // �߰� 
using UnityEngine.SceneManagement;                  //����Ƽ Scene �̵��� ���ؼ� ������

public class GameManager : MonoBehaviour
{


    public class Kiwi
    {
        public double MaxFull, MinLevelFull, FullChange = 5;
        public double MaxPlay, MinLevelPlay, PlayChange = 5;
        public double MaxClean, MinLevelClean, CleanChange = 5;
        public float KiwiHP;
        public bool isFull, isPlay, isClean;
        public int KwiwLevel;
        public int generation;
        public float KiwiExp;
        public static double PastMaxF, PastMaxP, PastMaxC;
        public int count;

        //Full=============================================================

        public void GetFull(float amount)
        {
            this.FullChange += amount;
            if (this.FullChange > this.MaxFull)
            {
                this.FullChange = this.MaxFull;
            }
            FullChack();
        }
        public void TakeFull(float amount)
        {
            this.FullChange -= amount;
            if (this.FullChange < 0)
            {
                FullChange = 0;
            }
            FullChack();
            ZeroCount();
        }
        public void FullChack()
        {
            if (this.FullChange >= this.MinLevelFull)
            {
                this.isFull = true;
            }
            else
            {
                this.isFull = false;
            }
        }

        //Play=============================================================

        public void GetPlay(float amount)
        {
            this.PlayChange += amount;
            if (this.PlayChange > this.MaxPlay)
            {
                this.PlayChange = this.MaxPlay;
            }
            PlayChack();
        }
        public void TakePlay(float amount)
        {
            this.PlayChange -= amount;
            if (this.PlayChange < 0)
            {
                PlayChange = 0;
            }
            PlayChack();
            ZeroCount();
        }
        public void PlayChack()
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

        public void GetClean(float amount)
        {
            this.CleanChange += amount;
            if (this.CleanChange > this.MaxClean)
            {
                this.CleanChange = this.MaxClean;
            }
            CleanChack();
        }
        public void TakeClean(float amount)
        {
            this.CleanChange -= amount;
            if (this.CleanChange < 0)
            {
                CleanChange = 0;
            }
            CleanChack();
            ZeroCount();
        }
        public void CleanChack()
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

        public void GetHP(float amount)
        {
            this.KiwiHP += amount;
            if (this.KiwiHP > 30)
            {
                this.KiwiHP = 30;
            }
        }
        public void TakeHP(float amount)
        {
            this.KiwiHP -= amount;
            if (this.KiwiHP < 0)
            {
                KiwiDie();
            }
        }

        //=================================================================

        public void MinLevel()
        {
            this.MinLevelClean = Math.Round(this.MaxClean / 100 * 70);
            this.MinLevelPlay = Math.Round(this.MaxPlay / 100 * 70);
            this.MinLevelFull = Math.Round(this.MaxPlay / 100 * 70);
        }
        public void LevelUp()
        {
            this.MaxClean += 10;
            this.MaxFull += 10;
            this.MaxPlay += 10;
            this.KiwiExp = 0;
        }
        public void ZeroCount()
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

        public void NewKiwi()
        {
            if (this.generation == 0)
            {
                this.MaxFull = 10;
                this.MaxPlay = 10;
                this.MaxClean = 10;
                this.FullChange = 5;
                this.PlayChange = 5;
                this.CleanChange = 5;
            }
            else
            {
                this.MaxFull = 10 + Math.Round(PastMaxF / 2);
                this.MaxPlay = 10 + Math.Round(PastMaxP / 2);
                this.MaxClean = 10 + Math.Round(PastMaxC / 2);
                this.FullChange = Math.Round(MaxFull / 2);
                this.PlayChange = Math.Round(MaxPlay / 2);
                this.CleanChange = Math.Round(MaxClean / 2);
            }
            this.KiwiHP = 30;
            this.KiwiExp = 0;
            this.generation++;
            MinLevel();
            ZeroCount();
        }
        public void KiwiDie()
        {
            PastMaxC = this.MaxClean;
            PastMaxF = this.MaxFull;
            PastMaxP = this.MaxPlay;
            NewKiwi(); // �׽�Ʈ�� ���߿� ����
        }
    }
    public enum GameState           //���� ���°� ����
    {
        Start,
        Playing,
        Battle
    }

    public event Action<GameState> OnGameStateChanged;

    public GameState currentState = GameState.Start;

    //=================================================================
    // ���� ���� 
    //=================================================================


    public Kiwi kiwi;
    public int Coin;
    public GameState CurrentState
    {
        get { return currentState; }
        private set
        {
            currentState = value;
            OnGameStateChanged?.Invoke(currentState);       //�̺�Ʈ�� null�� �ƴѰ�쿡�� �� �̺�Ʈ�� ȣ�� 
        }
    }
    public GameManager() { }
    public static GameManager Instance { get; private set; }    //�̱���ȭ

    private void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            transform.parent = null;
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        SceneManager.sceneLoaded += OnSceneLoaded;

    }
    public void Start()
    {   //���� ���� ������ ���⿡ �ۼ�
        kiwi = new Kiwi();
        kiwi.NewKiwi();
    }

    private void OnDestroy()    //�� ������Ʈ�� �ı��� ���
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;  //�̺�Ʈ�� �����Ѵ�. 
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

    }
    public void MoveScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void UseCoin(int amount)
    {
        Coin -= amount;
    }
    public void GetCoin(int amount)
    {
        Coin += amount;
    }
}
