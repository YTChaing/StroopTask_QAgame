using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
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


    public string[] questions1;
    public string[] questions2;
    bool[] answer1;
    bool[] answer2;
    public int[] Qrandom;
    public int[] Qrandom2;

    int num, rndNum, temp, totalans;
    int correctCount, wrongCount, noansCount;
    bool isStart = false, isEnd = false, playing = false;
    bool check, choose = false, rightAns;
    float time, totaltime;
    string tempstr;

    void Start()
    {
        questions1 = new string[] { "太陽從東方升起", "太陽不是從東方升起", "海洋大學在海邊", "海洋大學在高雄", "工學院有資工系",
                                                "工學院有電機系", "2019年台北市長是柯文哲", "2019年台北市長不是柯文哲","海洋大學有醫學院","海洋大學有海洋系",
                                                "台灣同婚已經合法", "有些植物會行光合作用", "地球繞著太陽轉","太陽會發光","這堂課是腦機介面原理與應用",
                                                "這堂課名字是用大腦作Unity遊戲", "在台灣找警察報案打110", "歐拉數e約等於2.71828","南非在南半球","利比亞在非洲",
                                                "祕魯在南美洲", "北京市是中國首都", "67是質數","101不是質數","一般籃球上場人數為一隊5人",
                                                "一般棒球人數最少為一隊9人", "馬英九曾當任總統" ,"LED較傳統燈泡省電","紐西蘭的七月是夏天","Gogoro是電動車品牌",
                                                "奧運有短跑項目","2020奧運在東京","近視要戴近視眼鏡","天上的雲大部分由水分子組成","北極星是恆星",
                                                "地球是平的","母企鵝會下蛋","鯨魚是哺乳類","現在是21世紀","蜘蛛有8隻腳",
                                                "氧元子的原子序是12","硫酸是一種強酸","人類唾液一般為中性","白色的對比色是黑色","光的三原色沒有黃色",
                                                "W.H.O.是世界衛生組織的簡稱","台灣生育率超低","天線寶寶有3種顏色","華碩是美國品牌","現今人類男性可以懷孕",
                                                "英國的動物園有獨角獸"
        };




        questions2 = new string[] { "太陽從西方升起", "太陽不是從西方升起", "海洋大學在基隆", "海洋大學不在台北", "工學院沒有資工系",
                                                "資工系在電資學院", "2019年新北市長是柯文哲", "2019年新北市長不是柯文哲","海洋大學沒有醫學院","海洋大學沒有航管系",
                                                "台灣同婚還未合法", "有些植物不會行光合作用", "月球繞著地球轉","月球會發光","這堂課的授課老師是莊鈞翔老師",
                                                "這堂課的授課老師是程華淮老師", "在台灣找消防隊報案打119", "2的6次方為128","智利在南半球","伊朗在亞洲",
                                                "日本在亞洲", "東京是日本首都", "51是質數","1不是質數","一般足球上場人數為一隊10人",
                                                "般排球上場人數為一隊7人", "丁守中曾當任台北市長","傳統燈泡較LED省電","冰島的十二月是夏天","Gogoro不是電動車品牌",
                                                "奧運有游泳項目","2020奧運在北京","老花是近視的別稱","天上的雲大部分由二氧化碳組成","冥王星是行星",
                                                "地球是立方體","企鵝會孵蛋","鯊魚是哺乳類","現在是22世紀","蜘蛛是昆蟲的一種",
                                                "碳元子的原子序是16","氫氧化鈉是一種強鹼","人類唾液一般為強鹼性","光的三原色沒有白色","藍光,綠光,紅光合在一起是黑色",
                                                "U.N.是聯合國的簡稱","日本生育率超低","彩虹有五種顏色","華為不是中國品牌","現今人類男性可以自體繁殖",
                                                "美國的動物園沒有恐龍"

        };

        answer1 = new bool[] { true, false, true, false, false,
                                  false, true, false, false, true,
                                  true, true, true, true, true,
                                  false, true, true, true, true,
                                  true, true, true, false, true,
                                  true, true , true, false,true,
                                  true,true,true,true,true,
                                  false,true,true,true,true,
                                  false,true,true,true,true,
                                  true,true,false,false,false,
                                  false
        };

        answer2 = new bool[] { false, true, true, true, true,
                                  true,false, true, true, false,
                                  false, true, true, false, true,
                                  false, true, false, true, true,
                                  true, true,false, true,false,
                                  false,false,false,false,false,
                                  true,false,false,false,false,
                                  false,true,false,false,false,
                                  false,true,false,true,false,
                                  true,true,false,false,false,
                                  true
        };

         Qrandom = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50};

        Qrandom2 = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26 ,27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50};

}

