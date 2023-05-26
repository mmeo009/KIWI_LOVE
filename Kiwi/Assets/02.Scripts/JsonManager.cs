using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class JsonManager : DataManager
{
    public KiwiStats kiwiStats;

    [ContextMenu("To Json Data")]
    public void SaveToJson(KiwiStats kiwiStats)
    {
        string jsonData = JsonUtility.ToJson(kiwiStats,true);
        string path = Path.Combine(Application.dataPath + "/Resources/Json/KiwiStats.json");
        File.WriteAllText(path, jsonData);
    }
    [ContextMenu("From Json Data")]
    public void LoadFromJson() 
    {
        string path = Path.Combine(Application.dataPath + "/Resources/Json/KiwiStats.json");
        string jsonData = File.ReadAllText(path);
        kiwiStats = JsonUtility.FromJson<KiwiStats>(jsonData);
    }
}


