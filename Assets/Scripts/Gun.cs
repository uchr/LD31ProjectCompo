using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	public Tentacle tentacle;
	public ParticleSystem smoke;
	public AudioSource fire;

	public void Fire() {
		tentacle.isDead = true;
		smoke.Play();
		fire.Play();
	}

	private void Awake () {
	
	}

	private void Update () {
	
	}
}
