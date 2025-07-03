using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public Animator animator;
    public List<AnimatorSetup> animatorSetups;
    public enum AnimatorType
    {
        IDLE,
        RUN,
        DEATH
    }

    public void Play(AnimatorType type)
    {
        foreach (var animation in animatorSetups)
        {
            if (animation.type == type)
            {
                animator.SetTrigger(animation.trigger);
                break;
            }
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Play(AnimatorType.RUN);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Play(AnimatorType.DEATH);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Play(AnimatorType.IDLE);
        }
    }
}

[System.Serializable]
 public class AnimatorSetup
 {
     public AnimatorManager.AnimatorType type;
     public string trigger;
 }

