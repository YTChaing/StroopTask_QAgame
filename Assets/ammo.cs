using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ammo : MonoBehaviour
{
	public GameController gc;
	public Animator anim;

	void OnTriggerEnter(Collider other){
		gc.GetComponent<next>().mode2Score = true;
		anim.SetBool("Idling",true);
	}

}
