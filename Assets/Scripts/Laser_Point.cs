using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser_Point : MonoBehaviour {

    private SteamVR_TrackedObject myTrackedObject;
    private SteamVR_Controller.Device myControllerDevice
    {
        get { return SteamVR_Controller.Input((int)myTrackedObject.index); }

    }

    public GameObject myLaserPrefab;
    private GameObject myLaser;
    private Transform myLaserTransform;
    private Vector3 myHitPoint;
    private void ShowmyLaser(RaycastHit hit)
    {
        myLaser.SetActive(true);
        myLaserTransform.position = Vector3.Lerp(myTrackedObject.transform.position, myHitPoint, .5f);
        myLaserTransform.LookAt(myHitPoint);
        myLaserTransform.localScale = new Vector3(myLaserTransform.localScale.x, myLaserTransform.localScale.y, hit.distance);
    }

    // Use this for initialization
    void Start () {

        myTrackedObject = GetComponent<SteamVR_TrackedObject>();
        myLaser = Instantiate(myLaserPrefab);
        myLaserTransform = myLaser.transform;
        
    }
	
	// Update is called once per frame
	void Update () {

        if (myControllerDevice.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            RaycastHit hit;
            if (Physics.Raycast(myTrackedObject.transform.position, transform.forward, out hit, 1000))
            {
                myHitPoint = hit.point;
                ShowmyLaser(hit);
            }
        }
        else
        {
            myLaser.SetActive(false);
        }
	}
}
