using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class KiwiStatManager : MonoBehaviour
{
        public KiwiStats kiwiStats;
}

[System.Serializable]
public class KiwiStats
{
    public float hp, sta, clean, mental;
    public int generation;
    public string[] recentKiwi;
}

