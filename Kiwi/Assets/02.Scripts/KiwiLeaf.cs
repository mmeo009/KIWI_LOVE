using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KiwiLeaf : MonoBehaviour
{
    protected GameManager GameManager => GameManager.Instance;
    private void Start()
    {

    }

    void MyPosition(int num)
    {
        GameManager.leaf[num].LeafCreate();
    }
}
