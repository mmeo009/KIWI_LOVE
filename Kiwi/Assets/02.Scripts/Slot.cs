using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] Image image; //이미지 컴포넌트를 담을 곳

    private Item item;
    public Item Item
    {
        get { return item; }  // item정보를 넘길때 사용
        set
        {
            item = value;
            if (item != null)
            {
                image.sprite = item.itemImage;
                image.color = new Color(1, 1, 1, 1);
            }
            else
            {
                image.color = new Color(1, 1, 1, 0);
            }
        }
    }
}

