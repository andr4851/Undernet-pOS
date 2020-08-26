using System;
using System.IO;
using UnityEngine;

public class SystemLog : MonoBehaviour {

	public string path;
	public string filePath;
	
	Terminal term;
	public static SystemLog SysLog;
	void Awake()
	{
		SysLog = this;
	}
	void Start()
	{
		string text;
		term = GetComponent<Terminal>();
		if (!Directory.Exists(path))
		{
			Directory.CreateDirectory(path);
		}
		if (!File.Exists(filePath))
		{
			text = Convert.ToString(DateTime.Now) + "\n" + "System install!" + "\n";
			File.WriteAllText(filePath, text);
		}
		else
		{
			text = "\n" + Convert.ToString(DateTime.Now);
			File.AppendAllText(filePath, text);
		}
	}
	public void AppendLog()
	{
		string input = term.com;
		string Output = term.OutputModule.text;
		string text = "\n" + "Input: " + input + "\n" + "Output: " + Output + "\n";
		File.AppendAllText(filePath, text);

	}

}
