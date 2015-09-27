using UnityEngine;
using System.Collections;

public class RopeRender : MonoBehaviour {

	LineRenderer lrend;
	public Transform start;
	public Transform finish;

	// Use this for initialization
	void Start () {
		lrend = GetComponent<LineRenderer>();
		Update();
	}
	
	// Update is called once per frame
	void Update () {
		lrend.SetPosition(0,start.position);
		lrend.SetPosition(1,finish.position);
	}
}
