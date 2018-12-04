using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SB_tut_end : StateMachineBehaviour {

    GameObject tutorial; 
	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	//override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        TutorialManager.Instance.mState = TutorialManager.Tut_State.Go;
        
        TutorialManager.Instance.tutorial_stuff.SetActive(false);
        ////사운드 재생
        SoundManager_Voice.isPlaying = true;
        GameObject.Find("SoundManager_Voice").GetComponent<SoundManager_Voice>().voiceNum = 1;


    }

    // OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    //
    //}
}
