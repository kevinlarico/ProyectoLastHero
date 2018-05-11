using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextShoot : MonoBehaviour {
	public float speed;
	public Text texto;
	public bool Borrando;
	public float borrador;
	public Vector3 vec;
	public bool difuminar;
	// Use this for initialization
	void Start () {
		vec = transform.position;
		borrador = 1f;
		speed = 15f;
		texto = GetComponent<Text> ();
	}
	public void End(){
		difuminar = true;
	}
	// Update is called once per frame
	void Update () {

		if (Borrando == true) {
			borrador -= 1 * Time.deltaTime;
			speed = speed + 30 * Time.deltaTime;
			transform.position = new Vector3 (transform.position.x,  transform.position.y+speed*Time.deltaTime, transform.position.z);
		}
			

		Color tmp = texto.color;
		tmp.a = borrador;
		texto.color = tmp;
		if (borrador < 0.05) {
			transform.position = vec;
			texto.text = " ";
			Borrando = false;
			speed = 15f;
			borrador = 1f;
		}
	}

}
