using System.Collections;
using UnityEngine;
using UnityEngine.XR;

public class KiwiState : MonoBehaviour
{
    public enum CharacterStates
    {
        Idle,
        Die,
        Eat
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
    IEnumerator Eat()
    {
        while (true)
        {
            anim.SetBool(hashEat, true);
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

