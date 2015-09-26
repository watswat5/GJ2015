using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject[] spawnables;
    public static bool hasObject;
    Animator mator;

	// Use this for initialization
	void Start () {
        Spawn();
        mator = GetComponentInParent<Animator>();
    }

    void Spawn()
    {
        GameObject go = (GameObject)Instantiate((GameObject)spawnables[0], transform.position, transform.rotation);
        go.transform.parent = transform;
        hasObject = true;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("floating");
        if (gos.Length == 0 && !mator.GetCurrentAnimatorStateInfo(0).IsName("CraneTurn"))
        {
            mator.SetTrigger("Grab");
        }

        if (gos.Length == 0 && mator.GetCurrentAnimatorStateInfo(0).IsName("CraneTurn") && mator.GetCurrentAnimatorStateInfo(0).normalizedTime >= .5)
        {
            Spawn();
            mator.ResetTrigger("Grab");
        }

    }
}
