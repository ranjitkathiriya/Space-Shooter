﻿using UnityEngine;
using System.Collections;

public class Rendomrotertor_enemy : MonoBehaviour {

	public float speed;

	void Start(){

		GetComponent<Rigidbody> ().velocity = transform.forward * speed;
	}

}
