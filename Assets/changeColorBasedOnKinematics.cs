using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColorBasedOnKinematics : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Renderer rend = GetComponent<Renderer>();
        rend.material.shader = Shader.Find("Standard");

        if (GetComponentInParent<Rigidbody>().isKinematic) {
            rend.material.SetColor("_Color", Color.gray);
        }
        else {
            rend.material.SetColor("_Color", Color.blue);
        }
    }
}
