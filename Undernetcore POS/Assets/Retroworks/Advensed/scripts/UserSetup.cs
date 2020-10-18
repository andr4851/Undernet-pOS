using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class UserSetup : MonoBehaviour {

    public string RootPath = "/storage/emulated/0/Undernet/usr/root";
    public InputField password;

    public void SetupSuperUser()
    {
        if (!Directory.Exists(RootPath)){
            Directory.CreateDirectory(RootPath);
            string file = "[asses]\nSuperUser\n[password]\n" + password.text;
            File.WriteAllText(RootPath + "/UserData.uud", file);
        }
    }
}
