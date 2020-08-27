using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class DesktopObject : MonoBehaviour {

	public Transform WindowManager;
	public Transform ButtonManager;
	
	public Text clock;
	public Slider sound;
	public Image BattoryImg;
	public Text BattoryText;
	public GameObject Terminal, About;
	public GameObject TermButton;
	private Button[] MiniButa;
	void Update() 
	{
		
		clock.text = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "\n" + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
		AudioListener.volume = sound.value;
		BattoryImg.fillAmount = SystemInfo.batteryLevel;
		BattoryText.text = Convert.ToString(SystemInfo.batteryLevel * 100) + "%";
	}
	public void Quit() 
	{
		Application.Quit();
	}
	public void LoadTerminalOly() 
	{
		UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(0);
	}
	public void OpenTerminal() 
	{
		GameObject ActTerm = Instantiate(Terminal, WindowManager);
		ActTerm.transform.localScale = new Vector3(1, 1, 1);
		GameObject ActButs = Instantiate(TermButton, ButtonManager);
		MiniButa = ActButs.GetComponentsInChildren<Button>();
		MiniButa[0].onClick.AddListener(delegate {
			ActTerm.SetActive(true);
			});
		MiniButa[1].onClick.AddListener(delegate { 
			ActTerm.SetActive(false);
		});
		ActTerm.GetComponent<Window>().MiniBut = MiniButa;

	}
	public void OpenAbout() 
	{
		GameObject ActAbout = Instantiate(About, WindowManager);
		ActAbout.transform.localScale = new Vector3(1, 1, 1);
		GameObject ActButs = Instantiate(TermButton, ButtonManager);
		MiniButa = ActButs.GetComponentsInChildren<Button>();
		MiniButa[0].onClick.AddListener(delegate {
			ActAbout.SetActive(true);
		});
		MiniButa[1].onClick.AddListener(delegate {
			ActAbout.SetActive(false);
		});
		ActAbout.GetComponent<Window>().MiniBut = MiniButa;

	}
}
