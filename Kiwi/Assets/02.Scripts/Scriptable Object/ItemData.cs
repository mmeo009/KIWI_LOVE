using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "Item Data", menuName = "Scriptable Object/Item Data", order = 2)]
public class ItemData : ScriptableObject
{
    [SerializeField]
    private int itemType;
    public int ItemType { get { return itemType; } }
    //0 == 음식, 1 == 청결, 2 == 치장용, 3 == 기타 아이템(레벨업 관련)
    [SerializeField]
    private int addPoint;
    public int AddPoint { get { return addPoint; } }
    //버프량
    [SerializeField]
    private int decreasePoint;
    public int DecreasePoint { get { return decreasePoint; } }
    //디버프량
    [SerializeField]
    private int itemCost;
    public int ItemCost { get { return itemCost; } }
    //아이템의 가격
}
