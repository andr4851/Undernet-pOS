using System;
using System.IO;
using UnityEngine;

public class TerminalScripting : MonoBehaviour {

    [HideInInspector]
    public string path;
    public string[] lines;
    [HideInInspector]
    public Terminal term;

    void Start()
    {
        term = GetComponent<Terminal>();
    }
    public void OpenScript()
    {
        term.AutorunOrScript = true;
        if (path.Contains(".uts"))
        {
            int leah = 0;
            lines = File.ReadAllLines(path);
            foreach(string line in lines)
            {
                if (line[0] != '%')
                {
                    term.com = line;
                    term.Enter();
                    term.OutputModule.gameObject.transform.SetAsLastSibling();
                }
                if (leah > lines.Length)
                {
                    term.com = String.Empty;
                    leah = 0;
                    term.AutorunOrScript = false;
                    term.next();
                    term.ActInp.transform.SetAsLastSibling();

                }
                else
                {
                    leah++;
                    Debug.Log(leah);
                    term.AutorunOrScript = false;

                }
            }
        }
        else
        {
            term.PreNext();
            term.OutputModule.text = "This file is not an undernet script";
            term.AutorunOrScript = false;
            term.next();
        }
    }

}
