using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ShoseButt : MonoBehaviour {

	public Text FileNameText;
    public int Index;

	public void OnClick()
    {
        ShoseBG.Instace.SelectBG(Index);
    }
}
