using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_IntroEndless : MonoBehaviour
{
    public void ClickEndlessMode()
    {
        SceneManager.LoadScene("IntroEndless");
    }
}