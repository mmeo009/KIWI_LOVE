using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] Image image; //�̹��� ������Ʈ�� ���� ��

    private Item item;
    public Item Item
    {
        get { return item; }  // item������ �ѱ涧 ���
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

