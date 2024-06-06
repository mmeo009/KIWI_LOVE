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
        /*GameManager.CreateLeaf(leafAmount);
        GameObject[] leaf = new GameObject[leafAmount];
        for (int i = 0; i < leafAmount; i++)
        {
            int num = Random.Range(0, leaves.Length);
            leaf[i] = (GameObject)Instantiate(leaves[num]);
            leaf[i].transform.position = GameManager.leaf[i].pos;
        }*/
    }
    public void MoveKiwi()
    {
        GameManager.MoveScene("02. GamePlay S");
    }

    public void GetMoney()
    {
        GameManager.GetCoin(leafAmount);
    }
}
[System.Serializable]
public class Leaf
{
    public Vector3 pos;
    public float lX, lY;
    public GameObject leaf;
    public void LeafCreate()
    {
        this.leaf.transform.position = pos;
    }
    public void LeafPosition()
    {
        lX = Random.Range(0.0f, 10.0f);
        lY = Random.Range(-2f, 4f);
        pos = new Vector2(-0.3f, lY);
    }
    public void LeafRotate()
    {
        Quaternion toTree = Quaternion.LookRotation(new Vector3(0, 0, 0));
    }
}
