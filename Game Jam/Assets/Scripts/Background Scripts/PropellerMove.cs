﻿using UnityEngine;
using System.Collections;

public class PropellerMove : MonoBehaviour {
    public float rotateSpeed = 5.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime));
	}
}
