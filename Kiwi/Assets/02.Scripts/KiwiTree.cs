using DG.Tweening.Core.Easing;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KiwiTree : MonoBehaviour
{
    protected GameManager GameManager => GameManager.Instance;
    public int leafAmount;
    public GameObject[] leaves;

    private void OnEnable()
    {
        leafAmount = GameManager.kiwi.generation;
        GameManager.CreateLeaf(leafAmount);
        GameObject[] leaf = new GameObject[leafAmount];
        for (int i = 0; i < leafAmount; i++)
        {
            int num = Random.Range(0, leaves.Length);
            leaf[i] = (GameObject)Instantiate(leaves[num]);
            leaf[i].transform.position = GameManager.leaf[i].pos;
        }
    }

    public void GetMoney()
    {
        GameManager.GetCoin(leafAmount);
    }
}
