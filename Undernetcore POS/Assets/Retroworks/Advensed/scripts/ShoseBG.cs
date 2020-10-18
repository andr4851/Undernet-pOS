using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;

public class ShoseBG : MonoBehaviour {

	public Transform FileObjectsArea;
	public GameObject FileBut;
	public RawImage BackGround;

	public RawImage PreView;
	public InputField Path;

	private DirectoryInfo drInfo = new DirectoryInfo("/storage/emulated/0/");
	private FileInfo[] files;

	public static ShoseBG Instace;

	public Users users;
	
	private void Awake()
	{
		Instace = this;
	}
	
	// Use this for initialization
	
	void Start () {
		Getter();
	}
	public void SelectBG(int index)
	{
		WWW url = new WWW("file://" + files[index].FullName);
		PreView.texture = url.texture;
		Path.text = "file://" + files[index].FullName;
		if (!File.Exists("/storage/emulated/0/Undernet/usr/" + DesktopObject.dsk.UserName.text + "/DesktopSettings.usf"))
		{
			File.CreateText("/storage/emulated/0/Undernet/usr/" + DesktopObject.dsk.UserName.text + "/DesktopSettings.usf");
		}
		else
		{
			File.WriteAllText("/storage/emulated/0/Undernet/usr/" + DesktopObject.dsk.UserName.text + "/DesktopSettings.usf", Path.text);
		}
	}
	public void SetupBG()
	{
		WWW url = new WWW(Path.text);
		BackGround.texture = url.texture;
	}
	
	 void Getter()
	{

			files = new string[] { "*.jpeg", "*.jpg", "*.png" }.SelectMany(ext => drInfo.GetFiles(ext, SearchOption.AllDirectories)).ToArray();
			for (int i = 0; i < files.Length; i++)
			{
				ShoseButt shoser = Instantiate(FileBut, FileObjectsArea).GetComponent<ShoseButt>();
				shoser.FileNameText.text = files[i].Name;
				shoser.Index = i;
			}
		
	}
}
