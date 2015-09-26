using UnityEngine;
using System.Collections;

public class SceneryMovement : MonoBehaviour {
    public enum Direction { Left = -1, Right = 1};
    public float speed = 1;
    public Direction direction = Direction.Right;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(speed * Time.deltaTime * (float)direction, 0, 0);
	}
}
