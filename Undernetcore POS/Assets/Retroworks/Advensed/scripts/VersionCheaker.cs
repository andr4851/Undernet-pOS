using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Net;

public class VersionCheaker : MonoBehaviour {

	public string Url;
	public string Path;
	public string Version;

	void Start () {
		if (!Directory.Exists(Path))
		{
			Directory.CreateDirectory(Path);
		}
	}
	
	public void Cheack()
	{
		
		WebClient webClient = new WebClient();
		webClient.Headers.Add(HttpRequestHeader.UserAgent, "Other");
		webClient.Headers.Add(HttpRequestHeader.Accept, "applucation/pdf");
		webClient.DownloadFile(Url, "/storage/emulated/0/Undernet/tmp/version.txt");
		if (Version == File.ReadAllText("/storage/emulated/0/Undernet/tmp/version.txt"))
		{
			ErrorsLogic.ERRLog.ErrorStart("Updates and version", "New version isn't found");
		}
		else
		{
			ErrorsLogic.ERRLog.ErrorStart("Updates and version", "New version found " + File.ReadAllText("/storage/emulated/0/Undernet/tmp/version.txt"));
		}

		File.Delete("/storage/emulated/0/Undernet/tmp/version.txt");
	}
}
