using UnityEngine;
using System.Collections;

public class ObjectManager : MonoBehaviour {

    public bool floating = true;

    void Start()
    {
        Invoke("ToggleFloat", 5);
        tag = "floating";
    }

    void FixedUpdate()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        if (tag == "floating")
        {   
            body.useGravity = false;
        }
        else
        {
            body.useGravity = true;

        }
    }

    public void ToggleFloat()
    {
        tag = "Untagged";
        transform.parent = null;
    }

}
