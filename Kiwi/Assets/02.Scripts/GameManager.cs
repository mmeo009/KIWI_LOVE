using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;               // UI �߰� 
using UnityEngine.SceneManagement;                  //����Ƽ Scene �̵��� ���ؼ� ������
using System;             // �߰� 
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
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


    public Kiwi kiwi; // Ű�� �ν��Ͻ� ����
    public Leaf[] leaf; // ������ �ν��Ͻ� ����
    public int Coin; // ��� ���� ����
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
        CreateKiwi();
        Coin = 10000;
    }

    private void OnDestroy()    //�� ������Ʈ�� �ı��� ���
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;  //�̺�Ʈ�� �����Ѵ�. 
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

    }
    public void MoveScene(string SceneName) //�� �̵�(���ϴ� �� �̸�)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void UseCoin(int amount) //���μҺ�(���ҷ�)
    {
        Coin -= amount;
    }
    public void GetCoin(int amount) //��������(������)
    {
        Coin += amount;
    }

    public void CreateKiwi()
    {
        kiwi = new Kiwi();
        kiwi.NewKiwi(); //Ű�� ����
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
