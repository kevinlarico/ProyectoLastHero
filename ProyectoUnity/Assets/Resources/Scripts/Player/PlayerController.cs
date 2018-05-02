using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	public static PlayerController instance;
	public Vector2 vec;
	public Vector2 vecContinuo;
	public float yPrimero;
	public float yContinuo;
	public float Rotacion;
	public GameObject PosicionBala;
	public GameObject DireccionBala;
	public GameObject Shoot;
	// Use this for initialization
	void Awake () {
		instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			vec = Input.mousePosition;
			yPrimero = vec.y;
		}
		if (Input.GetMouseButton (0)) {
			vecContinuo = Input.mousePosition;
			yContinuo = vecContinuo.y;
			Rotacion = yPrimero - yContinuo;
			//-46 + 60
			Rotacion=Mathf.Clamp(Rotacion,-46f,60f);
			transform.rotation = Quaternion.AngleAxis (Rotacion, Vector3.forward);

		}
		if (Input.GetMouseButtonUp (0)) {
			Instantiate (Shoot, PosicionBala.transform.position, Quaternion.identity);
		}
	}
}
