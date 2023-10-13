using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characteranimation : MonoBehaviour
{
    private Animator anim;
    private AttackUniversal attackUniversal;

    void Awake()
    {
        anim = GetComponent<Animator>();
        attackUniversal = GetComponent<AttackUniversal>();
    }

    public void Walk(bool move)
    {
        anim.SetBool("Movement", move);
    }

    public void Punch()
    {
        anim.SetTrigger(AnimationTags.PUNCH_TRIGGER);
    }

    public void Punch_2()
    {
        anim.SetTrigger(AnimationTags.PUNCH2_TRIGGER);
    }

    public void Punch_3()
    {
        anim.SetTrigger(AnimationTags.PUNCH3_TRIGGER);
    }

    public void Kick()
    {
        anim.SetTrigger(AnimationTags.KICK_TRIGGER);
    }

    public void Kick_2()
    {
        anim.SetTrigger(AnimationTags.KICK2_TRIGGER);
    }

    public void Kick_3()
    {
        anim.SetTrigger(AnimationTags.KICK3_TRIGGER);
    }

    public void Jump()
    {
        anim.SetTrigger(AnimationTags.JUMP_TRIGGER);
    }
}
