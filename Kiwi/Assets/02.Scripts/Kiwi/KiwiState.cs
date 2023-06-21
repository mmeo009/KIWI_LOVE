using System.Collections;
using UnityEngine;
using UnityEngine.XR;

public class KiwiState : MonoBehaviour
{
    public enum CharacterStates
    {
        Idle,
        Die,
        Play,
        Eat
    }
    public Animator anim;

    private readonly int hashEat = Animator.StringToHash("Eat");
    private readonly int hashPlay = Animator.StringToHash("Play");
    private readonly int hashFly = Animator.StringToHash("Fly");
    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    public CharacterStates nowState;
    public virtual void StateUpdate(CharacterStates newState)
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
            anim.SetBool(hashPlay, false);
            yield return null;
        }
    }
    IEnumerator Eat()
    {
        while (true)
        {

            yield return null;
        }
    }
    IEnumerator Play()
    {
        while (true)
        {
            anim.SetBool(hashPlay, true);
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

