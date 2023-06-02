using System.Collections;
using System.Collections.Generic;
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
        Cute
    }
        public Animator anim;

        private readonly int hashRun = Animator.StringToHash("IsRun");
        private readonly int hashJump = Animator.StringToHash("IsJump");
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
                anim.SetBool(hashJump, true);
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
        IEnumerator Cute()
        {
            while (true)
            {
                yield return null;
            }
        }

    }

