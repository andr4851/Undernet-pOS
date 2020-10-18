using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NotepadLogic : MonoBehaviour {

    public TMP_InputField Main;
    public InputField SavePath;
    public InputField LoadPath;

    public void Save()
    {
        string text = Main.text;
        File.WriteAllText(SavePath.text, text);
        SavePath.text = String.Empty;
    }
    public void Load()
    {
        Main.text = File.ReadAllText(LoadPath.text);
        LoadPath.text = String.Empty;

    }
}
