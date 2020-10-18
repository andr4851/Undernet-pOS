using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SystemMonitorScript : MonoBehaviour
{

	public Text DeviseInformation;
	public Text CPULoad;
	public Text RAMLoad;
	public Text FPS;
	public Text SoundLevel;
	public Text MousePos;
	public float updateInterval = 0.5F;
	private double lastInterval;
	private int frames = 0;
	private float fps;
	System.Diagnostics.PerformanceCounter cpuCounter;
	System.Diagnostics.PerformanceCounter ramCounter;

	void Start()
	{
		DeviseInformation.text = "OS: " + SystemInfo.operatingSystem + "\n" + "Device name: " + SystemInfo.deviceName + "\n" + "Device type: " + SystemInfo.deviceType + "\n" + "Device model: " + SystemInfo.deviceModel + "\n" + "Graphics device name: " + SystemInfo.graphicsDeviceName;
		lastInterval = Time.realtimeSinceStartup;
		frames = 0;
		////////////////////////////////////////////
		System.Diagnostics.PerformanceCounterCategory.Exists("PerformanceCounter");

		cpuCounter = new System.Diagnostics.PerformanceCounter();

		cpuCounter.CategoryName = "Processor";
		cpuCounter.CounterName = "% Processor Time";
		cpuCounter.InstanceName = "_Total";

		ramCounter = new System.Diagnostics.PerformanceCounter("Memory", "Available MBytes");

	}

	// Update is called once per frame
	void Update()
	{
		SoundLevel.text = System.Convert.ToString(AudioListener.volume * 100) + "%";
		CPULoad.text = getCurrentCpuUsage();
		RAMLoad.text = getAvailableRAM();

		MousePos.text = Input.mousePosition.ToString(); ;
		FPS.text = fps.ToString("f2");
		++frames;
		float timeNow = Time.realtimeSinceStartup;
		if (timeNow > lastInterval + updateInterval)
		{
			fps = frames / System.Convert.ToInt32(timeNow - lastInterval);
			frames = 0;
			lastInterval = timeNow;
		}
	}
	public string getCurrentCpuUsage()
	{
		return cpuCounter.NextValue() + "%";
	}
	public string getAvailableRAM()
	{
		return ramCounter.NextValue() + "MB";
	}
}

