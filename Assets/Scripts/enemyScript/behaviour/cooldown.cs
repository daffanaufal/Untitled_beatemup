using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cooldown : StateMachineBehaviour
{
    float timer;
    public float timeIdle;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer=0;    
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer+=Time.deltaTime;
        if (timer > timeIdle)
            animator.SetBool("isCooldown", false);    
    }
}
