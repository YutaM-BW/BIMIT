using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;//情報を読み込むStringReaderを使用するために導入
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

//クイズの情報をCSVから読み込んで、変数に格納する
public class CSVReader_Lv5//MonoBehaviourは継承しない
{
    static TextAsset csvFile;//CSVファイルを変数として扱うために宣言
    static List<string[]> QuizData = new List<string[]>();//CSVファイルの中身を入れる配列を定義。全てのデータが文字列形式で格納される
    //変数名[i]がエネミーIDがiの情報をそれぞれ示す
    public string[] Question = new string[5000];//クイズの問題
    public string[] Correct = new string[5000];//クイズの正解
    public string[] Wrong = new string[5000];//クイズの不正解
    //指定したアドレスに保管されているCSVファイルから情報を読み取り、QuizDataに情報を文字列として格納するメソッド。
    //QuizData[i][j]はCSVファイルのi行、j列目のデータを表す。但し先頭行（タイトル部分）は0行目と考えるものとする。
    static void CsvReader_Lv5()
    {
        csvFile = Resources.Load("QuizLevel5") as TextAsset;//指定したファイルをTextAssetとして読み込み(ファイル名の.csvは不要なことに注意)　最初の行（タイトル部分）も読み込まれるのでそこは使用しない
        StringReader reader = new StringReader(csvFile.text);//
        while (reader.Peek() != -1)//最後まで読み込むと-1になる関数
        {
            string line = reader.ReadLine();//一行ずつ読み込み
            QuizData.Add(line.Split(','));//,区切りでリストに追加していく
        }
    }
    //QuizDataに一度CSVファイルのデータを読み込んだら他のプログラムから扱いやすいよう定義したQuestion等の変数にデータを格納する
    public void Init()
    {
        CsvReader_Lv5();//QuizDataへ情報を一時格納
        //各変数へデータを格納
        for (int i = 1; i < QuizData.Count; i++)//Questionが記述された最後まで読み込み。一行目はタイトルなのでi=0はデータとして扱わない
        {
            Question[i] = QuizData[i][0];
            Correct[i] = QuizData[i][1];
            Wrong[i] = QuizData[i][2];
        }
    }
}