using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlawTrigger : EnemyTrigger {

    OutlawBehaviour outlaw;

    // Use this for initialization
    void Start () {
        outlaw = GetComponentInChildren<OutlawBehaviour>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //trigger enter
    void OnTriggerEnter(Collider other)
    {
        //check other
        if ((doTriggerPlayer && other.gameObject.CompareTag(targetTag)) || (doTriggerBullet && other.gameObject.CompareTag(bulletTag)) && !isTriggered)
        {
            //check object hasnt been destroyed before being triggered
            if (outlaw)
            {
                isTriggered = true;
                outlaw.target = other.gameObject;
                outlaw.isActive = true;
            }
            
        }
    }
}
