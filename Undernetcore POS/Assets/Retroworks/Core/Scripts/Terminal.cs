﻿using System;
using System.IO;
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
				OutputModule.text = " version of system: 0.9.3 unstable \n version of core: 0.8 mod \n Distributive: Undernet pOS \n Code name: Skynet";
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
			OutputModule.text = "Netreba Andrey: One programmer - One Developer";
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
  "dev - developer \n" +
  "ver - core version \n" +
  "quit - exit of app \n" +
  "exit - exit of terminal(Window mode only) \n" +
  "echo - you output in terminal \n" +
  "math - simple calculater \n" +
  "file - work with file \n" +
  "ColBack [color] - Background color(blue, red, green, black) or ColBack CustomImg [path]";
				next();
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
	private void PreNext(){
		ActOut = Instantiate (Output);
		ActOut.transform.SetParent (Main);
		ActOut.transform.localScale = new Vector3 (1, 1, 1);
		OutputModule = ActOut.GetComponent<Text> ();
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
						OutputModule.text = "[Double] [operator] [Double] \n inf - information \n pi - pi number \n E - e number \n operators: +(plus), -(minus), *(multiplication), /(division), %(modulo divison) %%(persent)";
						if (AutorunOrScript == false)
						{
							next();
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
						catch (DirectoryNotFoundException)
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
		}
	}
}