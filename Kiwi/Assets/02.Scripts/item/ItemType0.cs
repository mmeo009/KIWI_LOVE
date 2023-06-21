using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemType0 : MonoBehaviour
{
    Animator anim;
        private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        if(this.gameObject.tag == "Worm" || this.gameObject.tag == "GH")
        {
            int aB = Random.Range(1, 3);
            if(aB == 1)
            {
                anim.SetTrigger("AwakeA");
            }
            else
            {
                anim.SetTrigger("AwakeB");
            }
        }
        else
        {
            anim.SetTrigger("Awake");
        }
    }
}
