using System.Collections;
using UnityEngine;

public class KiwiState : MonoBehaviour
{
    public enum CharacterStates
    {
        Idle,
        Dirty,
        Boring,
        Hungry,
        Sleep,
        Die,
        eat
    }
    public Animator anim;

    private readonly int hashEat = Animator.StringToHash("Eat");
    private readonly int hashFly = Animator.StringToHash("Fly");
    public void Start()
    {
        anim = GetComponent<Animator>();
    }


    protected CharacterStates nowState;
    protected virtual void StateUpdate(CharacterStates newState)
    {
        StopCoroutine(nowState.ToString());
        nowState = newState;
        Debug.Log(nowState);
        StartCoroutine(nowState.ToString());
    }
    IEnumerator Idle()
    {
        while (true)
        {
            anim.SetBool(hashEat, false);
            anim.SetBool(hashFly, false);
            yield return null;
        }
    }
    IEnumerator eat()
    {
        while (true)
        {
            anim.SetBool(hashEat, true);
            yield return null;
        }
    }
    IEnumerator Dirty()
    {
        while (true)
        {
            yield return null;
        }
    }
    IEnumerator Boring()
    {
        while (true)
        {
            yield return null;
        }
    }
    IEnumerator Hungry()
    {
        while (true)
        {
            anim.SetBool(hashFly, true);
            yield return null;
        }
    }
    IEnumerator Sleep()
    {
        while (true)
        {
            yield return null;
        }
    }
    IEnumerator Die()
    {
        while (true)
        {
            yield return null;
        }
    }

}

