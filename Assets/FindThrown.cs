using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FindThrown : NPCbaseFSM
{
    GameObject[] Distractions;

    void awake()
    {
        Distractions = GameObject.FindGameObjectsWithTag("DistractionPoint");

    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Distractions = GameObject.FindGameObjectsWithTag("DistractionPoint");
        base.OnStateEnter(animator, stateInfo, layerIndex);
        //agent.isStopped = false;
    }

    void FixedUpdate()
    {
        Distractions = GameObject.FindGameObjectsWithTag("DistractionPoint");
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (Distractions.Length == 0 || Distractions[0] != null) return;
        agent.destination = Distractions[0].transform.position;
        /*
        if (Vector3.Distance(Distractions[0].transform.position,
        NPC.transform.position) < accuracy)
        {
            agent.destination = Distractions[0].transform.position;
        }
        */



        //agent.SetDestination(Distractions[0].transform.position);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //agent.isStopped = true;
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
