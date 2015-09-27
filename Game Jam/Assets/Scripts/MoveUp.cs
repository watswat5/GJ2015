using UnityEngine;
using System.Collections;

public class MoveUp : MonoBehaviour {
    public float speed = 1f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(0, speed * Time.deltaTime, 0);
	}
}
