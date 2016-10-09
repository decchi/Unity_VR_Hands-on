using UnityEngine;
using System.Collections;

public class InvisibleWhenMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (FlagManager.moveFlg)
        {
            gameObject.SetActive(false);
        }
	
	}
}
