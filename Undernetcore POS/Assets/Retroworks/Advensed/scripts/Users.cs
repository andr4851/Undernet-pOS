using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class Users : MonoBehaviour {

    public Transform UserBase;
    public Animator LogOnAnumation;
    public GameObject UserView;
    public GameObject Error;
    ///////////////////////////////////////////
    public string usrFolderPath = "/storage/emulated/0/Undernet/usr";
    public GameObject RegestrationSuperUser;

    public GameObject Loger;
    public GameObject Desktop;
    public GameObject ErrorPanel, ErrorText;
    //////////////////////////////////////////
    public Text time, date, UsernameINWork;
    public InputField UserName;
    public InputField password;

    public Text userName;
    private void Update()
    {
        time.text = DateTime.Now.Second + ":" + DateTime.Now.Minute + ":" + DateTime.Now.Hour;
        date.text = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year + "\n" + DateTime.Now.DayOfWeek;
    }
    private void Start()
    {
       
        if (!Directory.Exists(usrFolderPath))
        {
            Directory.CreateDirectory(usrFolderPath);
            RegestrationSuperUser.SetActive(true);
        }

        DirectoryInfo directoryInfo = new DirectoryInfo(usrFolderPath);
        DirectoryInfo[] Users = directoryInfo.GetDirectories().ToArray();
        for (int i = 0; i < Users.Length; i++)
        {
           GameObject UserCart = Instantiate(UserView, UserBase);
           userName = UserCart.GetComponentInChildren<Text>();
           userName.text = Users[i].Name;
        }

    }
    public void LogOn()
    {
        if (Directory.Exists(usrFolderPath + "/" + UserName.text))
        {
            string[] lines = null;
            try
            {
              lines = File.ReadAllLines(usrFolderPath + "/" + UserName.text + "/UserData.uud");
            }
            catch (FileNotFoundException)
            {
                Debug.Log("Inputs be clear!");
                ErrorPanel.SetActive(true); ErrorText.SetActive(true);
            }
            finally
            {
               
                if (password.text == lines[3])
                {
                    Loger.SetActive(false);
                    Desktop.SetActive(true);
                    UsernameINWork.text = UserName.text;
                    Debug.Log("Asses grouded!");
                }
                else
                {
                    Error.SetActive(true);
                    Debug.Log("Asses denite!");
                }
            }
        }
        else
        {
            Error.SetActive(true);
            Debug.LogError("User not found!");
        }
    }

    public void OpenLogOn()
    {
        LogOnAnumation.Play("StartLoger");
    }
}
