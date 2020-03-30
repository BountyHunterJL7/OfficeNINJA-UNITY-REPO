using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : NPCbaseFSM
{
    GameObject[] waypoints;
    int currentWP;

    void awake()
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
        
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint");
        base.OnStateEnter(animator,stateInfo,layerIndex);
        currentWP = Random.Range(1, 7);
        agent.isStopped = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {   
        if(waypoints.Length == 0) return;
        if (Vector3.Distance(waypoints[currentWP].transform.position, 
        NPC.transform.position) < accuracy)
        {
            currentWP = Random.Range(1, 7);
            if (currentWP >= waypoints.Length)
            {
                currentWP = 0;
            }
        }


        agent.SetDestination(waypoints[currentWP].transform.position);
        //rotate to face target waypoint
        // var direction = waypoints[currentWP].transform.position - NPC.transform.position;
        // NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation, 
        // Quaternion.LookRotation(direction), 
        // rotSpeed * Time.deltaTime);

        // NPC.transform.Translate(0, 0, Time.deltaTime * speed);

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //agent.Stop();
        //agent.isStopped = true;
        agent.ResetPath();
    }
}
