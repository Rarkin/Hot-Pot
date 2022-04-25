﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class EnemyTrigger : MonoBehaviour {

    [Header("Tags")]
    public string targetTag = "Player";
    public string bulletTag = "Bullet";

    [Header("Trigger")]
    public bool isTriggered = false; //checks to see if trigger has been triggered
    public bool doTriggerPlayer = true; //checks to see if player should trigger
    public bool doTriggerBullet = false; //checks to see if bullet should trigger

    [Header("Warning")]
    public GameObject WarningObject;
    public float WarningBegan = 0.0f;
    public float WarningTime = 0.5f;
    public float WarningYEndValue = 0.4f;
    public bool WarningActive = false;

    public EnemyBehavior Enemy;

    // Use this for initialization
    void Start () {
        Enemy = GetComponentInChildren<EnemyBehavior>();
    }
	
	// Update is called once per frame
	void Update () {
        if (WarningActive == true)
        {
            WarningBegan = Time.time;
            if (Time.time > WarningTime)
            {
                WarningActive = false;
            }
        }
    }

    //trigger enter
    void OnTriggerEnter(Collider other)
    {
        //check other
        if (((doTriggerPlayer && other.gameObject.CompareTag(targetTag)) || (doTriggerBullet && other.gameObject.CompareTag(bulletTag))) && !isTriggered)
        {
            //Check object hasnt been killed before triggered
            if (Enemy)
            {
                Warning();
                //Setup();
                //change has setup to true
                isTriggered = true;
                Enemy.Activate();
            }
        }
    }

    public void Warning()
    {
        if (WarningObject)
        {
            WarningActive = true;
            Vector3 currentPos = transform.position;
            Vector3 extraHeight = new Vector3(0.0f, 2.0f, 0.0f);
            GameObject Object = Instantiate(WarningObject, currentPos + extraHeight, Quaternion.identity);
            Object.transform.DOScaleY(WarningYEndValue, 0.5f).SetEase(Ease.OutBack, 5f);
        }
    }

}

