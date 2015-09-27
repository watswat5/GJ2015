using UnityEngine;
using System.Collections;

public class ClawYPos : MonoBehaviour {

	private Vector3 original;
	public Transform yTrans;

	// Use this for initialization
	void Start () {
		original = transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.TransformPoint(original).y > yTrans.position.y)
		{
			Vector3 temp = transform.position;
			temp.y = yTrans.position.y;
			transform.position = temp;
		}
	}
}
