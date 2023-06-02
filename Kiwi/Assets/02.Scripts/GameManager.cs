using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               // UI �߰� 
using System;                       // �߰� 
using UnityEngine.SceneManagement;                  //����Ƽ Scene �̵��� ���ؼ� ������

public class GameManager : MonoBehaviour
{  
    public enum GameState           //���� ���°� ����
    {
        Start,
        Playing,
        KiwiDie,
        Battle
    }

    public event Action<GameState> OnGameStateChanged;

    public GameState currentState = GameState.Start;

    //=================================================================
    // ���� ���� 
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
            OnGameStateChanged?.Invoke(currentState);       //�̺�Ʈ�� null�� �ƴѰ�쿡�� �� �̺�Ʈ�� ȣ�� 
        }
    }

    public void StartGame()
    {   //���� ���� ������ ���⿡ �ۼ�
        CurrentState = GameState.Playing;

    }

    public void KiwiDie()
    {   //Ű�� �׾����� ������ ���⿡ �ۼ�
        CurrentState = GameState.KiwiDie;
        generation += 1;
        
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

    private void OnDestroy()    //�� ������Ʈ�� �ı��� ���
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;  //�̺�Ʈ�� �����Ѵ�. 
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