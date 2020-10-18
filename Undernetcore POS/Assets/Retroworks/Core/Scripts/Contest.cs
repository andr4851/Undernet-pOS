using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contest : MonoBehaviour {

	public GameObject ContestMenu;
	public GameObject ChoseBGWin;

	public Transform WindowManager;
	public void OpenTerminalWithContest()
	{
		DesktopObject.dsk.OpenTerminal();
		DestroyContest();
	}
	public void OpenFileManagerWithContest()
	{
		DesktopObject.dsk.OpenFileManager();
		DestroyContest();
	}
	public void ShoseBG()
	{
		WindowManager = DesktopObject.dsk.WindowManager;
		GameObject ActBG = Instantiate(ChoseBGWin, WindowManager);
		ActBG.GetComponent<ShoseBG>().BackGround = DesktopObject.dsk.BG;
		DestroyContest();
	}
	

	private void DestroyContest() 
	{
		Destroy(ContestMenu);
	}
}

