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
        GameOver
    }

    public event Action<GameState> OnGameStateChanged;

    public GameState currentState = GameState.Start;

    //=================================================================
    // ���� ���� 
    //
    //=================================================================

    public int MaxCute;
    public int MaxPlay;
    public int MaxHungry;
    public int Sleep;

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

    public void GameOver()
    {   //���� ���� ������ ���⿡ �ۼ�
        CurrentState = GameState.GameOver;
        
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

    public void MoveTreeScene()
    {

        SceneManager.LoadScene("Tree S");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
       
    }

}