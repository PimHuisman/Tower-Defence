using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Currency : MonoBehaviour {
	public float myCurrency;
	public Text currencyText;

	void Update() {
		currencyText.text = myCurrency.ToString();
	}
}
