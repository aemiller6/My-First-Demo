using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monolith_Events : MonoBehaviour {

    public AudioClip sound;

    private AudioSource source { get { return GetComponent<AudioSource>(); } }

        private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Ground")
        {
            var joint = AddFixedJoint();
            joint.connectedBody = collision.gameObject.GetComponent<Rigidbody>();
            Debug.Log(gameObject.name + "Collided with Ground");
            PlaySound();
        }
    }

    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 2000;
        fx.breakTorque = 2000;
        return fx;
    }

    private void PlaySound()
    {
        source.PlayOneShot(sound);
        Debug.Log("Play Audio");
    }

    // Use this for initialization
    void Start () {
        gameObject.AddComponent<AudioSource>();
        source.clip = sound;
        source.playOnAwake = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
