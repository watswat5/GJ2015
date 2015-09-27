using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

    public GameObject[] spawnables;
    public static bool hasObject;
	CraneManager crane;

	// Use this for initialization
	void Start () {
		crane = GetComponentInParent<CraneManager>();
    }

    public void Spawn()
    {
        GameObject go = (GameObject)Instantiate((GameObject)spawnables[0], transform.position, transform.rotation);
        go.transform.parent = transform;
        hasObject = true;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] gos = GameObject.FindGameObjectsWithTag("floating");
        if (gos.Length == 0)
        {
			crane.GrabNewItem();
        }
    }
}
