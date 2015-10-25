using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class column : MonoBehaviour {

	[SerializeField] Image bar;
	[SerializeField] Text displayValue;
	[SerializeField] Text percent;

	// Use this for initialization
	void Start () {
		SetValue (0, 0f);
	}

	public void SetValue(int x, float scale){
		Vector3 oldScale = bar.transform.localScale;
		oldScale.y = scale;
		bar.transform.localScale = oldScale;
		displayValue.text = "" + x;
		percent.text = String.Format("{0:P2}",scale);
	}
}
