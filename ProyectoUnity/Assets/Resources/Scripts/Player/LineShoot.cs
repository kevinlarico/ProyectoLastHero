using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LineShoot : MonoBehaviour {
	public Vector3 Init;
	public Rigidbody2D rb;
	public float speed;
	public BoxCollider2D box;
	public GameObject Texto;
	public Text ShootText;
	public int PerfectCount;
	public bool Shooting;
	public GameObject Barra;
	// Use this for initialization
	void Start () {
		Init = transform.position;
		rb = GetComponent<Rigidbody2D> ();
		box = GetComponent<BoxCollider2D> ();
	}

	void FixedUpdate () {
		rb.velocity = new Vector2 (speed,rb.velocity.y);
	}
	void OnTriggerStay2D(Collider2D other){
		if (Shooting != false) {
			switch (other.tag) {
			case "Line/Miss":
				Texto.GetComponent<TextShoot> ().Borrando = true;
				Texto.GetComponent<Text> ().text = "Failed";

				Reset ();

				break;
			case "Line/Cool":
				PlayerController.instance.Shoots ();
				Texto.GetComponent<TextShoot> ().Borrando = true;
				Texto.GetComponent<Text> ().text = "Cool Shoot";

				Reset ();
				break;
			case "Line/Great":
				PlayerController.instance.Shoots();
				Texto.GetComponent<TextShoot> ().Borrando = true;
				Texto.GetComponent<Text> ().text = "Great Shoot";


				Reset ();
				break;
			case "Line/Perfect":
				PlayerController.instance.Shoots ();
				Texto.GetComponent<TextShoot> ().Borrando= true;

				PerfectCount++;
				if (PerfectCount != 0) {
					Texto.GetComponent<Text> ().text = "Perfect Shoot x "+PerfectCount;
				} else {
					Texto.GetComponent<Text> ().text = "Perfect Shoot";
				}
				Shooting = false;
				break;
			case "Line/Exit":
				transform.position = Init;
				break;
			}
		} else {
			if (other.tag == "Line/Exit") {
				transform.position = Init;
			}
		}
	}
	public void Reset(){
		PerfectCount = 0;
		Shooting = false;
	}
}
