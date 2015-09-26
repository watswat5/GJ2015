using UnityEngine;
using System.Collections;

public class follwCamera : MonoBehaviour {
    private float offset;

	// Use this for initialization
	void Start () {
        offset = Camera.main.transform.position.y - transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 temp = transform.position;
        temp.y = Camera.main.transform.position.y + offset;
        transform.position = temp;
	}
}
