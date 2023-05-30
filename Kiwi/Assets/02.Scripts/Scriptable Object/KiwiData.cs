using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Kiwi Data", menuName = "Scriptable Object/Kiwi Data", order = 1)]
public class KiwiStats : ScriptableObject
{
    [SerializeField]
    private float healthPoint;
    public float HealthPoint { get { return healthPoint; } }
    //Ű��� �ִ� Ű���� ä���� ��Ÿ���� (�������� ä�°��� ����)
    [SerializeField]
    private float stat001;
    public float Stat001 { get { return stat001; } }
    //stat 001�� Ű���� ����� ��ġ�� ������ ä�� ��ġ�� ���ȴ�.
    [SerializeField]
    private float stat002;
    public float Stat002 { get { return stat002; } }
    //stat 002�� Ű���� û�ᵵ ��ġ�� ������ ���ݷ� ��ġ�� ���ȴ�.
    [SerializeField]
    private float stat003;
    public float Stat003 { get { return stat003; } }
    //stat 003�� Ű���� ������ ��ġ�� ������ ���ݼӵ� ��ġ�� ���ȴ�.
    [SerializeField]
    private int generation;
    public int Generation { get { return generation; } }
    //Ű���� ���븦 ����ϴ� ����
    [SerializeField]
    private string lastKiwi;
    public int LastKiwi { get { return generation; } }
    //Ű���� �� ������ ������ ����صδ� ���ڿ�

    [ContextMenu("To Json Data")]
    public void SaveToJson()
    {
        string jsonData = JsonUtility.ToJson(t, true);
        string path = Path.Combine(Application.dataPath + "/Resources/Json/KiwiStats.json");
        File.WriteAllText(path, jsonData);
    }
    [ContextMenu("From Json Data")]
    public void LoadFromJson()
    {
        string path = Path.Combine(Application.dataPath + "/Resources/Json/KiwiStats.json");
        string jsonData = File.ReadAllText(path);
        kiwiData = JsonUtility.FromJson<KiwiData>(jsonData);
    }

}
