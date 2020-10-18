using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DesktopObject : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	public Transform MainManager;
	public Transform WindowManager;
	public Transform ButtonManager;
	public GameObject DesktopMode;
	public GameObject LockDown;


	public GameObject contest;
	public RawImage BG;
	public Text clock, LockDownClock;
	public Text UserName, LockUserName;
	public Slider sound;
	public Image BattoryImg;
	public Text BattoryText;
	public GameObject Terminal, About, SystemMonitor, Notepad, FileManager;
	public GameObject TermButton;
	private Button[] MiniButa;
	private bool IsDown;

	public static DesktopObject dsk = new DesktopObject();
	void Awake()
	{
		dsk = this;
	}
	void Start()
	{
		LockUserName.text = UserName.text;
		try
		{
			string[] pathBG = File.ReadAllLines("/storage/emulated/0/Undernet/usr/" + UserName.text + "/DesktopSettings.usf");
			Debug.Log(pathBG[0]);
			WWW url = new WWW(pathBG[0]);
			BG.texture = url.texture;
		}
		catch(FileNotFoundException)
		{
			ErrorsLogic.ERRLog.ErrorStart("File not found", "File 'DesktopSettings.usf' not found! \n Desktop isn't automatic setup! \n Please setup your desktop again");
		}
		catch (DirectoryNotFoundException)
		{
			ErrorsLogic.ERRLog.ErrorStart("File not found", "File 'DesktopSettings.usf' not found! \n Desktop isn't automatic setup! \n Please setup your desktop again");
		}
	}
	void Update() 
	{
		Vector3 PointerPos = Input.mousePosition;
		if (Input.GetKeyDown(KeyCode.Mouse1))
		{
			GameObject ActContest = Instantiate(contest, MainManager);
			ActContest.transform.localScale = new Vector3(1, 1, 1);
			ActContest.transform.position = PointerPos;
		}
		////////////////////////////////////////////////////////
		clock.text = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + " " + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
		LockDownClock.text = DateTime.Now.Hour + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Second + "\n" + DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
		AudioListener.volume = sound.value;
		BattoryImg.fillAmount = SystemInfo.batteryLevel;
		BattoryText.text = Convert.ToString(SystemInfo.batteryLevel * 100) + "%";
		///////////////////////////////////////////////////////
	}
	
	public void Quit() 
	{
		Application.Quit();
	}
	public void LoadTerminalOly() 
	{
		UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(0);
	}
	public void OpenTerminal() 
	{
		GameObject ActTerm = Instantiate(Terminal, WindowManager);
		ActTerm.transform.localScale = new Vector3(1, 1, 1);
		GameObject ActButs = Instantiate(TermButton, ButtonManager);
		MiniButa = ActButs.GetComponentsInChildren<Button>();
		MiniButa[0].onClick.AddListener(delegate {
			ActTerm.SetActive(true);
			});
		MiniButa[1].onClick.AddListener(delegate { 
			ActTerm.SetActive(false);
		});
		ActTerm.GetComponent<Window>().MiniBut = MiniButa;

	}
	public void OpenAbout() 
	{
		GameObject ActAbout = Instantiate(About, WindowManager);
		ActAbout.transform.localScale = new Vector3(1, 1, 1);
		GameObject ActButs = Instantiate(TermButton, ButtonManager);
		MiniButa = ActButs.GetComponentsInChildren<Button>();
		MiniButa[0].onClick.AddListener(delegate {
			ActAbout.SetActive(true);
		});
		MiniButa[1].onClick.AddListener(delegate {
			ActAbout.SetActive(false);
		});
		ActAbout.GetComponent<Window>().MiniBut = MiniButa;

	}
	public void OpenSystemMonitor()
	{
		GameObject ActSysMon = Instantiate(SystemMonitor, WindowManager);
		ActSysMon.transform.localScale = new Vector3(1, 1, 1);
		GameObject ActButs = Instantiate(TermButton, ButtonManager);
		MiniButa = ActButs.GetComponentsInChildren<Button>();
		MiniButa[0].onClick.AddListener(delegate {
			ActSysMon.SetActive(true);
		});
		MiniButa[1].onClick.AddListener(delegate {
			ActSysMon.SetActive(false);
		});
		ActSysMon.GetComponent<Window>().MiniBut = MiniButa;
	}
	public void OpenNotepad()
	{
		GameObject ActNote = Instantiate(Notepad, WindowManager);
		ActNote.transform.localScale = new Vector3(1, 1, 1);
		GameObject ActButs = Instantiate(TermButton, ButtonManager);
		MiniButa = ActButs.GetComponentsInChildren<Button>();
		MiniButa[0].onClick.AddListener(delegate {
			ActNote.SetActive(true);
		});
		MiniButa[1].onClick.AddListener(delegate {
			ActNote.SetActive(false);
		});
		ActNote.GetComponent<Window>().MiniBut = MiniButa;
	}

	public void OpenFileManager()
	{
		GameObject ActFM = Instantiate(FileManager, WindowManager);
		ActFM.transform.localScale = new Vector3(1, 1, 1);
		GameObject ActButs = Instantiate(TermButton, ButtonManager);
		MiniButa = ActButs.GetComponentsInChildren<Button>();
		MiniButa[0].onClick.AddListener(delegate {
			ActFM.SetActive(true);
		});
		MiniButa[1].onClick.AddListener(delegate {
			ActFM.SetActive(false);
		});
		ActFM.GetComponent<Window>().MiniBut = MiniButa;
	}

	public void OnPointerDown(PointerEventData eventData)
	{
		Vector3 PointerPos = Input.mousePosition;
		if (Input.touchCount == 2 && IsDown != true) 
		{
			IsDown = true;
			GameObject ActContest = Instantiate(contest, MainManager);
			IsDown = true;
			ActContest.transform.localScale = new Vector3(1, 1, 1);
			IsDown = true;
			ActContest.transform.position = PointerPos;
			IsDown = true;
		}
	}
	public void OnPointerUp(PointerEventData eventData)
	{
		IsDown = false;
	}
}
