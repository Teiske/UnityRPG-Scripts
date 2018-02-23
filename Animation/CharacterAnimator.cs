using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimator : MonoBehaviour {

    NavMeshAgent agent;
    Animator animator;

    const float locomationAnimationSmoothTime = .1f;

	void Start () {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
	}

	void Update () {
        float speedPercent = agent.velocity.magnitude / agent.speed;
        animator.SetFloat("speedPercent", speedPercent, locomationAnimationSmoothTime, Time.deltaTime);
	}
}
