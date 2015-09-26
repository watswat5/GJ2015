using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ScenerySpawner : MonoBehaviour {
    private List<GameObject> scenery;
    public List<GameObject> low, mid, hi;
    public float heightChange = 100;
    public float spawnDelay = 5f;
    private float timer;
    public float depthRange = 5;
    public float heightRange = 10f;
    public float minHeight = 6f;
    public GameObject right, left;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if(CameraMove.Height <= heightChange)
        {
            scenery = low;
        }
        else if(CameraMove.Height > heightChange && CameraMove.Height <= 2 * heightChange)
        {
            scenery = mid;
        }
        else
        {
            scenery = hi;
        }
        timer += Time.deltaTime;
        if(timer >= spawnDelay)
        {
            timer = 0;
            GameObject g = Instantiate(scenery[(int)Random.Range(0, scenery.Count - 1)]) as GameObject;
            int direction = (int)Random.Range(0, 2);
            if(direction == 0)
            {
                g.tag = "right";
                g.transform.position = new Vector3(left.transform.position.x, left.transform.position.y + Random.Range(-heightRange, heightRange), left.transform.position.z + Random.Range(-depthRange, depthRange));
                SceneryMovement sm = g.GetComponent <SceneryMovement> () as SceneryMovement;
                sm.direction = SceneryMovement.Direction.Right;
            }
            else
            {
                g.tag = "left";
                g.transform.position = new Vector3(right.transform.position.x, right.transform.position.y + Random.Range(-heightRange, heightRange), right.transform.position.z + Random.Range(-depthRange, depthRange));
                SceneryMovement sm = g.GetComponent<SceneryMovement>() as SceneryMovement;
                sm.direction = SceneryMovement.Direction.Left;
            }
            if(g.transform.position.y < minHeight)
            {
                g.transform.position = new Vector3(g.transform.position.x, minHeight, g.transform.position.z);
            }
            //float offset = Random.Range(-depthRange, depthRange);
            //g.transform.position = new Vector3(g.transform.position.x, g.transform.position.y, right.transform.position.z + offset);
        }
	}
}
