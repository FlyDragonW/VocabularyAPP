using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[System.Serializable]

public class voLIst : MonoBehaviour
{
    public string en, POS, ch;
    public int option;
    public GameObject dropdown;
    public Text text;

    static public vocabulary[] list = new vocabulary[10000];
    static public int CurrentIndex;
    static public int voAmount;

    public class vocabulary
    {
        public int index;
        public string english, PartOfSpeech ,chinese;
        public vocabulary(int i,string en, string pos, string ch)
        {
            index = i;
            english = en;
            PartOfSpeech = pos;
            chinese = ch;
        }
    }

    private void Start()
    {
        CurrentIndex = 0;
        voAmount = 0;
        DisplayList();
    }

    public void ReadEnBtn(string s)
    {
        en = s;
    }

    public void ReadChBtn(string s)
    {
        ch = s;
    }

    public void SubmitBtn()
    {
        option = dropdown.GetComponent<Dropdown>().value;
        switch (option)
        {
            case 0:
                POS = "n.";
                break;
            case 1:
                POS = "v.";
                break;
            case 2:
                POS = "adj.";
                break;
            case 3:
                POS = "adv.";
                break;
        }
        if (en == string.Empty && ch == string.Empty) return;
        vocabulary vo = new vocabulary(CurrentIndex, en, POS, ch);
        list[CurrentIndex] = vo;
        CurrentIndex++;
        voAmount++;
        DisplayList();
    }

    void DisplayList()
    {
        text.text = "";
        foreach (vocabulary vo in list)
        {
            if (vo == null) return;
            text.text += '\n' + vo.index.ToString() + ". " + vo.english + ' ' + vo.PartOfSpeech + ' ' + vo.chinese;
        }
    }

    public void MainPageBtn()
    {
        SceneManager.LoadScene("MainPage");
    }

    public void StartBtn()
    {
        SceneManager.LoadScene("Start");
    }

    public void SaveBtn()
    {
        string jsonString = JsonUtility.ToJson(list);
        PlayerPrefs.SetString("list", jsonString);
        PlayerPrefs.SetInt("currentIndex", CurrentIndex);
        PlayerPrefs.SetInt("voAmount", voAmount);
    }

    public void LoadBtn()
    {
        string jsonString = PlayerPrefs.GetString("list");
        list = JsonUtility.FromJson<vocabulary[]>(jsonString);
        CurrentIndex = PlayerPrefs.GetInt("currentIndex");
        voAmount = PlayerPrefs.GetInt("voAmount");
        DisplayList();
    }
    private void Printvo(vocabulary vo)
    {
        print(vo.index);
        print(vo.english);
        print(vo.PartOfSpeech);
        print(vo.chinese);
    }
}
