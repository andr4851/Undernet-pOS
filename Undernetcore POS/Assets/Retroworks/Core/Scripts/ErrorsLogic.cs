using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ErrorsLogic : MonoBehaviour {

	public Transform WindowManager;
	public GameObject ErrorWindow;

	public Text Title;
	public Text Memo;

	public static ErrorsLogic ERRLog;

	void Awake()
	{
		ERRLog = this;
	}


	public void ErrorStart(string title, string memo)
	{
		Text[] texts;
		GameObject ActErr = Instantiate(ErrorWindow, WindowManager);
		ActErr.transform.localScale = new Vector3(1, 1, 1);
		texts = ActErr.GetComponentsInChildren<Text>();
		Title = texts[0];
		Title.text = title;
		Memo = texts[1];
		Memo.text = memo;
		Title = null;
		Memo = null;
	}
}
