using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string itemName;
    //������ �̸�
    public Sprite itemImage;
    //������ �̹���
    public int itemType;
    //0 == ����(food), 1 == û��(clean), 2 == ġ���(deco/play), 3 == ��Ÿ ������(������ ����)
    public int itemCost;
    //�������� ����
}



