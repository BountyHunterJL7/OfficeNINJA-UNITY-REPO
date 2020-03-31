using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChillPatrol : NPCbaseFSM
{
    GameObject[] NPCwaypoints;
    //public GameObject NPC;
    //public UnityEngine.AI.NavMeshAgent agent;
    int currentWP;

    void awake()
    {
        NPCwaypoints = GameObject.FindGameObjectsWithTag("NPCwaypoint");
        //agent = NPC.GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //NPC = animator.gameObject;
        //agent = NPC.GetComponent<UnityEngine.AI.NavMeshAgent>();
        NPCwaypoints = GameObject.FindGameObjectsWithTag("NPCwaypoint");
        base.OnStateEnter(animator, stateInfo, layerIndex);
        currentWP = Random.Range(1, 3);
        agent.isStopped = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (NPCwaypoints.Length == 0) return;

        if (Vector3.Distance(NPCwaypoints[currentWP].transform.position,
        NPC.transform.position) < 3.0)
        {
            Debug.Log("New WP");
            currentWP = Random.Range(1, 3);
            if (currentWP >= NPCwaypoints.Length)
            {
                currentWP = 0;
            }
        }


        agent.SetDestination(NPCwaypoints[currentWP].transform.position);
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
