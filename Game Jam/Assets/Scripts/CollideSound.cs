using UnityEngine;
using System.Collections;

public class CollideSound : MonoBehaviour {
    public enum ObjectType : int { Book, Glass, Metal, Wood};
    public ObjectType type;
    public float lerpFactor = 2f;
    public AudioClip[] impacts = new AudioClip[4];
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision c)
    {
        Debug.Log("HIT");
        if (gameObject.GetComponent<Rigidbody>().velocity.magnitude > 0.02)
        {
            Debug.Log("PLAY");
            float p = GetComponent<Rigidbody>().velocity.magnitude * .5f; 
            GetComponent<AudioSource>().pitch = Mathf.Clamp(p, 0.5f, 4.0f);
            GetComponent<AudioSource>().PlayOneShot(impacts[(int)type], Mathf.Lerp(0, 1, gameObject.GetComponent<Rigidbody>().velocity.magnitude * lerpFactor * gameObject.GetComponent<Rigidbody>().velocity.magnitude));
        }
    }
}
