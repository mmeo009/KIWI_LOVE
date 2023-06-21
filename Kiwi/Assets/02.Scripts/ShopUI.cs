using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    public GameObject play,eat,clean;

    bool playactive = false;
    bool eatactive = false;
    bool cleanactive = false;
    public void Awake()
    {
        play.SetActive(playactive);
        eat.SetActive(eatactive);
        clean.SetActive(cleanactive);
    }
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
}
