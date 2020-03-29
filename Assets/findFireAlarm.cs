using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class findFireAlarm : NPCbaseFSM
{
    GameObject AlarmPosition;
    float alarmDistance;
    private void Awake()
    {
        AlarmPosition = GameObject.FindGameObjectWithTag("FireAlarm");
    }
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        AlarmPosition = GameObject.FindGameObjectWithTag("FireAlarm");
        base.OnStateEnter(animator, stateInfo, layerIndex);
    }

    void FixedUpdate()
    {
        AlarmPosition = GameObject.FindGameObjectWithTag("FireAlarm");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("GotTotheagent");
        agent.destination = AlarmPosition.transform.position;
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.ResetPath();
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
