using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class Currency : MonoBehaviour
{
    public float myCurrency;
    public string currencyString;
    public GameObject currencyPanel;
    public Text currencyText;
    public Text currencyTextShadow;
    public GameObject newCurrencyObject;
    public GameObject objectPlace;
    public float timeToDisableObject;
    float addedAmount;

    void Update()
    {
        string s = currencyString + myCurrency.ToString();
        currencyText.text = s;
        currencyTextShadow.text = s;
		if (Input.GetButtonDown("O"))
		{
			AddCurrency(25);
		}
    }

    public void AddCurrency(float amount)
    {
        addedAmount = amount;
        GameObject newObject = Instantiate(newCurrencyObject, currencyPanel.transform);
        RectTransform objectRect = newObject.GetComponent<RectTransform>();
        objectRect = objectPlace.GetComponent<RectTransform>();
        //newObject.GetComponent<RectTransform>() = objectPlace.GetComponent<RectTransform>();

        Animator anim = newObject.GetComponent<Animator>();
        anim.enabled = true;

        newObject.GetComponent<Text>().text = "+ " + amount;
        float secs = 1;
        StartCoroutine("NewEnim", secs);
        Destroy(newObject, timeToDisableObject);
    }

    public IEnumerator NewEnim(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        myCurrency += addedAmount;

        yield return null;
    }


}

