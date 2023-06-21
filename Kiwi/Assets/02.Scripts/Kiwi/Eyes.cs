using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    protected GameManager GameManager => GameManager.Instance;
    public GameObject[] eyes;
    public float blinkTimer = 0.2f;
    public int eyeType = 0;
    public bool isClose = false;
    void Awake()
    {
        eyes = GameObject.FindGameObjectsWithTag("Eyes"); //´« Å×±×°¡ ÀÖ´Â Ä£±¸µéÀ» ¸ðµÎ Ã£¾Æ ³ÖÀ½
        GameObject[] temp = eyes;
        for (int i = 0; i < eyes.Length; i++)
        {
            string name = temp[i].name.ToString();
            if (name.Contains(i.ToString()))
            {
                eyes[i] = temp[i];
            }
        }
        // ´«¾Ë ¼ø¼­ Á¤·Ä È¤½Ã ¸ô¶ó¼­

        for(int j = 1; j < eyes.Length; j++)
        {
            eyes[j].gameObject.active = false;
        }
        // ´« ÇÏ³ª»©°í ´Ù ²ô±â
    }
    private void FixedUpdate()
    {
        switch(GameManager.kiwi.count)
        {
            case 0:
                eyeType = 0; 
                break;
            case 1:
                eyeType = 1; 
                break;
            case 2:
                eyeType = 2;
                break;
        }
        blinkTimer -= Time.fixedDeltaTime; // ´« Å¸ÀÌ¸Ó
        if(blinkTimer <= 0)
        {
            Blink(); //´« ±ôºýÀÌ ½ÇÇà
        }
    }
    void Update()
    {
        
    }
    public void Blink()
    {
        for (int i = 0; i < eyes.Length; i++) 
        {
            eyes[i].gameObject.active = false;
        } //ÀÏ´Ü ´« ´Ù ²ô±â
        if (isClose == false)
        {
            eyes[1].gameObject.active = true;
            isClose = true;
            blinkTimer = 0.1f;
        } // ¸¸¾à ´«ÀÌ ¶°ÀÖÀ¸¸é ´« °¨±â
        else
        {
            switch (eyeType)
            {
                case 0:
                    eyes[0].gameObject.active = true;
                    break;
                case 1:
                    eyes[4].gameObject.active = true;
                    break;
                case 2:
                    eyes[5].gameObject.active = true;
                    break;
                case 3:
                    eyes[6].gameObject.active = true;
                    break;
            }
            isClose = false;
            blinkTimer = Random.Range(0.2f, 1.0f);
        } // ¸¸¾à ´«À» °¨°í ÀÖÀ¸¸é ´« ¶ß±â

    }
}
