using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleBasedOnControllerDistance : MonoBehaviour {

    private GameObject theLeftController;
    private GameObject theRightController;
    // Use this for initialization
    void Start()
    {
        theLeftController = GameObject.FindGameObjectsWithTag("Controller")[0];
        theRightController = GameObject.FindGameObjectsWithTag("Controller")[1];

    }

    // Update is called once per frame
    void Update () {

        //Vector3.Distance(theLeftController.transform.position, theRightController.transform.position)


    }
}

