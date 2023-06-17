using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    [SerializeField] Image image; //�̹��� ������Ʈ�� ���� ��

    private ItemData _item;
    public ItemData item
    {
        get { return _item; }  // item������ �ѱ涧 ���
        set
        {
            _item = value;
            if (_item != null)
            {
                image.sprite = item. ItemImage;
                image.color = new Color(1, 1, 1, 1);
            }
            else
            {
                image.color = new Color(1, 1, 1, 0);
            }
        }
    }
}

