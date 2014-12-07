using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public Tentacle tentacle;
	public ParticleSystem smoke;

	public void Fire() {
		tentacle.isDead = true;
		smoke.Play();
	}

	private void Awake () {
	
	}

	private void Update () {
	
	}
}
