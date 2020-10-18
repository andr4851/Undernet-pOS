using System;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
public class Loader : MonoBehaviour {

	string FilePath = "/storage/emulated/0/Undernet/sys/Loader.usf";
	Terminal term;
	void Start () {
		term = GetComponent<Terminal>();
		term.AutorunOrScript = true;
		if (!File.Exists(FilePath))
		{
			term.AutorunOrScript = true;
			File.WriteAllText(FilePath, "[TypeOfLoad]\nTextInfo\n[Mode]\nNoSetup");
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
					if(File.ReadAllLines(FilePath)[1] == "TextInfo")
					{
					CheakFilesAndDirs();
					}
					Thread.Sleep(5000);
					term.OutputModule.text = "Load desktop...";
					SceneManager.LoadSceneAsync(1);
				}
				else if(memo[3] == "TerminalOnly")
				{
					term.AutorunOrScript = false;
					if (File.ReadAllLines(FilePath)[1] == "TextInfo")
					{
						CheakFilesAndDirs();
					}
					term.OutputModule.text = "Welcome!";
					term.Start();
				}

			}
		}
	}
	void CheakFilesAndDirs()
	{
		if(Directory.Exists("/storage/emulated/0/Undernet/sys"))
		{
			term.PreNext();
			term.OutputModule.text = "Directory '/storage/emulated/0/Undernet/sys' is exist";
		}
		else
		{
			term.PreNext();
			term.OutputModule.text = "Directory '/storage/emulated/0/Undernet/sys' isn't exist";
		}
		if (Directory.Exists("/storage/emulated/0/Undernet/usr"))
		{
			term.PreNext();
			term.OutputModule.text = "Directory '/storage/emulated/0/Undernet/usr' is exist";
		}
		else
		{
			term.PreNext();
			term.OutputModule.text = "Directory '/storage/emulated/0/Undernet/usr' isn't exist";
		}
		if (Directory.Exists("/storage/emulated/0/Undernet/tmp"))
		{
			term.PreNext();
			term.OutputModule.text = "Directory '/storage/emulated/0/Undernet/tmp' is exist";
		}
		else
		{
			term.PreNext();
			term.OutputModule.text = "Directory '/storage/emulated/0/Undernet/tmp' isn't exist";
		}
		Thread.Sleep(2000);
		if (File.Exists("/storage/emulated/0/Undernet/sys/TerminalAutorun.usf"))
		{
			term.PreNext();
			term.OutputModule.text = "File '/storage/emulated/0/Undernet/sys/TerminalAutorun.usf' is exist";
		}
		else
		{
			term.PreNext();
			term.OutputModule.text = "File '/storage/emulated/0/Undernet/sys/TerminalAutorun.usf' isn't exist";
		}
		if (File.Exists("/storage/emulated/0/Undernet/sys/TerminalLog.log"))
		{
			term.PreNext();
			term.OutputModule.text = "File '/storage/emulated/0/Undernet/sys/TerminalLog.log' is exist";
		}
		else
		{
			term.PreNext();
			term.OutputModule.text = "File '/storage/emulated/0/Undernet/sys/TerminalLog.log' isn't exist";
		}
		if (File.Exists("/storage/emulated/0/Undernet/sys/WelCust.usf"))
		{
			term.PreNext();
			term.OutputModule.text = "File '/storage/emulated/0/Undernet/sys/WelCust.usf' is exist";
		}
		else
		{
			term.PreNext();
			term.OutputModule.text = "File '/storage/emulated/0/Undernet/sys/WelCust.usf' isn't exist";
		}

	}
}
