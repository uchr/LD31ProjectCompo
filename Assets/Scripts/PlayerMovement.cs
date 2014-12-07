using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	private Transform cachedTransform;
	private Transform cachedInner;
	public Animator playerAnimator;

	public float speed = 15.0f;

	private void Awake () {
		cachedTransform = transform;
		cachedInner = GameObject.Find("Player/Inner").GetComponent<Transform>();
	}

	private void Update () {
		Vector3 direct = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
		if (direct.magnitude > 0.5f)
			cachedInner.right = direct.normalized;
		rigidbody.velocity = Vector3.zero;
		playerAnimator.SetFloat("Velocity", direct.magnitude);
		if (direct.magnitude != 0.0f)
			cachedTransform.position += direct * Time.deltaTime * speed;

		RaycastHit hit;
		Ray ray =  new Ray(cachedTransform.position, -Vector3.up);
		//Debug.DrawLine(ray.origin, ray.direction * 500.0f + ray.origin, Color.green);
		var layerMask = 1 << 8;
		if (Physics.Raycast(ray, out hit, 500.0f, layerMask)) {
			Vector3 position = new Vector3(cachedTransform.position.x, hit.point.y + cachedTransform.localScale.y * 3.0f, cachedTransform.position.z);
			//Debug.DrawLine(ray.origin, hit.point);
			transform.position = position;
		}
	}
}
