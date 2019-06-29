using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class next : MonoBehaviour
{
    public Button NextBtn;
    public Button modeNextBtn;
    public Button EndBtn;
    public GameObject Scene;
    public GameObject Scene2;
    public GameObject getID;
    public GameObject introduction;
    public GameObject score;
    public GameObject introduction2;
    public GameObject score2;
    public GameObject ammo;
    public InputField inputID;
    public Camera cam;
    public Camera cam2;
    public GameObject A03;
    public GameObject Ldoor;
    public GameObject Rdoor;
    public Animator anim;

    bool moveCam;
    bool moveCamUp;
    bool moveCamFront;
    public bool mode2Cam;
    public bool mode2Score;

    void Start()
    {
        moveCam = true;
        moveCamUp = true;
        moveCamFront = true;
        mode2Cam = false;
	mode2Score = false;
    }

    void Update()
    {
        if(!mode2Cam){
            if (moveCam)
            {
                if (cam.transform.position.y > 15)
                {
                    moveCamUp = false;
                }
                else if (cam.transform.position.y < 6.5)
                {
                    moveCamUp = true;
                }

                if (moveCamUp)
                {
                    cam.transform.Translate(new Vector3(0, 0.02f, 0));
                }
                else
                {
                    cam.transform.Translate(new Vector3(0, -0.02f, 0));
                }

                if (cam.transform.position.z > -15)
                {
                    moveCamFront = false;
                }
                else if (cam.transform.position.z < -25)
                {
                    moveCamFront = true;
                }

                if (moveCamFront)
                {
                    cam.transform.Translate(new Vector3(0, 0, 0.02f));
                }
                else
                {
                    cam.transform.Translate(new Vector3(0, 0, -0.02f));
                }

            }
            else
            {
                if (cam.transform.position.y > 6.5)
                {
                    cam.transform.Translate(new Vector3(0, -2f, 0));
                }
		else if(cam.transform.position.y > 4.5){
                    cam.transform.Translate(new Vector3(0, -0.5f, 0));
		}
		else if(cam.transform.position.y < 4){
                    cam.transform.Translate(new Vector3(0, 0.2f, 0));
		}
                if (cam.transform.position.z < -15)
                {
                    cam.transform.Translate(new Vector3(0, 0, 2f));
                }
		else if(cam.transform.position.z < -13){
                    cam.transform.Translate(new Vector3(0, 0, 0.5f));
		}
		else if(cam.transform.position.z > -12.5){
                    cam.transform.Translate(new Vector3(0, 0, -0.2f));
		}
            }

             if (A03.transform.position.x > -22){
			A03.transform.Translate(new Vector3(0, 0, -1f));
			cam2.transform.Translate(new Vector3(0, 0, -1f));
		}
		if(Ldoor.transform.position.z > 7){
			Ldoor.transform.Translate(new Vector3(-1f, 0, 0));
		}
		if(Rdoor.transform.position.z < 1){
			Rdoor.transform.Translate(new Vector3(-1f, 0, 0));
		}

        }
        else{
                if (A03.transform.position.x - cam2.transform.position.x > 4){
			cam2.transform.Translate(new Vector3(0, 0, 1f));
		}
                if (A03.transform.position.x >= -2.9){
			mode2Score = true;
			anim.SetBool("Idling",true);
		}
		if(mode2Score){
       		 	score2.gameObject.SetActive(true);			
		}
        }
    }

    public void NextBtnOnclick()
    {
        Debug.Log("ID:" + inputID.text);
        this.GetComponent<CSV>().CreateIdDir(inputID.text);
        moveCam = false;
        getID.gameObject.SetActive(false);
        introduction.gameObject.SetActive(true);
    }
    public void modeNextBtnOnclick()
    {
        score.gameObject.SetActive(false);
        introduction2.gameObject.SetActive(true);
        mode2Cam = true;
        Scene.SetActive(false);
        Scene2.SetActive(true);
	this.GetComponent<AudioController>().mode1bg.Stop();
	this.GetComponent<AudioController>().mode2bg.Play();
    }
    public void EndBtnOnclick()
    {
        score2.gameObject.SetActive(false);
        getID.gameObject.SetActive(true);
        moveCam = true;
        mode2Cam = false;
        mode2Score = false;
        Scene2.SetActive(false);        
        Scene.SetActive(true);
        inputID.text = "";
	this.GetComponent<AudioController>().mode1bg.Play();
	this.GetComponent<AudioController>().mode2bg.Stop();
    }
}
