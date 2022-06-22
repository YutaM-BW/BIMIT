using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class TypingScript : MonoBehaviour {

	//　問題の日本語文
	private string[] qJ = { "問題", "テスト", "タイピング", "かめくめちゃん" };
	//　問題のローマ字文
	private string[] qR = { "monndai", "tesuto", "taipinngu", "kamekumechann" };
	//　日本語表示テキスト
	private Text UIJ;
	//　ローマ字表示テキスト
	private Text UIR;
	//　日本語問題
	private string nQJ;
	//　ローマ字問題
	private string nQR;
	//　問題番号
	private int numberOfQuestion;

	//　正解率の計算
	correctAR = 100f * correctN / (correctN + mistakeN);
	//　小数点以下の桁を合わせる
	UIcorrectAR.text = correctAR.ToString("0.00");

// 問題を出力するメソッド
	// Start is called before the first frame update
	void Start()
	{
		//　テキストUIを取得
		UIJ = transform.Find("InputPanel/QuestionJ").GetComponent<Text>();
		UIR = transform.Find("InputPanel/QuestionR").GetComponent<Text>();
		UII = transform.Find("InputPanel/Input").GetComponent<Text>();
		UIcorrectA = transform.Find("DataPanel/Correct Answer").GetComponent<Text>();
		UImistake = transform.Find("DataPanel/Mistake").GetComponent<Text>();
		UIcorrectAR = transform.Find("DataPanel/Correct Answer Rate").GetComponent<Text>();

		//　データ初期化処理
		correctN = 0;
		UIcorrectA.text = correctN.ToString();
		mistakeN = 0;
		UImistake.text = mistakeN.ToString();
		correctAR = 0;
		UIcorrectAR.text = correctAR.ToString();

		//　問題出力メソッドを呼ぶ
		OutputQ();
	}

	//　新しい問題を表示するメソッド
	void OutputQ()
	{

		//　問題数内でランダムに選ぶ
		numberOfQuestion = Random.Range(0, qJ.Length);

		//　選択した問題をテキストUIにセット
		nQJ = qJ[numberOfQuestion];
		nQR = qR[numberOfQuestion];
		UIJ.text = nQJ;
		UIR.text = nQR;
	}


// 問題をタイピングするメソッド
	//　問題の何文字目か
	private int indexOfString;

	// Update is called once per frame
	void Update()
	{
		//　今見ている文字とキーボードから打った文字が同じかどうか
		if (Input.GetKeyDown(nQR[indexOfString].ToString()))
		{
			//　正解時の処理を呼び出す
			Correct();
			//　問題を入力し終えたら次の問題を表示
			if (indexOfString >= nQR.Length)
			{
				OutputQ();
			}
		}
		else if (Input.anyKeyDown)
		{
			//　失敗時の処理を呼び出す
			Mistake();
		}
	}

	//　タイピング正解時の処理
	void Correct()
	{
		Debug.Log("正解");
	}

	//　タイピング失敗時の処理
	void Mistake()
	{
		Debug.Log("失敗");
	}

	//　正解率の計算処理
	void CorrectAnswerRate() {
		Debug.Log("正解率計算");
		//　正解率の計算
		correctAR = 100f * correctN / (correctN + mistakeN);
		//　小数点以下の桁を合わせる
		UIcorrectAR.text = correctAR.ToString("0.00");
	}
}
