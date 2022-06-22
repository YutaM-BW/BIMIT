using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static System.Net.Mime.MediaTypeNames;

public class TypingScript : MonoBehaviour {

	//�@���̓��{�ꕶ
	private string[] qJ = { "���", "�e�X�g", "�^�C�s���O", "���߂��߂����" };
	//�@���̃��[�}����
	private string[] qR = { "monndai", "tesuto", "taipinngu", "kamekumechann" };
	//�@���{��\���e�L�X�g
	private Text UIJ;
	//�@���[�}���\���e�L�X�g
	private Text UIR;
	//�@���{����
	private string nQJ;
	//�@���[�}�����
	private string nQR;
	//�@���ԍ�
	private int numberOfQuestion;

	//�@���𗦂̌v�Z
	correctAR = 100f * correctN / (correctN + mistakeN);
	//�@�����_�ȉ��̌������킹��
	UIcorrectAR.text = correctAR.ToString("0.00");

// �����o�͂��郁�\�b�h
	// Start is called before the first frame update
	void Start()
	{
		//�@�e�L�X�gUI���擾
		UIJ = transform.Find("InputPanel/QuestionJ").GetComponent<Text>();
		UIR = transform.Find("InputPanel/QuestionR").GetComponent<Text>();
		UII = transform.Find("InputPanel/Input").GetComponent<Text>();
		UIcorrectA = transform.Find("DataPanel/Correct Answer").GetComponent<Text>();
		UImistake = transform.Find("DataPanel/Mistake").GetComponent<Text>();
		UIcorrectAR = transform.Find("DataPanel/Correct Answer Rate").GetComponent<Text>();

		//�@�f�[�^����������
		correctN = 0;
		UIcorrectA.text = correctN.ToString();
		mistakeN = 0;
		UImistake.text = mistakeN.ToString();
		correctAR = 0;
		UIcorrectAR.text = correctAR.ToString();

		//�@���o�̓��\�b�h���Ă�
		OutputQ();
	}

	//�@�V��������\�����郁�\�b�h
	void OutputQ()
	{

		//�@��萔���Ń����_���ɑI��
		numberOfQuestion = Random.Range(0, qJ.Length);

		//�@�I�����������e�L�X�gUI�ɃZ�b�g
		nQJ = qJ[numberOfQuestion];
		nQR = qR[numberOfQuestion];
		UIJ.text = nQJ;
		UIR.text = nQR;
	}


// �����^�C�s���O���郁�\�b�h
	//�@���̉������ڂ�
	private int indexOfString;

	// Update is called once per frame
	void Update()
	{
		//�@�����Ă��镶���ƃL�[�{�[�h����ł����������������ǂ���
		if (Input.GetKeyDown(nQR[indexOfString].ToString()))
		{
			//�@�������̏������Ăяo��
			Correct();
			//�@������͂��I�����玟�̖���\��
			if (indexOfString >= nQR.Length)
			{
				OutputQ();
			}
		}
		else if (Input.anyKeyDown)
		{
			//�@���s���̏������Ăяo��
			Mistake();
		}
	}

	//�@�^�C�s���O�������̏���
	void Correct()
	{
		Debug.Log("����");
	}

	//�@�^�C�s���O���s���̏���
	void Mistake()
	{
		Debug.Log("���s");
	}

	//�@���𗦂̌v�Z����
	void CorrectAnswerRate() {
		Debug.Log("���𗦌v�Z");
		//�@���𗦂̌v�Z
		correctAR = 100f * correctN / (correctN + mistakeN);
		//�@�����_�ȉ��̌������킹��
		UIcorrectAR.text = correctAR.ToString("0.00");
	}
}
