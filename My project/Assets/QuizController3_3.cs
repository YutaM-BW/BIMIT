using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//Image型を扱うために導入
using UnityEngine.SceneManagement;
using System.Security.Cryptography;

public class QuizController3_3 : MonoBehaviour
{
    [SerializeField] Button QuestionButton = null;//クイズの問題を表示させるTextオブジェクトとの連携のために導入
    [SerializeField] Button CorrectButton = null;//クイズの正解を表示させるButtonオブジェクトとの連携のために導入
    [SerializeField] Button WrongButton = null;//クイズの不正解を表示させるButtonオブジェクトとの連携のために導入

    private CSVReader_Lv3 QuizInfo;//CSVを読み込むCSVReader_Lv1クラスを扱うために宣言
    public AudioClip CorrectSound;
    public AudioClip WrongSound;
    int i = 113;
    //AudioSource AudioSource;
    //ゲーム起動時の動作
    private void Start()
    {
        i = RandomNumberGenerator.GetInt32(1, i + 1);
        QuizInfo = new CSVReader_Lv3();//CSVReader_Lv1クラスの実体としてQuizInfo生成
        QuizInfo.Init();//CSVデータの読み込みと変数への格納処理
        QuestionButton.GetComponentInChildren<Text>().text = QuizInfo.Question[i];//CSVファイル内でQur=0で表されるエネミーの名前ををTextオブジェクトに表示させる
        CorrectButton.GetComponentInChildren<Text>().text = QuizInfo.Correct[i];//CSVファイル内でenemyID=1で表されるエネミーの名前ををTextオブジェクトに表示させる
        WrongButton.GetComponentInChildren<Text>().text = QuizInfo.Wrong[i];//CSVファイル内でenemyID=2で表されるエネミーの名前ををTextオブジェクトに表示させる
    }
    //「スライム」ボタンが押された時の動作。Imageオブジェクトにスライムの画像を表示させるとともに、Textオブジェクトに名前とHPを表示させる
    public void ClickCorrectButton()
    {
        StartCoroutine("Correct");
    }
    private IEnumerator Correct()
    {
        GetComponent<AudioSource>().PlayOneShot(CorrectSound);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Stage3-4");
    }
    //「ゴブリン」ボタンが押された時の動作。Imageオブジェクトにゴブリンの画像を表示させるとともに、Textオブジェクトに名前とHPを表示させる
    public void ClickWrongButton()
    {
        StartCoroutine("Wrong");
    }
    private IEnumerator Wrong()
    {
        GetComponent<AudioSource>().PlayOneShot(WrongSound);
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("Stage3-4");
    }
}