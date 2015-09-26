using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraMove : MonoBehaviour {
    public float speed = 3f;
    public static bool towerCollapse = false;
    public bool tc = towerCollapse;
    public static float Height = 0;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Height = transform.position.y;
        tc = towerCollapse;
        Transform t = GetMax();
        Vector2 point = Camera.main.WorldToViewportPoint(t.position);
        if (point.y < 0)
            towerCollapse = true;
        if (t.position.y > transform.position.y)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(transform.position.y, t.position.y, Time.deltaTime * speed), transform.position.z);
        }
	}

    Transform GetMax()
    {
        List<Transform> towerObjects = GetObjectsInLayer(9);
        if (towerObjects.Count < 1)
            return transform;
        Transform t = towerObjects[0].transform;
        foreach(Transform g in towerObjects)
        {
            if (g.position.y > t.position.y)
                t = g.transform;
        }
        return t;
    }
    private List<Transform> GetObjectsInLayer(int layer)
    {
        Transform[] objects = GameObject.FindObjectsOfType(typeof(Transform)) as Transform[];
        List<Transform> to = new List<Transform>();
        if (objects == null)
            return to;
        foreach(Transform t in objects)
        {
            if (t.gameObject.layer == layer)
                to.Add(t);
        }
        return to;
    }

}
