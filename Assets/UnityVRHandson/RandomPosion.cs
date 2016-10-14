using UnityEngine;
using System.Collections;

public class RandomPosion : MonoBehaviour {
    Transform pos; //

    // Use this for initialization
    void Start () {
        pos = GetComponent<Transform>();
    }
	
	// Update is called once per frame
	void Update () {
    }

    void OnCollisionEnter(Collision collision)
    {
        float x = Random.Range(-5, 5);
        float z = Random.Range(-5, 5);
        pos.transform.position = new Vector3(x, 0.5f, z);
    }
}
