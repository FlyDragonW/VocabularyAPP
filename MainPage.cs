using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainPage : MonoBehaviour
{
    public void VolListBtn()
    {
        SceneManager.LoadScene("VolList");
    }

    public void StartBtn()
    {
        SceneManager.LoadScene("Start");
    }
}
