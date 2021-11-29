using UnityEngine;
using Valve.VR;
using System.Collections;

public class Fire : MonoBehaviour {
	public SteamVR_Action_Boolean trigger;
	public SteamVR_Input_Sources type;
	public float force = 20f;
	public float hitValue = 1f;
	public GameObject hitFX;
	public AudioClip hitSound;
	public  GameObject hand;
	public  GameObject target;

	AudioSource audio;

	void Start () {
		audio = GetComponent<AudioSource>();
	}

	void Update () {
		if (trigger.GetLastStateDown(type) && Time.timeScale == 1
			&& !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) {
			Ray ray = new Ray(hand.transform.position, target.transform.position);
			Debug.DrawRay(ray.origin, ray.direction, Color.green);
			RaycastHit hit;
			audio.PlayOneShot(hitSound);
			if (Physics.Raycast (ray, out hit)) {
				Instantiate (hitFX, hit.point, Quaternion.identity);
				if (hit.rigidbody) {
					hit.rigidbody.AddForceAtPosition(force*ray.direction, 
					                                 hit.point, ForceMode.Impulse);
					hit.transform.SendMessage("Hit", hitValue);
				}
			}	
		}
	}
}