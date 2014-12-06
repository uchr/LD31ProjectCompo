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
		float angle = Vector3.Angle(Vector3.back + cachedTransform.position, player.position - cachedTransform.position);
		//Debug.DrawLine(cachedTransform.position, Vector3.back * 500.0f + cachedTransform.position, Color.green);
		//Debug.DrawLine(cachedTransform.position, (player.position - cachedTransform.position) * 500.0f + cachedTransform.position, Color.green);
		//Debug.Log("X: " + player.position.x);
		//Debug.Log(angle * Mathf.Sign(player.position.x));
		if (angle * Mathf.Sign(player.position.x) > 10.0f) {
			cachedTransform.Rotate(Vector3.up * Time.deltaTime * Mathf.Lerp(0.0f, speed, (angle - 10.0f)) / 5.0f);
		}
		if (angle * Mathf.Sign(player.position.x) < 10.0f) {
			cachedTransform.Rotate(-Vector3.up * Time.deltaTime * Mathf.Lerp(0.0f, speed, (angle - 10.0f)) / 5.0f);
		}
	}
}
