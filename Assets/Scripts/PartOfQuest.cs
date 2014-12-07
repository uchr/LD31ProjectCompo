using UnityEngine;
using System.Collections;

public class PartOfQuest : MonoBehaviour {

	public Transform collider = null;
	public int stage = 0;

	private void OnTriggerEnter(Collider other) {
		MainQuest.instance.NextStage(stage);
		collider.gameObject.SetActive(false);
    }

	private void OnDrawGizmos() {
		Gizmos.color = Color.green;
		if (collider != null)
			Gizmos.DrawWireSphere(transform.position, collider.localScale.x);
	}
}
