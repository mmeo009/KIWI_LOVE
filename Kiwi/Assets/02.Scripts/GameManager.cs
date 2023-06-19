using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               // UI 추가 
using UnityEngine.SceneManagement;                  //유니티 Scene 이동을 위해서 가져옴
using System;             // 추가 
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{


    public class Kiwi
    {
        public double MaxFull, MinLevelFull, FullChange = 5;
        public double MaxPlay, MinLevelPlay, PlayChange = 5;
        public double MaxClean, MinLevelClean, CleanChange = 5;
        public float KiwiHP;
        public bool isFull, isPlay, isClean , canIGrow;
        public int KwiwLevel;
        public int generation;
        public float KiwiExp, maxExp;
        public static double PastMaxF, PastMaxP, PastMaxC;
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
            this.MinLevelClean = Math.Round(this.MaxClean / 100 * 70);
            this.MinLevelPlay = Math.Round(this.MaxPlay / 100 * 70);
            this.MinLevelFull = Math.Round(this.MaxPlay / 100 * 70);
        }
        public void LevelUpChack()
        {
            if ((this.isClean == true && this.isFull == true) || (this.isFull == true && this.isPlay == true) || (this.isPlay == true && this.isClean == true)|| (this.isClean == true && this.isFull == true && this.isPlay == true))
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
            if(KiwiExp >= maxExp)
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
                this.MaxFull = 10 + Math.Round(PastMaxF / 2);
                this.MaxPlay = 10 + Math.Round(PastMaxP / 2);
                this.MaxClean = 10 + Math.Round(PastMaxC / 2);
                this.FullChange = Math.Round(MaxFull / 2);
                this.PlayChange = Math.Round(MaxPlay / 2);
                this.CleanChange = Math.Round(MaxClean / 2);
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

    public class Leaf
    {
        public Vector2 position;
        public float lX, lY;
        public GameObject leaf;
        public void ThisLeafPosition()
        {
            lX = Random.Range(0.0f, 10.0f);
            lY = Random.Range(0.0f, 10.0f);
        }
        public void Spawn()
        {
            Quaternion toTree = Quaternion.LookRotation(new Vector3(0,0,0));
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


    public Kiwi kiwi; // 키위 인스턴스 생성
    public int Coin = 100; // 골드 변수 선언
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
        CreateKiwi();
    }

    private void OnDestroy()    //이 오브젝트가 파괴될 경우
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;  //이벤트를 삭제한다. 
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

    }
    public void MoveScene(string SceneName) //씬 이동(원하는 씬 이름)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void UseCoin(int amount) //코인소비(감소량)
    {
        Coin -= amount;
    }
    public void GetCoin(int amount) //코인증가(증가량)
    {
        Coin += amount;
    }

    public void CreateKiwi()
    {
        kiwi = new Kiwi();
        kiwi.NewKiwi(); //키위 생성
    }
}
