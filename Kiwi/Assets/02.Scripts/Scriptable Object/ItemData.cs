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
    //0 == ����, 1 == û��, 2 == ġ���, 3 == ��Ÿ ������(������ ����)
    [SerializeField]
    private int addPoint;
    public int AddPoint { get { return addPoint; } }
    //������
    [SerializeField]
    private int decreasePoint;
    public int DecreasePoint { get { return decreasePoint; } }
    //�������
    [SerializeField]
    private int itemCost;
    public int ItemCost { get { return itemCost; } }
    //�������� ����
    [SerializeField]
    private Sprite itemImage;
    public Sprite ItemImage { get { return itemImage; } }
    //�������� ��������Ʈ
    [SerializeField]
    private string itemName;
    public string ItemName { get { return itemName; } }
    //�������� �̸�
}
