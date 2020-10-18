using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class WelcomerCustomer : MonoBehaviour {

	public string FilePath = "/storage/emulated/0/Undernet/sys/WelCust.usf";
	
	public Text SysName;
	public Text SecondName;
	public RawImage Logo;

	private string[] lines;

	void Start () {
		if (!File.Exists(FilePath))
		{
			File.Create(FilePath);
		}
		lines = File.ReadAllLines(FilePath);
		if (lines != null)
		{
			foreach (string lin in lines)
			{
				Compiator(lin);
			}
		}
		
	}
	
	public void Compiator(string line)
	{
		string[] words;
		words = line.Split(' ');
		switch (words[0])
		{
			case "Logo":
				WWW url = new WWW("file://" + words[1]);
				Logo.texture = url.texture;
				break;
			case "MainText":
				words[0] = String.Empty;
				SysName.text = String.Join(" ", words);
				break;
			case "SecondText":
				words[0] = String.Empty;
				SecondName.text = String.Join(" ", words);
				break;
		}
	}
}
