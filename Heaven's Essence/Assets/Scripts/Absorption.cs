﻿using UnityEngine;
using System.Collections;

public class Absorption : MonoBehaviour {

    private BoxCollider2D coll;
	private int killEnemy = 1000000;

    // Use this for initialization
    void Start () {
        coll = this.GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
        int layerMask = 1;
        int layerDepth = layerMask << 9;  //enemies on ninth layer
        if (coll.IsTouchingLayers(layerDepth))
        {
            float angle = 0;
            Collider2D[] hits = Physics2D.OverlapBoxAll(new Vector2(transform.position.x, this.transform.position.y), new Vector2(coll.size.x, coll.size.y), angle, layerDepth);
            foreach(Collider2D hit in hits)
            {
                if (hit.GetComponent<EnemyHealth>() != null && hit.GetComponent<EnemyHealth>().IsBelowThirtyFivePercent())
                {
                    string attackType = hit.name;
                    if (gameObject.activeSelf)
                    {
                        this.gameObject.SendMessage("EnemyAbsorbed", attackType, SendMessageOptions.DontRequireReceiver);
                    }
                    if (hit.gameObject.activeSelf)
                    {
                        hit.gameObject.SendMessage("DealDamage", killEnemy, SendMessageOptions.DontRequireReceiver);
                    }
                }
            }
        }
            
	}
}
