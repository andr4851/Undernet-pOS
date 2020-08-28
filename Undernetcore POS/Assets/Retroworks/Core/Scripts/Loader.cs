using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour {

	string FilePath = "/storage/emulated/0/Undernet/sys/Loader.usf";
	void Start () {
		Terminal term = GetComponent<Terminal>();
		term.AutorunOrScript = true;
		if (!File.Exists(FilePath))
		{
			term.AutorunOrScript = true;
			File.WriteAllText(FilePath, "[TypeOfLoad]\nNoShowTextOrGraficalInformation\n[Mode]\nNoSetup");
			term.PreNext();
			term.OutputModule.text = "It's you first start app!\nFor configured loader input 'setupLoader' + 'T' or 'X'";
			term.AutorunOrScript = false;
			term.Start();
		}
		else 
		{
			if (File.ReadAllText(FilePath) == String.Empty)
			{
				term.AutorunOrScript = true;
				term.PreNext();
				term.OutputModule.text = "You haven't configured the loader yet!\nFor configured loader input 'setupLoader' + 'T' or 'X'";
				term.AutorunOrScript = false;
				term.Start();
			}
			else 
			{
				string[] memo = File.ReadAllLines(FilePath);
				if (memo[3] == "NoSetup")
				{
					term.AutorunOrScript = true;
					term.PreNext();
					term.OutputModule.text = "You haven't configured the loader yet!\nFor configured loader input 'setupLoader' + 'T' or 'X'";
					term.AutorunOrScript = false;
					term.Start();
				}
				else if (memo[3] == "WinMode")
				{
					SceneManager.LoadSceneAsync(1);
				}
			}
		}
	}
}
