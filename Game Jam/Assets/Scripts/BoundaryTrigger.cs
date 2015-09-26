using UnityEngine;
using System.Collections;

public class BoundaryTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider c)
    {
        if(c.gameObject.layer == 9)
        {
            CameraMove.towerCollapse = true;
        }
    }
}
