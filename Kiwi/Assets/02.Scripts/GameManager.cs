using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               // UI 추가 
using System;                       // 추가 
using UnityEngine.SceneManagement;                  //유니티 Scene 이동을 위해서 가져옴

public class GameManager : MonoBehaviour
{  
    public enum GameState           //게임 상태값 설정
    {
        Start,
        Playing,
        KiwiDie,
        Battle
    }

    public event Action<GameState> OnGameStateChanged;

    public GameState currentState = GameState.Start;

    //=================================================================
    // 변수 선언 
    //
    //=================================================================

    public int Coin;
    public float MaxFull, MinLevelFull, FullChange;
    public float MaxPlay, MinLevelPlay, PlayChange;
    public float MaxClean, MinLevelClean, CleanChange;
    public bool isFull, isPlay, isClean;
    public int KwiwLevel;
    public float KiwiExp;
    public int generation;

    public GameState CurrentState
    {
        get { return currentState; }
        private set
        {
            currentState = value;
            OnGameStateChanged?.Invoke(currentState);       //이벤트가 null이 아닌경우에만 이 이벤트를 호출 
        }
    }

    public void StartGame()
    {   //게임 시작 로직을 여기에 작성
        CurrentState = GameState.Playing;

    }

    public void KiwiDie()
    {   //키위 죽었을때 로직을 여기에 작성
        CurrentState = GameState.KiwiDie;
        generation += 1;
        
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