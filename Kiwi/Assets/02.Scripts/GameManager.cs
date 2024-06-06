using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               // UI 추가 
using UnityEngine.SceneManagement;                  //유니티 Scene 이동을 위해서 가져옴
using System;             // 추가 
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
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
    public Leaf[] leaf; // 나뭇잎 인스턴스 생성
    public int Coin; // 골드 변수 선언
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
        Coin = 10000;
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

    public void CreateLeaf(int amount)
    {
        leaf[amount] = new Leaf();

        for(int i = 0; i < leaf.Length; i++)
        {
            leaf[i].LeafPosition();
        }
    }
}
