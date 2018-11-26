﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour {

    Animator animator;
    GameObject whereToGo, House, Melvin, Door;
    bool beenToHouse = false;

	// Use this for initialization
	void Start () {
        animator = GetComponent<Animator>();
        House = GameObject.FindWithTag("RunToPoint");
        Melvin = GameObject.Find("Melvin");
        Door = GameObject.Find("PhantomDoor");
    }
	
	// Update is called once per frame
	void Update ()
    {
        LookTowards(whereToGo);
        
        if (beenToHouse == true && Vector3.Distance(transform.position, Melvin.transform.position) < 2)
        {
            animator.SetBool("ReachedMelvin", true);
        }
    }

    public void RunScene()
    {
        animator.SetBool("TigerIsGone", true);
        GameObject.Find("GirlCanvas").SetActive(false);
        whereToGo = House;
    }

    public void WalkToDoor()
    {
        beenToHouse = true;
        animator.SetBool("ReachedHouse", true);
        whereToGo = Door;
    }

    public void GiveKey()
    {
        if (beenToHouse == true)
            whereToGo = Melvin;
    }

    void LookTowards(GameObject destination)
    {
        var targetRotation = Quaternion.LookRotation(destination.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5 * Time.deltaTime);
    }
}