using UnityEngine;
using System.Collections;

public class Tentacle : MonoBehaviour {

	public BoxCollider boxCollider;
	public Animator tentacleAnimator;
	public bool isDead = false;

	private void Update () {
		if (isDead) {
			tentacleAnimator.SetBool("Dead", isDead);
			boxCollider.enabled = false;
			this.enabled = false;
		}
	}

	private void OnTriggerEnter(Collider other) {
		MainQuest.instance.isLose = true;
    }

    private void OnDrawGizmos() {
		Gizmos.color = Color.green;
		if (boxCollider != null)
			Gizmos.DrawWireCube(transform.position, -boxCollider.size);
	}
}
