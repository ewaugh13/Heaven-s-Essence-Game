﻿using UnityEngine;
using System.Collections;

public class AnimatorScript : MonoBehaviour
{

    public GameObject particleSystem;
    public GameObject attackPoint;
	public bool useController;
    public bool PS4Controller;
    public bool XBoxController;

    //public GameObject weaponPosition;
    private Animator animator;
	private Vector3 lookDirection;
    // Use this for initialization
    void Start()
    {
        animator = this.GetComponent<Animator>();
        PS4Controller = false;
        XBoxController = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale != 0)
        {
			Vector3 previousDirection = lookDirection;
			if (useController)
			{
                if(PS4Controller)
                {
                    lookDirection = new Vector3(10 * Input.GetAxis("PS4RHorizontal") + this.transform.position.x, (-10) * Input.GetAxis("PS4RVertical") + this.transform.position.y, 0);
                    if (Input.GetAxis("PS4RHorizontal") == 0 && Input.GetAxis("PS4RVertical") == 0)
                    {
                        lookDirection = previousDirection;
                    }
                }
                else if(XBoxController)
                {
                    lookDirection = new Vector3(10 * Input.GetAxis("XBoxRHorizontal") + this.transform.position.x, (-10) * Input.GetAxis("XBoxRVertical") + this.transform.position.y, 0);
                    if (Input.GetAxis("XBoxRHorizontal") == 0 && Input.GetAxis("XBoxRVertical") == 0)
                    {
                        lookDirection = previousDirection;
                    }
                }
			}
			else
			{
            	lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			}
            lookDirection.z = 0f;

            var xDiff = Mathf.Abs(this.transform.position.x - lookDirection.x);
            var yDiff = Mathf.Abs(this.transform.position.y - lookDirection.y);


            if (xDiff < yDiff)
            {
                //up
                if (lookDirection.y > this.transform.position.y)
                {
                    animator.SetInteger("Direction", 2);
                    fire(2);
                    this.gameObject.transform.GetChild(0).transform.position = new Vector3(.5f, 0, 0) + this.gameObject.transform.position;
                    attackPoint.transform.position = new Vector3(0, 1.25f, 0) + this.gameObject.transform.GetChild(0).transform.position;
                    particleSystem.transform.position = new Vector3(0, .73f, 0) + this.gameObject.transform.position;
                    particleSystem.transform.rotation = Quaternion.Euler(215f, 0f, 0);
                }
                //down
                else {
                    animator.SetInteger("Direction", 0);
                    fire(0);
                    this.gameObject.transform.GetChild(0).transform.position = new Vector3(-.5f, 0, 0) + this.gameObject.transform.position;
                    attackPoint.transform.position = new Vector3(0, -1f, 0) + this.gameObject.transform.GetChild(0).transform.position;
                    particleSystem.transform.position = new Vector3(0, .73f, 1) + this.gameObject.transform.position;
                    particleSystem.transform.rotation = Quaternion.Euler(215f, 0f, 0);
                }

                this.gameObject.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
                this.gameObject.GetComponentInParent<BoxCollider2D>().offset = new Vector2(0, 0);

            }

            else {

                this.gameObject.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = true;

                //right
                if (lookDirection.x > this.transform.position.x)
                {
                    animator.SetInteger("Direction", 1);
                    fire(1);
                    this.gameObject.transform.GetChild(0).transform.position = new Vector3(1.25f, .5f, 0) + this.gameObject.transform.position;       // this should be (.25, .1, 0) but scalling makes it need to be this
                    this.gameObject.GetComponentInParent<BoxCollider2D>().offset = new Vector2(-.5f, 0);
                    attackPoint.transform.position = new Vector3(.5f, 0, 0) + this.gameObject.transform.GetChild(0).transform.position;
                    particleSystem.transform.position = new Vector3(-.66f, .73f, 0) + this.gameObject.transform.position;
                    particleSystem.transform.rotation = Quaternion.Euler(335f, 265f, 0);
                }
                //left
                else {
                    animator.SetInteger("Direction", 3);
                    fire(3);
                    this.gameObject.transform.GetChild(0).transform.position = new Vector3(-1.25f, .5f, 0) + this.gameObject.transform.position;
                    this.gameObject.GetComponentInParent<BoxCollider2D>().offset = new Vector2(.5f, 0);
                    attackPoint.transform.position = new Vector3(-.5f, 0, 0) + this.gameObject.transform.GetChild(0).transform.position; // add attack point to weapon position
                    particleSystem.transform.position = new Vector3(.66f, .73f, 0) + this.gameObject.transform.position;
                    particleSystem.transform.rotation = Quaternion.Euler(215f, 265f, 0);
                }
            }
        }
    }

    void fire(int value)
    {
        if (Input.GetAxis("Fire1") > 0)
        {
            animator.SetInteger("Direction", value);
            animator.SetBool("Shoot", true);
        }
        else {
            animator.SetBool("Shoot", false);
        }
    }
}
