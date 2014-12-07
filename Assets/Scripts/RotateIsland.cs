using UnityEngine;
using System.Collections;

public class RotateIsland : MonoBehaviour {

	private Transform cachedTransform;
	private Transform player;

	public float speed = 10.0f;

	private void Awake () {
		cachedTransform = transform;
		player = GameObject.Find("Player").GetComponent<Transform>();
	}

	private void Update () {
		Vector3 dirToPlayer = player.position - cachedTransform.position;
		dirToPlayer.y = 0.0f;
		// dirToPlayer = dirToPlayer.normalized;
		float angle = Vector3.Angle(Vector3.back, dirToPlayer);
		// Debug.DrawLine(cachedTransform.position, Vector3.back * 500.0f + cachedTransform.position, Color.white);
		// Debug.DrawLine(cachedTransform.position, dirToPlayer * 500.0f + cachedTransform.position, Color.green);
		// Debug.Log("X: " + player.position.x);
		// Debug.Log(angle * Mathf.Sign(player.position.x));
		// Debug.Log(angle);
		if (angle * Mathf.Sign(player.position.x) > 5.0f) {
			// cachedTransform.forward = Vector3.Lerp(cachedTransform.forward, -dirToPlayer, Time.deltaTime * speed);
			cachedTransform.Rotate(Vector3.up * Time.deltaTime * Mathf.Lerp(0.0f, speed, (angle - 5.0f)) / 5.0f);
		}
		if (angle * Mathf.Sign(player.position.x) < -5.0f) {
			cachedTransform.Rotate(-Vector3.up * Time.deltaTime * Mathf.Lerp(0.0f, speed, (angle - 5.0f)) / 5.0f);
		}
	}
}
