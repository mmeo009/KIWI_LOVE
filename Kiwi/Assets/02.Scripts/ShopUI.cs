using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public GameObject /*inventoryPanel,*/play,eat,clean;
/*    bool activeInventory = false;*/
    bool playactive = false;
    bool eatactive = false;
    bool cleanactive = false;

    private void Start()
    {
/*        inventoryPanel.SetActive(activeInventory);*/
       ;
    }

/*    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            activeInventory =!activeInventory;
            inventoryPanel.SetActive(!activeInventory);
        }
    }*/
    public void PlayShop()
    {
        playactive = !playactive;
        play.SetActive(!playactive);
    }
    public void EatShop()
    {
        eatactive = !eatactive;
        eat.SetActive(!eatactive);
    }
    public void CleanShop()
    {
        cleanactive = !cleanactive;
        clean.SetActive(!cleanactive);
    }

    public void Awake()
    {
        play.SetActive(playactive);
        eat.SetActive(eatactive);
        clean.SetActive(cleanactive);
    }
}
