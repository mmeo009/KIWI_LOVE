using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    private KiwiData kiwiData;
    public KiwiData KiwiData { get { return kiwiData; } }
    private ItemData itemData;
    public ItemData ItemData { get { return itemData; } }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            save();
        }
    }
    void save()
    {
        KiwiData.SaveToJson();
    }
}
