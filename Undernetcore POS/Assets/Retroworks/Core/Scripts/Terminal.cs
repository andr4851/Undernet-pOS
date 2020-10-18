using System;
using System.Collections;
using System.IO;
using System.Net;
using UnityEngine;
using UnityEngine.UI;


public class Terminal : MonoBehaviour {

	//Spawner
	public Transform Main;

	//Main objects
	public GameObject Inp;
	public GameObject Output;
	public GameObject TermWin;
	public RawImage BackGround;
	public Color InpNameColor;
	//Private objects
	[HideInInspector]
	public GameObject ActInp;
	private InputField OldInp;
	private InputField InpModule;
	private GameObject ActOut;
	[HideInInspector]
	public Text OutputModule;
	private string[] Splits;
	[HideInInspector]
	public string com;
	public bool WindowMode;
	private bool ErrorStop = false;
	public bool AutorunOrScript;
	private DirectoryInfo ThisDir;
	private bool OnlyStart = true;


	//On start terminal else next enter
	public void Start(){
		if (AutorunOrScript == false)
		{
			ActInp = Instantiate(Inp);
			ActInp.transform.SetParent(Main);
			ActInp.transform.localScale = new Vector3(1, 1, 1);
			InpModule = ActInp.GetComponentInChildren<InputField>();
			if (WindowMode != false)
			{
				string name = SystemInfo.deviceName + "@" + DesktopObject.dsk.UserName.text + ":";
				ActInp.GetComponent<Text>().text = name;
				ActInp.GetComponent<Text>().color = InpNameColor;
			}
			{

			}
			InpModule.onEndEdit.AddListener(delegate (string arg0)
			{
				Enter();
			});
		}
		if (OnlyStart != false)
		{
			ThisDir = new DirectoryInfo("/storage/emulated/0");
			OnlyStart = false;
		}
		Debug.Log(ThisDir.FullName.ToString());
	}
		//On click enter
	public void Enter(){
		if (AutorunOrScript == false)
		{
			com = InpModule.text;
		}
		Splits = com.Split(' ');
		SpliterFunc ();
		//If input is empty
		if (String.IsNullOrEmpty (com)) {
			if (!ErrorStop == true) {
				if (AutorunOrScript == false)
					next ();
				ErrorStop = true;
			}
		}
		switch(com){
		//Output version of core
		case "ver":
				PreNext();
				OutputModule.text = " version of system: 2.0 stable \n version of core: 0.97 mod \n Distributive: Undernet pOS \n Code name: Arpanet";
			if (AutorunOrScript == false)
			{
				next();
			}
			break;
		//Remove this terminal window
		case "exit":
				if (TermWin == null) 
				{
					PreNext();
					OutputModule.text = "You in terminal only mode!";
					if (AutorunOrScript == false)
					{
						next();
					}
					break;
				}
				GetComponentInParent<Window>().Dest();
			break;
		case "quit":
			Application.Quit ();
			break;
		case "dev":
			PreNext ();
			OutputModule.color = Color.green;
			OutputModule.text = "Netreba Andrey: Kernel and system developer \n" +
					"Süleyman Yasir Kula: file manager developer";
			if (AutorunOrScript == false)
			{
				next();
			}
			break;
		case "Mydevice":
			PreNext();
			OutputModule.color = Color.green;
			OutputModule.text = "OS: " + SystemInfo.operatingSystem + "\n" + "Device name: " + SystemInfo.deviceName + "\n" + "Device type: "+ SystemInfo.deviceType + "\n"+ "Device model: "+ SystemInfo.deviceModel + "\n" + "Graphics device name: " + SystemInfo.graphicsDeviceName;
			if (AutorunOrScript == false)
			{
				next();
			}
			break;
		case "LoadWinMode":
			UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(1);
			break;
		case "DateTime":
			PreNext();
			OutputModule.text = Convert.ToString(DateTime.Now);
			if (AutorunOrScript == false)
			{
				next();
			}
			break;
			case "help":
				PreNext();
				OutputModule.text = "DateTime - this time \n" +
					"LoadWinMode - load window mode \n" +
	 "Mydevice - device information \n" +
  "dev - developers \n" +
  "ver - core version \n" +
  "quit - exit of app \n" +
  "exit - exit of terminal(Window mode only) \n" +
  "echo - you output in terminal \n" +
  "whoami - Username of active user \n" +
  "math - simple calculater \n" +
  "file - work with file \n" +
  "ColBack [color] - Background color(blue, red, green, black) or ColBack CustomImg [path] \n" +
  "downl [ulrFile] [FilePath] \n" +
  "setupLoader [arg] need to setup applucation loader \n" +
  "AddUser [Username] [password] - add user in system \n" +
  "DeleteUser [Username] - delete user \n" +
  "StartError [title(One word only!)] [memo] - open error window with your title and memo (Window mode only) \n" +
  "whoami - Username (window mode only)";
				next();
				break;
			case "whoami":
				if (WindowMode != false) {
					PreNext();
					OutputModule.text = DesktopObject.dsk.UserName.text;
					if (AutorunOrScript == false)
						next();
				}
				else {
					PreNext();
					OutputModule.text = "root";
					if (AutorunOrScript == false)
						next();
				}
				break;
			//If invalid command
			default:
			if (ErrorStop == true){
				ErrorStop = false;
				break;
			}
			PreNext ();
			OutputModule.color = Color.red;
			OutputModule.text = "Invalid command!";
			if (AutorunOrScript == false)
			{
				next();
			}
			break;
		}
		if(AutorunOrScript == false)
			SystemLog.SysLog.AppendLog();
		if (AutorunOrScript == true)
		{
			ActInp.transform.SetAsLastSibling();
			InpModule.readOnly = false;
		}
	}
	//Create output
	public void PreNext(){
		ActOut = Instantiate (Output);
		ActOut.transform.SetParent (Main);
		ActOut.transform.localScale = new Vector3 (1, 1, 1);
		OutputModule = ActOut.GetComponent<Text> ();
	}
	public void OutputText(string text)
	{
		PreNext();
		OutputModule.text = text;

	}
	//Next input
	public void next(){
		OldInp = InpModule;
		OldInp.readOnly = true;
		Start ();
	}
	private void SpliterFunc(){
		//Simple echo command
		switch (Splits[0]) {
			case "echo":
				Splits[0] = String.Empty;
				PreNext();
				OutputModule.text = String.Join(" ", Splits);
				if (AutorunOrScript == false)
				{
					next();
				}
				ErrorStop = true;
				break;
			//Math function
			case "math":
				double one;
				double two;
				double three;
				switch (Splits[1]) {
					case "inf":
						PreNext();
						OutputModule.text = "_____________________________________________________";
						PreNext();
						OutputModule.text = "Retrowork company 2019-2020 |--//|";
						PreNext();
						OutputModule.text = "Undernet core math module version 1.3";
						PreNext();
						OutputModule.text = "For help please input 'math help'";
						PreNext();
						OutputModule.text = "_____________________________________________________";
						if (AutorunOrScript == false)
						{
							next();
						}
						ErrorStop = true;
						break;
					case "pi":
						PreNext();
						OutputModule.text = Convert.ToString(Math.PI);
						if (AutorunOrScript == false)
						{
							next();
						}
						ErrorStop = true;
						break;
					case "E":
						PreNext();
						OutputModule.text = Convert.ToString(Math.E);
						if (AutorunOrScript == false)
						{
							next();
						}
						ErrorStop = true;
						break;
					case "help":
						PreNext();
						OutputModule.text = "[Double] [operator] [Double] \n inf - information \n pi - pi number \n E - e number\n LinearFunc(y=kx) - [k] [x] [operator(plus or minus)(optional)] [b(optional)] \n operators: +(plus), -(minus), *(multiplication), /(division), %(modulo divison) %%(persent)";
						if (AutorunOrScript == false)
						{
							next();
						}
						break;
					case "LinearFunc":
						double k;
						double x;
						double b;
						k = Convert.ToDouble(Splits[2]);
						x = Convert.ToDouble(Splits[3]);
						
						double preFinal = k * x;
						if(Splits[5] != null)
						{
							if (Splits[4] == "-")
							{
								b = Convert.ToDouble(Splits[5]);
								PreNext();
								OutputModule.text = "x = " + x.ToString() + "\n y = " + Convert.ToString(preFinal - b);
								ErrorStop = true;
								next();
								
							}
							else if (Splits[4] == "+")
							{
								b = Convert.ToDouble(Splits[5]);
								PreNext();
								OutputModule.text = "x = " + x.ToString() + "\n y = " + Convert.ToString(preFinal + b);
								ErrorStop = true;
								next();

							}
						}
						break;

				}
				switch (Splits[2]) {
					//plus
					case "+":
						one = Convert.ToDouble(Splits[1]);
						two = Convert.ToDouble(Splits[3]);
						three = one + two;
						PreNext();
						OutputModule.text = Convert.ToString(three);
						if (AutorunOrScript == false)
						{
							next();
						}
						ErrorStop = true;
						break;
					//minus
					case "-":
						one = Convert.ToDouble(Splits[1]);
						two = Convert.ToDouble(Splits[3]);
						three = one - two;
						PreNext();
						OutputModule.text = Convert.ToString(three);
						if (AutorunOrScript == false)
							next();
						ErrorStop = true;
						break;
					//umnodjenie
					case "*":
						one = Convert.ToDouble(Splits[1]);
						two = Convert.ToDouble(Splits[3]);
						three = one * two;
						PreNext();
						OutputModule.text = Convert.ToString(three);
						if (AutorunOrScript == false)
							next();
						ErrorStop = true;
						break;
					//delenie
					case "/":
						one = Convert.ToDouble(Splits[1]);
						two = Convert.ToDouble(Splits[3]);
						PreNext();
						OutputModule.text = Convert.ToString(one / two);
						if (AutorunOrScript == false)
							next();
						ErrorStop = true;
						break;
					case "%":
						one = Convert.ToDouble(Splits[1]);
						two = Convert.ToDouble(Splits[3]);
						PreNext();
						OutputModule.text = Convert.ToString(one % two);
						if (AutorunOrScript == false)
							next();
						ErrorStop = true;
						break;
					case "%%":
						one = Convert.ToDouble(Splits[1]);
						two = Convert.ToDouble(Splits[3]);
						PreNext();
						OutputModule.text = Convert.ToString(one / 100 * two);
						if (AutorunOrScript == false)
							next();
						ErrorStop = true;
						break;
				}
				break;
			case "file":
				string path;
				string[] directories;
				string[] files;
				switch (Splits[1])
				{
					case "open":
						switch (Splits[2])
						{
							case "text":
								path = Splits[3];
								Debug.Log(path);
								PreNext();
								try
								{
									OutputModule.text = File.ReadAllText(path);
								}
								catch (FileNotFoundException)
								{
									OutputModule.color = Color.red;
									OutputModule.text = "File not found!";
									ErrorStop = true;
									if (AutorunOrScript == false)
										next();

								}
								finally
								{
									ErrorStop = true;
									if (AutorunOrScript == false)
										next();
								}
								break;
							case "script":
								GetComponent<TerminalScripting>().path = Splits[3];
								GetComponent<TerminalScripting>().OpenScript();
								break;
						}
						break;
					case "delete":
						switch (Splits[2]){
							case "folder":
								path = Splits[3];
								Debug.Log(path);
								try
								{
									Directory.Delete(path);
								}
								catch (DirectoryNotFoundException)
								{
									OutputModule.color = Color.red;
									OutputModule.text = "Directory not found!";
									if (AutorunOrScript == false)
										next();
									ErrorStop = true;
								}
								finally
								{
									if (AutorunOrScript == false)
										next();
									ErrorStop = true;
								}
								break;
							case "file":
								path = Splits[3];
								Debug.Log(path);
								try
								{
									File.Delete(path);
								}
								catch (FileNotFoundException) 
								{
									OutputModule.color = Color.red;
									OutputModule.text = "File not found!";
									ErrorStop = true;
									if (AutorunOrScript == false)
										next();
								}
								finally
								{
									ErrorStop = true;
									if (AutorunOrScript == false)
										next();
								}
								break;

						}
						break;
					case "create":
						switch (Splits[2])
						{
							case "folder":
								path = Splits[3];
								Debug.Log(path);
								try
								{
									Directory.CreateDirectory(path);
								}
								catch (DirectoryNotFoundException)
								{
									OutputModule.color = Color.red;
									OutputModule.text = "Directory not found!";
									if (AutorunOrScript == false)
										next();
									ErrorStop = true;
								}
								finally
								{
									if (AutorunOrScript == false)
										next();
									ErrorStop = true;
								}
								break;
							case "file":
								path = Splits[3];
								Debug.Log(path);
								try
								{
									File.Create(path);
								}
								catch (DirectoryNotFoundException)
								{
									OutputModule.color = Color.red;
									OutputModule.text = "Directory not found!";
									ErrorStop = true;
									if (AutorunOrScript == false)
										next();
								}
								finally
								{
									ErrorStop = true;
									if (AutorunOrScript == false)
										next();
								}
								break;

						}
						break;
					case "view":
						PreNext();
						OutputModule.text = String.Empty;
						directories = Directory.GetDirectories(ThisDir.FullName);
						foreach (string s in directories) 
						{
							OutputModule.text += s + "\n";
						}
						files = Directory.GetFiles(ThisDir.FullName);
						foreach (string x in files) 
						{
							OutputModule.text += x + "\n";
						}
						next();
						ErrorStop = true;
						break;
					case "go":
						string newpath = Splits[2];
						try
						{
							ThisDir = new DirectoryInfo(newpath);
						}
						catch (Exception)
						{
							PreNext();
							OutputModule.color = Color.red;
							OutputModule.text = "Directory " + Splits[2] + " not found!";
							if (AutorunOrScript == false)
								next();
							ErrorStop = true;
						}
						finally
						{
							if (AutorunOrScript == false)
								next();
							Debug.Log(ThisDir.FullName.ToString() + " " + newpath);
							ErrorStop = true;
						}
						break;
					case "help":
						PreNext();
						OutputModule.text = "[function] [argument] [Full path]\n inf - information[func] \n open - open file[func]\n delete - delete file or folder[func] \n create - create file or folder[func]\n text - open text file(No space in file name!)[arg] \n go - go to directory [func] \n view - view this directories";
						if (AutorunOrScript == false)
							next();
						ErrorStop = true;
						break;
					case "inf":
						PreNext();
						OutputModule.text = "_____________________________________________________ \n Retrowork company 2019-2020 |--//| \n Undernet core file module version 1.0 \n For help please input 'file help' \n _____________________________________________________";
						if (AutorunOrScript == false)
							next();
						ErrorStop = true;
						break;
				}
				break;
			case "ColBack":
				switch (Splits[1]) 
				{
					case "blue":
						BackGround.color = Color.blue;
						BackGround.texture = null;
						if (AutorunOrScript == false)
							next();
						ErrorStop = true;
						break;
					case "red":
						BackGround.color = Color.red;
						BackGround.texture = null;
						if (AutorunOrScript == false) 
							next();
						ErrorStop = true;
						break;
					case "green":
						BackGround.color = Color.green;
						BackGround.texture = null;
						if (AutorunOrScript == false)
							next();
						ErrorStop = true;
						break;
					case "black":
						BackGround.color = Color.black;
						BackGround.texture = null;
						if (AutorunOrScript == false)
							next();
						ErrorStop = true;
						break;
					case "CustomImg":
						BackGround.color = new Color(205, 205, 205, 0.8f);
						WWW url = new WWW("file://" + Splits[2]);
						BackGround.texture = url.texture;
						if (AutorunOrScript == false)
							next();
						ErrorStop = true;
						break;
					default:
						PreNext();
						OutputModule.text = "Color not found";
						if (AutorunOrScript == false)
							next();
						ErrorStop = true;
						break;

				}
				break;
			case "setupLoader":
				string FilePath = "/storage/emulated/0/Undernet/sys/Loader.usf";
				switch (Splits[1]) 
				{
					
					case "T":
						File.WriteAllText(FilePath, "[TypeOfLoad]\nTextInfo\n[Mode]\nTerminalOnly");
						next();
						ErrorStop = true;
						break;
					case "X":
						File.WriteAllText(FilePath, "[TypeOfLoad]\nTextInfo\n[Mode]\nWinMode");
						next();
						ErrorStop = true;
						break;
					case "NoSetup":
						File.WriteAllText(FilePath, "[TypeOfLoad]\nTextInfo\n[Mode]\nNoSetup");
						next();
						ErrorStop = true;
						break;
					default:
						PreNext();
						OutputModule.text = "This argument is not found!";
						OutputModule.color = Color.red;
						next();
						ErrorStop = true;
						break;
				}
				break;
			case "AddUser":
				string usrPath = "/storage/emulated/0/Undernet/usr";
				Directory.CreateDirectory(usrPath + "/" + Splits[1]);
				string file = "[asses]\nBaseUser\n[password]\n" + Splits[2];
				File.WriteAllText(usrPath + "/" + Splits[1] + "/" + "UserData.uud", file);
				File.CreateText(usrPath + "/" + Splits[1] + "/" + "DesktopSettings.usf");
				ErrorStop = true;
				next();
				break;
			case "DeleteUser":
				usrPath = "/storage/emulated/0/Undernet/usr";
				string[] DelsFiles = Directory.GetFiles(usrPath + "/" + Splits[1]);
				PreNext();
				OutputModule.text = String.Empty;
				for (int i = 0; i < DelsFiles.Length; i++)
				{
					OutputText("Delete file in this path: " + DelsFiles[i]);
					File.Delete(DelsFiles[i]);
				}
				Directory.Delete(usrPath + "/" + Splits[1]);
				ErrorStop = true;
				OutputText("User " + Splits[1] + " now was been deleting!");
				next();
				break;
			case "downl":
				string urlPath = Splits[1];
				string Path = Splits[2];
				StartCoroutine(Downloader(urlPath, Path));
				ErrorStop = true;
				break;
			case "StartError":
				if (WindowMode == true)
				{
					string title = Splits[1];
					Splits[0] = String.Empty;
					Splits[1] = String.Empty;
					string memo = String.Join(" ", Splits);
					ErrorsLogic.ERRLog.ErrorStart(title, memo);
					if (AutorunOrScript == false)
						next();
					ErrorStop = true;
				}
				else
				{
					PreNext();
					OutputModule.text = "You in terminal only mode!";
					OutputModule.color = Color.red;
					if(AutorunOrScript == false)
						next();
					ErrorStop = true;
				}
				break;
		}
	}
	IEnumerator Downloader(string url, string path)
	{
		WebClient webClient = new WebClient();
		webClient.Headers.Add(HttpRequestHeader.UserAgent, "Other");
		webClient.Headers.Add(HttpRequestHeader.Accept, "applucation/pdf");
		OutputText("Downloading file from " + url + " to " + path);
		webClient.DownloadFile(url, path);
		OutputText("File download to " + path);
		if(AutorunOrScript != false)
			next();
		yield return null;
	}
}

