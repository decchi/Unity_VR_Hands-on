using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

    private Transform tr;
    public float speed = 0.1f;


    // Use this for initialization
    void Start () {
        tr = GetComponent<Transform>();

    }
	
	// Update is called once per frame
	void Update () {
        if (FlagManager.moveFlg)
        {
            Vector3 toward = tr.TransformDirection(Vector3.forward) * speed; //向いている方向にspeed分進んだ位置を取得
            tr.position += new Vector3(toward.x, 0, toward.z);  //X成分とZ成分のみ反映

        }
    }
}
