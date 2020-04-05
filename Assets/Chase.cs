using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Chase : NPCbaseFSM
{
    public AudioSource fstep;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       base.OnStateEnter(animator,stateInfo,layerIndex);
       fstep = animator.gameObject.GetComponent<AudioSource>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (!fstep.isPlaying && fstep != null)
        {
            fstep.volume = Random.Range(0.8f, 1);
            fstep.pitch = Random.Range(0.8f, 1.1f);
            fstep.Play();
        }
        agent.SetDestination(opponent.transform.position);
      //  var direction = opponent.transform.position - NPC.transform.position;
      //  NPC.transform.rotation = Quaternion.Slerp(NPC.transform.rotation,
      //  Quaternion.LookRotation(direction),
      //  rotSpeed * Time.deltaTime);

      //  NPC.transform.Translate(0, 0, Time.deltaTime * speed);
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
}
