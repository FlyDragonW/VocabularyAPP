using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class timer : MonoBehaviour
{
    public float Timer;
    public Text MINText;
    public Text SECText;
    
    public Text recordText;
    static public bool Recorded;
    // Start is called before the first frame update
    void Start()
    {
        Recorded = false;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        int temp = (int)Timer;
        UpdateText(temp);
    }

    void UpdateText(int t)
    {
        int min = (int)(t / 60);
        int sec = t % 60;
        if (min < 10) MINText.text = '0' + min.ToString();
        else MINText.text = min.ToString();

        if (sec < 10) SECText.text = '0' + sec.ToString();
        else SECText.text = sec.ToString();
        if(Player.score != 0 && Player.score % 10 == 0 && !Recorded)
        {
            Recorded = true;
            RecordTime(min,sec);
        }
    }

    void RecordTime(int min,int sec)
    {
        string MIN,SEC;
        if (min < 10) MIN = '0' + min.ToString();
        else MIN = min.ToString();
        if (sec < 10) SEC = '0' + sec.ToString();
        else SEC = sec.ToString();
        recordText.text = "連續" + Player.score.ToString() + "題 " + MIN + ':' + SEC;
    }
}
