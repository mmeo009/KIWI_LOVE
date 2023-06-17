using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu]
public class Item : ScriptableObject
{
    public string itemName;
    //아이템 이름
    public Sprite itemImage;
    //아이템 이미지
    public int itemType;
    //0 == 음식(food), 1 == 치장용(deco/play), 2 == 청결(clean), 3 == 기타 아이템(레벨업 관련)
    public int itemCost;
    //아이템의 가격
}



