using System;
using System.IO;
using UnityEngine;

public class Autorun : MonoBehaviour {

	public string path;
	public string Filepath;
	public string[] lines;

	void Start () {
		if (!Directory.Exists(path)) 
		{
			Debug.Log("No directory found! Creating derectory");
			Directory.CreateDirectory(path);
			
		}
		if (!File.Exists(Filepath))
		{
			Debug.Log("No file found! Creating file");
			File.Create(Filepath);	
		}
		if (!String.IsNullOrEmpty(File.ReadAllText(Filepath)))
		{
			int leah = 0;
			lines = File.ReadAllLines(Filepath);
			Terminal term = GetComponent<Terminal>();
			foreach (string text in lines)
			{

				if (text[0] != '%')
				{
					term.AutorunOrScript = true;
					term.com = text;
					term.Enter();
				}
				if (leah > lines.Length) 
				{
					term.com = String.Empty;
					leah = 0;
					//term.next();
					term.AutorunOrScript = false;
					term.Start();
					term.ActInp.transform.SetAsLastSibling();

				}
				else
				{
					leah++;
					Debug.Log(leah);
					term.AutorunOrScript = false;

				}
				

			}
			Debug.Log(String.Join(" ", lines));
		
		}
		
	}
	
}
