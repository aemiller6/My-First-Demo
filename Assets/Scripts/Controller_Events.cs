using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller_Events : MonoBehaviour {

    private SteamVR_TrackedObject myTrackedObject;
    private SteamVR_Controller.Device myControllerDevice
    {
        get { return SteamVR_Controller.Input((int)myTrackedObject.index); }
              
    }

	// Use this for initialization
	void Start () {

        myTrackedObject = GetComponent<SteamVR_TrackedObject>();
     
    }
	
	// Update is called once per frame

	void Update () {
        if (myControllerDevice.GetHairTriggerDown())
        {
            Debug.Log(gameObject.name + "CE: Trigger Down.");
        }
        if (myControllerDevice.GetHairTriggerUp())
        {
            Debug.Log(gameObject.name + "CE: Trigger Up.");
        }
        if (myControllerDevice.GetPressDown(SteamVR_Controller.ButtonMask.Grip))
        {
            Debug.Log(gameObject.name + "CE: Grip Pressed.");
        }
        if (myControllerDevice.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
        {
            Debug.Log(gameObject.name + "CE: Grip Released.");
        }
        if (myControllerDevice.GetPressDown(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
            Debug.Log(gameObject.name + "CE: App Menu Button Pressed.");
        }
        if (myControllerDevice.GetPressUp(SteamVR_Controller.ButtonMask.ApplicationMenu))
        {
            Debug.Log(gameObject.name + "CE: App Menu Button Released.");
        }
        if (myControllerDevice.GetPressDown(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Debug.Log(gameObject.name + "CE: Touchpad Pressed.");
        }
        if (myControllerDevice.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
            Debug.Log(gameObject.name + "CE: Touchpad Released.");
        }
	}
}
