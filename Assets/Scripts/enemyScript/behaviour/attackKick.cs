using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackKick : StateMachineBehaviour
{
    float timer;
    Transform player;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        timer=0;    
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(player);
        /*float distance = Vector3.Distance(player.position, animator.transform.position);
        if (distance > 2f)
            animator.SetBool("isKick",false);*/
        timer+=Time.deltaTime;
        if (timer>1)
            {animator.SetBool("isWait",true);}    
    }
}
