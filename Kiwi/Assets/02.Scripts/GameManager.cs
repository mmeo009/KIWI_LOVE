using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               // UI 추가 
using System;                       // 추가 
using UnityEngine.SceneManagement;                  //유니티 Scene 이동을 위해서 가져옴

public class GameManager : MonoBehaviour
{  


    public class Kiwi
    {
        public double MaxFull, MinLevelFull, FullChange = 5;
        public double MaxPlay, MinLevelPlay, PlayChange = 5;
        public double MaxClean, MinLevelClean, CleanChange = 5;
        public bool isFull, isPlay, isClean;
        public int KwiwLevel;
        public int generation;
        public float KiwiExp;
        public static double PastMaxF, PastMaxP, PastMaxC;

        //Full=============================================================

        public void GetFull(float amount)
        {
            this.FullChange += amount;            
        }
        public void TakeFull(float amount)
        {
            this.FullChange -= amount;
        }
        public void FullChack()
        {
            if(this.MaxFull <= this.FullChange)
            {
                this.FullChange = this.MaxFull;
            }
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
        }
        public void TakePlay(float amount)
        {
            this.PlayChange -= amount;
        }
        public void PlayChack()
        {
            if (this.MaxPlay <= this.PlayChange)
            {
                this.PlayChange = this.MaxPlay;
            }
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
        }
        public void TakeClean(float amount)
        {
            this.CleanChange -= amount;
        }
        public void CleanChack()
        {
            if (this.MaxClean <= this.CleanChange)
            {
                this.CleanChange = this.MaxClean;
            }
            if (this.CleanChange >= this.MinLevelClean)
            {
                this.isClean = true;
            }
            else
            {
                this.isClean = false;
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

        public void NewKiwi()
        {
            if(this.generation == 0)
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
            this.KiwiExp = 0;
            this.generation++;
            MinLevel();
        }
        public void KiwiDie()
        {
            PastMaxC = this.MaxClean;
            PastMaxF = this.MaxFull;
            PastMaxP = this.MaxPlay;
        }
    }
    public enum GameState           //게임 상태값 설정
    {
        Start,
        Playing,
        Battle
    }

    public event Action<GameState> OnGameStateChanged;

    public GameState currentState = GameState.Start;

    //=================================================================
    // 변수 선언 
    //=================================================================

    public Kiwi kiwi = new Kiwi();
    public int Coin;
    public GameState CurrentState
    {
        get { return currentState; }
        private set
        {
            currentState = value;
            OnGameStateChanged?.Invoke(currentState);       //이벤트가 null이 아닌경우에만 이 이벤트를 호출 
        }
    }


    public GameManager() { }
    public static GameManager Instance { get; private set; }    //싱글톤화
   
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
    {   //게임 시작 로직을 여기에 작성
        CurrentState = GameState.Playing;

        kiwi.NewKiwi();
        Debug.Log(kiwi.MaxFull);
        kiwi.KiwiDie();
        kiwi.NewKiwi();
        Debug.Log(kiwi.FullChange);

    }

    private void OnDestroy()    //이 오브젝트가 파괴될 경우
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;  //이벤트를 삭제한다. 
    }
    public void MoveGaneScene()
    {
        SceneManager.LoadScene("02. Gameplay S");
    }
    public void MoveTreeScene()
    {
        SceneManager.LoadScene("03. Tree S");
    }
    public void MoveBattleScene()
    {
        SceneManager.LoadScene("04. Battle S");
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
       
    }

}