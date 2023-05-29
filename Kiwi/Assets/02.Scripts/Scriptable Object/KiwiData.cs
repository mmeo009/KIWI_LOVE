using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Kiwi Data", menuName = "Scriptable Object/Kiwi Data", order = 1)]
public class KiwiStats : ScriptableObject
{
    [SerializeField]
    private float healthPoint;
    public float HealthPoint { get { return healthPoint; } }
    //키우고 있는 키위의 채력을 나타낸다 (전투시의 채력과는 별개)
    [SerializeField]
    private float stat001;
    public float Stat001 { get { return stat001; } }
    //stat 001은 키위의 배고픔 수치와 전투시 채력 수치에 사용된다.
    [SerializeField]
    private float stat002;
    public float Stat002 { get { return stat002; } }
    //stat 002는 키위의 청결도 수치와 전투시 공격력 수치에 사용된다.
    [SerializeField]
    private float stat003;
    public float Stat003 { get { return stat003; } }
    //stat 003은 키위의 지루함 수치와 전투시 공격속도 수치에 사용된다.
    [SerializeField]
    private int generation;
    public int Generation { get { return generation; } }
    //키위의 세대를 기록하는 변수
    [SerializeField]
    private string lastKiwi;
    public int LastKiwi { get { return generation; } }
    //키위의 전 세대의 스텟을 기록해두는 문자열

}
