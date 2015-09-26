using UnityEngine;
using System.Collections;

public class AddToTowerLayer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision c)
    {
        if(c.gameObject.layer == 9)
        {
            gameObject.layer = 9;
        }
    }
}
