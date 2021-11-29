using UnityEngine;
using System.Collections;

public class TankBehaviour : MonoBehaviour {

	public float life=1;
	public AudioClip hitSound;
	public AudioClip collectSound;
	public AudioClip dropSound;

	AudioSource AS;

	void Start () {
		AS = GetComponent<AudioSource>();
	}

	void Hit (float damage) {
		life -= damage;
		ScoreCount.UpdateScore(1);
		if (life > 0)
			AS.PlayOneShot(hitSound);
		else
			Kill ();
	}

	void Kill () {
		AudioSource.PlayClipAtPoint(collectSound, transform.position);
		ScoreCount.UpdateScore(5);
		Destroy(gameObject);
	}
}