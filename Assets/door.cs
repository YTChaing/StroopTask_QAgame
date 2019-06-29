using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour
{
	public GameController gc;
    	public Animator anim;
    	public Animator anim2;
	bool isOpened = false;
	public bool open = false;

	void Update()
    	{
		if(open){
			if(!isOpened){
				anim.Play("door", 0, 0);
				anim2.Play("door", 0, 0);
				isOpened = true;
			}			
		}
	}

	void OnTriggerEnter(Collider other){
		gc.GetComponent<GameController2>().isTrigger = true;
	}
}
