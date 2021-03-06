﻿using UnityEngine;
using System.Collections;
using System;

public class ArrowAI : MonoBehaviour {

    public GameObject player;
    public GameObject target;

    public int radius;
	// Use this for initialization
	void Start () {
        radius = 5;
        player = GameObject.FindGameObjectWithTag("Player");
        target = GameObject.FindGameObjectWithTag("Snitch");
        if (target != null)
        {
            transform.LookAt(target.transform.position);
            transform.Rotate(new Vector3(0, -90, 0), Space.Self);
            transform.position = (transform.position - target.transform.position).normalized * -radius + player.transform.position;
        }
        
    }
	
	// Update is called once per frame
	void Update () {
        if (target != null && Math.Abs(Vector3.Distance(transform.position, target.transform.position)) > radius/2)
        {
            transform.LookAt(target.transform);
            transform.Rotate(new Vector3(0, -90, 0), Space.Self);
            transform.position = (transform.position - target.transform.position).normalized * -radius + player.transform.position;
        }
    }
}
