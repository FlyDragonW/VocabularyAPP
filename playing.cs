using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    static public int score, difficulty;
    public GameObject[] BtnList;
    public Text question, title;
    public Text[] BtnTextList;
    public int answer;
    public int lastQuestionIndex;

    private void Start()
    {
        
        UpdateBtns();
    }
    void UpdateBtns()
    {
        for(int i = 0; i < 4; i++)
        {
            BtnList[i].GetComponent<Image>().color = new Color(1, 1, 1);
        }
        int mode = Random.Range(0, 5); // 1/5 chance for chinese mode
        int questionIndex = Random.Range(0, voLIst.voAmount);
        while (questionIndex == lastQuestionIndex) questionIndex = Random.Range(0, voLIst.voAmount);
        if (mode == 0)
        {
            question.text = voLIst.list[questionIndex].chinese;
            Buttons(false, questionIndex);
        }
        else
        {
            question.text = voLIst.list[questionIndex].english;
            Buttons(true, questionIndex);
        }
        lastQuestionIndex = questionIndex;
    }
    void Buttons(bool isQuestionEN, int index)
    {
        BtnList[0].SetActive(false); BtnList[1].SetActive(false);
        BtnList[2].SetActive(false); BtnList[3].SetActive(false);
        if (Random.Range(0, difficulty) == 0) // 2 option
        {
            BtnList[0].SetActive(true); BtnList[1].SetActive(true);
            answer = Random.Range(0, 2);
            BtnTextList[answer].text = voLIst.list[index].PartOfSpeech + "\n" + ((isQuestionEN) ? voLIst.list[index].chinese : voLIst.list[index].english);
            for (int i = 0; i < 2; i++)
            {
                if (i == answer) continue;
                else
                {
                    int temp = Random.Range(0, voLIst.voAmount);
                    while (temp == index) temp = Random.Range(0, voLIst.voAmount);
                    BtnTextList[i].text = voLIst.list[temp].PartOfSpeech + "\n" + ((isQuestionEN) ? voLIst.list[temp].chinese : voLIst.list[temp].english);
                }
            }
        }
        else // 4 option
        {
            BtnList[0].SetActive(true); BtnList[1].SetActive(true);
            BtnList[2].SetActive(true); BtnList[3].SetActive(true);
                
            answer = Random.Range(0, 4);
            BtnTextList[answer].text = voLIst.list[index].PartOfSpeech + "\n" + ((isQuestionEN) ? voLIst.list[index].chinese : voLIst.list[index].english);
            for (int i = 0; i < 4; i++)
            {
                if (i == answer) continue;
                else
                {
                    int temp = Random.Range(0, voLIst.voAmount);
                    while (temp == index) temp = Random.Range(0, voLIst.voAmount);
                    BtnTextList[i].text = voLIst.list[temp].PartOfSpeech + "\n" + ((isQuestionEN) ? voLIst.list[temp].chinese : voLIst.list[temp].english);
                }
            }
        }
    }

    public void Btn(int choice)
    {
        if(choice == answer)
        {
            score++;
            UpdateBtns();
            UpdateTitle();
            UpdateDifficulty();
        }
        else
        {
            BtnList[choice].GetComponent<Image>().color = new Color(1, 0.524f, 0.524f);
            score = 0;
            UpdateTitle();
        }
        
    }

    public void UpdateDifficulty()
    {
        difficulty = (int)score / 3;
        if(difficulty > 10)
        {
            if (Random.Range(0, 2) == 0) difficulty--;
        }
    }

    public void UpdateTitle()
    {
        timer.Recorded = false;
        title.text = "連續答對" + score.ToString() + "題";
    }

    public void MainPageBtn()
    {
        SceneManager.LoadScene("MainPage");
    }
    public void voListBtn()
    {
        SceneManager.LoadScene("voList");
    }
}
