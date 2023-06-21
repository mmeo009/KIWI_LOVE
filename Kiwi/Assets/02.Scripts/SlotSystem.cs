using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotSystem : MonoBehaviour
{
    public Item[] scriptableObject;
    public GameObject[] itemObject;
    public GameObject[] hue;
    public Animator KiwiAnim;
    public float timer = 3.0f;
    public bool button = false;
    protected GameManager GameManager => GameManager.Instance;
    private void Start()
    {
        KiwiAnim = GameObject.FindGameObjectWithTag("Kiwi").GetComponent<Animator>();
    }
    private void Update()
    {
        if(button == true)
        {
            timer -= Time.deltaTime;
        }
        if(timer <= 0)
        {
            ByeGH();
        }
    }
    private void ByeGH()
    {
        for(int i = 0; i < itemObject.Length; i++)
        {
            itemObject[i].gameObject.active = false;
        }
        for (int i = 0; i < hue.Length; i++)
        {
            hue[i].gameObject.active = false;
        }
        KiwiAnim.SetBool("Play", false);
        KiwiAnim.SetBool("Eat", false);
        timer = 3.0f;
        button = false;
    }
    public void PressButton(int itemNum)
    {
        if (button == false)
        {
            if (scriptableObject[itemNum].itemCost < GameManager.Coin)
            {
                if (itemNum != 17)
                {
                    itemObject[itemNum].gameObject.active = true;
                }
                else
                {
                    int Color = Random.Range(1, 4);
                    switch(Color)
                    {
                        case 1:
                            hue[0].gameObject.active = true;
                            break;
                        case 2:
                            hue[1].gameObject.active = true;
                            break;
                        case 3:
                            hue[2].gameObject.active = true;
                            break;
                    }
                }
                GameManager.UseCoin(scriptableObject[itemNum].itemCost);
                switch (itemNum)
                    {
                        case 0:
                            Debug.Log("¸Þ¶Ñ±â ¸ÀÀÖ´Ù");
                            break;

                        case 1:
                            Debug.Log("··ÀÌ ¸ÀÀÖ´Ù");
                            break;

                        case 2:
                            Debug.Log("½ºÆ© ¸ÀÀÖ´Ù");
                            break;

                        case 3:
                            Debug.Log("3´ë 500");
                            break;
                        case 4:
                            Debug.Log("ÁÖ¸ùÀÇ ÈÄ¿¹");
                            break;
                        case 5:
                            Debug.Log("³Ñ¾î°¡~");
                            break;
                        case 6:
                            Debug.Log("½Ã¿ø");
                            break;
                        case 7:
                            Debug.Log("¹­¾î");
                            break;
                        case 8:
                            Debug.Log("½»½»");
                            break;
                        case 9:
                            Debug.Log("»óÅ­ÇÑ ¾ÖÇÃ");
                            break;
                        case 10:
                            Debug.Log("µû²öÇÑ ºê·¹µå");
                            break;
                        case 11:
                            Debug.Log("»Í»Í");
                            break;
                        case 12:
                            Debug.Log("°í±Þ½º·¯¿î ÇÇ¸®");
                            break;
                        case 13:
                            Debug.Log("Ä¡ÀÌÀÌÀÍ");
                            break;
                        case 14:
                            Debug.Log("Ã·º¡Ã·º¡");
                            break;
                        case 15:
                            Debug.Log("¸ÀÀÖ´Â ¾¾¸®¾ó");
                            break;
                        case 16:
                            Debug.Log("¸®¾ó °»½ºÅÍ");
                            break;
                    }
                
                

                if (scriptableObject[itemNum].itemType == 0)
                {
                    GameManager.kiwi.GetFull(scriptableObject[itemNum].plusAmount);
                    KiwiAnim.SetBool("Eat", true);
                }
                else if (scriptableObject[itemNum].itemType == 1)
                {
                    GameManager.kiwi.GetPlay(scriptableObject[itemNum].plusAmount);
                    if(scriptableObject[itemNum].itemName != "Hue")
                    {
                        KiwiAnim.SetBool("Play", true);
                    }
                }
                else
                {
                    GameManager.kiwi.GetClean(scriptableObject[itemNum].plusAmount);
                    KiwiAnim.SetBool("Clean", true);
                }
                button = true;
            }
        }

    }
}


