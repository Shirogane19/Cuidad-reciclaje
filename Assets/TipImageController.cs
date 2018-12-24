using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TipImageController : MonoBehaviour {

	/*
	 * Allow to set an image in orden in the UI image component
	 */
	public Sprite[] tipImageList;
	Image tipImg;
	private int actualPosition;
	//----------------------------------------------------------
	void Awake () 
	{
		tipImg = GameObject.Find ("TruckGameTipImg").GetComponent<Image>();
	}
	//----------------------------------------------------------
	void Start()
	{
		actualPosition = 0;
	}
	//----------------------------------------------------------
	public void passRight()
	{
		if (actualPosition < tipImageList.Length-1)
		{
			actualPosition++;
			tipImg.sprite = tipImageList[actualPosition];
		}
	}
	//----------------------------------------------------------
	public void passLeft()
	{
		if (actualPosition > 0)
		{
			actualPosition--;
			tipImg.sprite = tipImageList[actualPosition];
		}
	}
	//----------------------------------------------------------
}
