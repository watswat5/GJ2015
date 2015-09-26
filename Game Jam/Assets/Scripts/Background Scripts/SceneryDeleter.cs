using UnityEngine;
using System.Collections;

public class SceneryDeleter : MonoBehaviour {
    public SceneryMovement.Direction side;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider c)
    {
        if(side == SceneryMovement.Direction.Right)
        {
            if (c.gameObject.tag == "right")
                Destroy(c.gameObject);
        }
        else
        {
            if (c.gameObject.tag == "left")
                Destroy(c.gameObject);
        }
    }
}
