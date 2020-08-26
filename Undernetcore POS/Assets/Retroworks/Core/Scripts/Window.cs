using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Window : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler,IPointerDownHandler {

	public GameObject Win;
	public GameObject ResizeArea;
	public Image destroy;
	public Image Hide;
	public Image Open;
	public float time;
	public Color Null;
	public Color One;
	public Color Two;
	public CanvasGroup Alpfa;
	private Vector3 mouseStartingPos;
	public bool isDragging = true;
	public int pixeSafeZone = 20;
	[HideInInspector]
	public Button[] MiniBut;
	public bool NoResize;

	//67027699
	void Start()
	{
		if (NoResize != false) 
		{
			ResizeArea.SetActive(false);
		}
	}
	void FixedUpdate(){
	}
	public void ON2(){
		Open.CrossFadeColor (Two, time, false, true);
	}
	public void OFF2(){
		Open.CrossFadeColor (Null, time, false, true);
	}
	public void ON1(){
		Hide.CrossFadeColor (Two, time, false, true);
	}
	public void OFF1(){
		Hide.CrossFadeColor (Null, time, false, true);
	}
	public void ON(){
		destroy.CrossFadeColor (One, time, false, true);
	}
	public void OFF(){
		destroy.CrossFadeColor (Null, time, false, true);
	}
	public void Dest(){
		Destroy (Win);
		Destroy (MiniBut[0].gameObject);
	}
		
	public void OnBeginDrag(PointerEventData eventData)
	{
		Alpfa.alpha = 0.6f;
		mouseStartingPos = Input.mousePosition;
	}

	public void OnDrag(PointerEventData eventData)
	{
		
		if (isDragging)
		{ 
			
			transform.position -= mouseStartingPos - Input.mousePosition;
			mouseStartingPos = Input.mousePosition;
		}
	}



	public void OnEndDrag(PointerEventData eventData)
	{

		Alpfa.alpha = 1;
		CheckOutScreen();

	}
	private void CheckOutScreen ()
	{
		if (transform.position.x > Screen.width)
		{
			transform.position = new Vector3(Screen.width - pixeSafeZone, transform.position.y);
		}
		else if (transform.position.x <= 0)
		{
			transform.position = new Vector3(pixeSafeZone, transform.position.y);
		}
		if (transform.position.y > Screen.height)
		{
			transform.position = new Vector3(transform.position.x, Screen.height - pixeSafeZone);
		}
		else if (transform.position.y <= 0)
		{
			transform.position = new Vector3(transform.position.x, pixeSafeZone);
		}
	}
	public void OnPointerDown(PointerEventData eventData){
		transform.SetAsLastSibling();
	}

}
