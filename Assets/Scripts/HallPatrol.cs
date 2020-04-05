using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HallPatrol : NPCbaseFSM
{
    GameObject[] waypoints;
    int currentWP;
    public AudioSource fstep;

    void awake()
    {
        waypoints = GameObject.FindGameObjectsWithTag("hallpoints");
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        waypoints = GameObject.FindGameObjectsWithTag("hallpoints");
        //Debug.LogError(animator.gameObject.name);
        base.OnStateEnter(animator, stateInfo, layerIndex);
        currentWP = Random.Range(0, waypoints.Length);
        agent.isStopped = false;
        fstep = animator.gameObject.GetComponent<AudioSource>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (waypoints.Length == 0) return;

        if (Vector3.Distance(waypoints[currentWP].transform.position,
        NPC.transform.position) < accuracy)
        {
            currentWP = Random.Range(0, waypoints.Length);
            if (currentWP >= waypoints.Length)
            {
                currentWP = 0;
            }
        }
        

        agent.SetDestination(waypoints[currentWP].transform.position);

        if (!fstep.isPlaying && fstep != null)
        {
            fstep.volume = Random.Range(0.8f, 1);
            fstep.pitch = Random.Range(0.8f, 1.1f);
            fstep.Play();
        }
        //rotate to face target waypoint
        // var direction = waypoints[currentWP].transform.position - NPC.transform.position;
        // NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation, 
        // Quaternion.LookRotation(direction), 
        // rotSpeed * Time.deltaTime);

        // NPC.transform.Translate(0, 0, Time.deltaTime * speed);

    }

    void FixedUpdate()
    {
        Debug.Log("jamasdasdasdasdasd");
        if (!fstep.isPlaying)
        {
            fstep.volume = Random.Range(0.8f, 1);
            fstep.pitch = Random.Range(0.8f, 1.1f);
            fstep.Play();
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //agent.Stop();
        //agent.isStopped = true;
        agent.ResetPath();
    }
}