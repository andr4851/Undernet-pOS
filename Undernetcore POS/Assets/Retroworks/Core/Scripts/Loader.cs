using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour {

	string FilePath = "/storage/emulated/0/Undernet/sys/Loader.usf";
	void Start () {
		Terminal term = GetComponent<Terminal>();
		if (!File.Exists(FilePath))
		{
			term.AutorunOrScript = true;
			File.Create(FilePath);
			term.PreNext();
			term.OutputModule.text = "It's you first start app!\nFor configured loader input 'setupLoader' + 'T' or 'X'";
			term.AutorunOrScript = false;
			term.next();
		}
		else 
		{
			if (File.ReadAllText(FilePath) == String.Empty)
			{
				term.AutorunOrScript = true;
				term.PreNext();
				term.OutputModule.text = "You haven't configured the loader yet!\nFor configured loader input 'setupLoader' + 'T' or 'X'";
				term.AutorunOrScript = false;
				term.next();
			}
			else 
			{
				string[] memo = File.ReadAllLines(FilePath);
				if (memo[3] == "TerminalOnly")
				{
					term.AutorunOrScript = true;
					term.PreNext();
					term.OutputModule.text = "You loader configurate to the terminal only mode";
					term.AutorunOrScript = false;
					term.next();
				}
				else if (memo[3] == "WinMode")
				{
					SceneManager.LoadSceneAsync(1);
				}
			}
		}
	}
}
