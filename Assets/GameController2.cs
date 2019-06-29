

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController2 : MonoBehaviour
{
    public Button StartBtn;
    public Button YesBtn;
    public Button NoBtn;
    public GameObject introduction;
    public GameObject gameFrame;
    public GameObject score;
    public Text question;
    public Text timer;
    public Text avgtime;
    public Animator anim;
    public Animator Ldoor;
    public Animator Rdoor;

    public string[] questions2;
    public bool[] answer2;
    public int[] Qrandom;
    public bool isTrigger,show;
    int num, rndNum, temp, totalans;
    int correctCount, wrongCount, noansCount;
    bool isStart, isEnd, playing;
    bool check, choose, rightAns;
    float time, totaltime;


    void Start()
    {
	isStart = false;
	isEnd = false;
	playing = false;
	choose = false;
	isTrigger = false;
	show = false;

    }

    void Update()
    {
	if(isTrigger){
		anim.SetBool("Idling",true);
		if(!playing){isStart = true;}
		isTrigger = false;
		show = true;
	}
        if (isStart){
            time = 0; totaltime = 0; totalans = 0; num = 0;
    	    correctCount = 0; wrongCount = 0; noansCount = 0;
            Time.timeScale = 1;
            Debug.Log("Start");

            this.GetComponent<CSV>().Clean();//清空

            for (int i = 0; i < 100; i++){
                for (int j = 0; j < 14; j++){                                                     		//num!!
                    rndNum = Random.Range(0, 50);
                    if (rndNum > 0){
                        temp = Qrandom[j];
                        Qrandom[j] = Qrandom[j + 1];
                        Qrandom[j + 1] = temp;
                    }
                }
            }
            question.text = "1. " + questions2[Qrandom[0]];
            isStart = false;
            playing = true;
        }
        if (isEnd){
		    show = false;
		    anim.SetBool("Idling",false);
		    Ldoor.SetBool("open",true);
		    Rdoor.SetBool("open",true);
		    this.GetComponent<AudioController>().door.Play();

            this.GetComponent<CSV>().Write("avgtime");
            this.GetComponent<CSV>().Write((totaltime / totalans).ToString());// 平均反應時間
            this.GetComponent<CSV>().ChangeLine();//change line

            this.GetComponent<CSV>().Write("CorrectCount");
            this.GetComponent<CSV>().Write(correctCount.ToString());
            this.GetComponent<CSV>().ChangeLine();//change line

            this.GetComponent<CSV>().Write("WrongCount");
            this.GetComponent<CSV>().Write(wrongCount.ToString());
            this.GetComponent<CSV>().ChangeLine();//change line

            this.GetComponent<CSV>().Write("NoAnsCount");
            this.GetComponent<CSV>().Write(noansCount.ToString());
            this.GetComponent<CSV>().ChangeLine();//change line

            this.GetComponent<CSV>().Write("acc");
            this.GetComponent<CSV>().Write(((float)correctCount / 15 * 100).ToString());
            this.GetComponent<CSV>().ChangeLine();//change line

            this.GetComponent<CSV>().WriteInExcel("mode2", this.GetComponent<next>().inputID.text);//mode2存檔
            playing = false;
            avgtime.text = "你的平均反應時間是：" + (totaltime / totalans).ToString() + "\n答對題數：" + correctCount.ToString() + "\n答錯題數：" + wrongCount.ToString() + "\n超時無作答題數：" + noansCount.ToString() + "\n作答正確率：" + ((float)correctCount / 15 * 100).ToString() + "%";
            isEnd = false;
        }
        if (choose){
            Debug.Log("rightAns? : " + rightAns + "  answertime : " + time.ToString());
            if (rightAns){
                //this.GetComponent<CSV>().Write(question.text);// question
		correctCount++;
                this.GetComponent<CSV>().Write("correct");// correct
                this.GetComponent<CSV>().Write(time.ToString());//answer time
                this.GetComponent<CSV>().ChangeLine();//change line
		        this.GetComponent<AudioController>().correct.Play();
            }
            else{
		wrongCount++;
                //this.GetComponent<CSV>().Write(question.text);// question
                this.GetComponent<CSV>().Write("incorrect");// incorrect
                this.GetComponent<CSV>().Write(time.ToString());//answer time
                this.GetComponent<CSV>().ChangeLine();//change line
		        this.GetComponent<AudioController>().wrong.Play();
            }
            totaltime += time;
            totalans++;
            //num++;
            if (num == 14){                                                                               //num!!
                isEnd = true;
            }
            else{
                num++;
                time = 0;
                question.text = (num + 1) + ". " + questions2[Qrandom[num]];
            }
            choose = false;
        }
        if (playing && show){
            time += Time.deltaTime;
            timer.text = "Timer:" + time.ToString();
            if (time > 3){
		noansCount++;
                Debug.Log("no ans");
                //num++;
                if (num == 14){                                                                            //num!!
                    isEnd = true;                 
                }
                else{
                    num++;
                    time = 0;
                    question.text = (num + 1) + ". " + questions2[Qrandom[num]];
                }
            }
        }
	if(show){
            gameFrame.gameObject.SetActive(true);
        }
	else{
            gameFrame.gameObject.SetActive(false);
        }
    }
    public void StartBtnOnclick()
    {
        introduction.gameObject.SetActive(false);
        gameFrame.gameObject.SetActive(true);
	    anim.SetBool("Idling",false);
    }

    public void YesBtnOnclick()
    {
        rightAns = !answer2[Qrandom[num]];
        choose = true;
    }

    public void NoBtnOnclick()
    {
        rightAns = answer2[Qrandom[num]];
        choose = true;
    }
}


