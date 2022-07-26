using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_IntroAdv : MonoBehaviour
{
    public void ClickGameStart()
    {
        SceneManager.LoadScene("IntroAdventure");
    }
}