using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReporterScript : MonoBehaviour {

    public GameObject pointerTarget = null;
    private GameObject theLeftController;
    private GameObject theRightController;
    // Use this for initialization
    void Start () {
        theLeftController = GameObject.FindGameObjectsWithTag("Controller")[0];
        theRightController = GameObject.FindGameObjectsWithTag("Controller")[1];

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnGUI() {
        string displayString = "blah";
        int count = GameObject.FindGameObjectsWithTag("BuildingBlock").Length;

        /*
        if (pointerTarget != null) {
            displayString = pointerTarget.name;
        }*/

        //displayString = "there are " + count.ToString() + " blocks in the world";

        displayString = "controllers are " + Vector3.Distance(theLeftController.transform.position, theRightController.transform.position).ToString() + " units apart";

        GUI.Label(new Rect(Screen.width/2, Screen.height/2, 300, 20), displayString);        
    }
}
