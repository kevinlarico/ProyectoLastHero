using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour {
	public Vector2 direction;
	public Rigidbody2D rb;
	public float speed;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		speed = 15f;
		Vector3 DireccionBala = PlayerController.instance.DireccionBala.transform.position;
		direction=(Vector2)((DireccionBala-transform.position));
		Vector3 dir = DireccionBala - transform.position;
		direction.Normalize ();
		rb.velocity = direction * speed;

		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
	}
	
	void OnBecameInvisible(){
		Destroy (this.gameObject);
	}
}
