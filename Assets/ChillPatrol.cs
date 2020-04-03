using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChillPatrol : StateMachineBehaviour
{
    GameObject[] NPCwaypoints;
    //public GameObject NPC
    //public UnityEngine.AI.NavMeshAgent agent;
    int currentWP;
    public GameObject NPC;
    public NavMeshAgent agent;
    public float timeLeft = 10;


    


    void awake()
    {
        
        NPCwaypoints = GameObject.FindGameObjectsWithTag("NPCwaypoint");
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        NPC = animator.gameObject;
        agent = NPC.GetComponent<NavMeshAgent>();
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
        NPC.transform.position) < 2.0)
        {
            animator.SetBool("idle", true);
            Debug.Log("New WP");
            currentWP = Random.Range(1, 3);
            if (currentWP >= NPCwaypoints.Length)
            {
                currentWP = 0;
            }
        }

        
        


        agent.SetDestination(NPCwaypoints[currentWP].transform.position);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.ResetPath();
    }
}