void Update()
    {
        if (isStart){
            time = 0; totaltime = 0; totalans = 0; num = 0;
    	    correctCount = 0; wrongCount = 0; noansCount = 0;
            Time.timeScale = 1;
            Debug.Log("Start");

            this.GetComponent<CSV>().Clean();//清空

            for (int i = 0; i < 100; i++){
                for (int j = 0; j < 50; j++){                                                          //num!!!
                    rndNum = Random.Range(0, 50);
                    if (rndNum > 0){
                        temp = Qrandom[j];
                        Qrandom[j] = Qrandom[j + 1];
                        Qrandom[j + 1] = temp;
                    }
                }
            }
            this.GetComponent<GameController2>().Qrandom = Qrandom;
            this.GetComponent<GameController2>().questions2 = questions2;
            this.GetComponent<GameController2>().answer2 = answer2;

            question.text = "1. " + questions1[Qrandom[0]];
            isStart = false;
            playing = true;
        }
        if (isEnd){
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

            this.GetComponent<CSV>().WriteInExcel("mode1", this.GetComponent<next>().inputID.text);//mode1存檔
            playing = false;
            gameFrame.gameObject.SetActive(false);
            score.gameObject.SetActive(true);
            avgtime.text = "你的平均反應時間是：" + (totaltime / totalans).ToString() + "\n答對題數：" + correctCount.ToString() + "\n答錯題數：" + wrongCount.ToString() + "\n超時無作答題數：" + noansCount.ToString() + "\n作答正確率：" + ((float)correctCount / 15 * 100).ToString() + "%";
            isEnd = false;
        }
        if (choose){
            
            Debug.Log("rightAns? : " + rightAns + "  answertime : " + time.ToString());
            if (rightAns) {
                //this.GetComponent<CSV>().Write(question.text);// question 中文輸出為亂碼 注意
		correctCount++;
                this.GetComponent<CSV>().Write("correct");// correct
                this.GetComponent<CSV>().Write(time.ToString());//answer time
                this.GetComponent<CSV>().ChangeLine();//change line
                anim.Play("jump", 0, 0);
		this.GetComponent<AudioController>().correct.Play();
            }
            else {
                //this.GetComponent<CSV>().Write(question.text);// question
		wrongCount++;
                this.GetComponent<CSV>().Write("incorrect");// incorrect
                this.GetComponent<CSV>().Write(time.ToString());//answer time
                this.GetComponent<CSV>().ChangeLine();//change line
                anim.Play("stun", 0, 0);
		this.GetComponent<AudioController>().wrong.Play();
            }
            totaltime += time;
            totalans++;
            num++;
            if (num == 15){                                                                                    //num!!!
                isEnd = true;
            }
            else{
                time = 0;
                question.text = (num+1) + ". " + questions1[Qrandom[num]];
            }
            choose = false;
        }
        if (playing){
            time += Time.deltaTime;
            timer.text = "Timer:" + time.ToString();
            if (time > 5){
		noansCount++;
                Debug.Log("no ans");
                anim.Play("stun", 0, 0);
                num++;
                if (num == 15){                                                                           //num!!!
                    isEnd = true;
                }
                else{
                    time = 0;
                question.text = (num+1) + ". " + questions1[Qrandom[num]];
                }
            }
        }
    }
    public void StartBtnOnclick()
    {
        introduction.gameObject.SetActive(false);
        gameFrame.gameObject.SetActive(true);
        isStart = true;
    }

    public void YesBtnOnclick()
    {
        rightAns = answer1[Qrandom[num]];
        choose = true;
    }

    public void NoBtnOnclick()
    {
        rightAns = !answer1[Qrandom[num]];
        choose = true;
    }
}