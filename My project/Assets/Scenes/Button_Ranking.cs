using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button_Ranking : MonoBehaviour
{
    public void ClickRanking()
    {
        SceneManager.LoadScene("Ranking");
    }
}