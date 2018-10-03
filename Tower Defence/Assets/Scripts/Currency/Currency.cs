using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Currency : MonoBehaviour {
	public float myCurrency;
	public string currencyString;
	public GameObject currencyPanel;
	public Text currencyText;
	public GameObject newCurrencyObject;
	public GameObject objectPlace;
	public float timeToDisableObject;

	void Update() {
		currencyText.text = currencyString + myCurrency.ToString();
	}

	public void AddCurrency(float amount) {
		GameObject newObject = Instantiate(newCurrencyObject, currencyPanel.transform);
		newObject.GetComponent<Text>().text = "+ " + amount;
		float seconds = newObject.GetComponent<Animation>().clip.length;
		print("Void amount: " + amount);
		
		print("Loading...");
		StartCoroutine("CurrencyRoutine", seconds);
		print("Done!");
		Destroy(newObject, timeToDisableObject);
	}

	public IEnumerator CurrencyRoutine(float seconds) {
		yield return new WaitForSeconds(seconds);
	}

}

