using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerInfo : MonoBehaviour {
	TowerStat stat;
	public GameObject infoParent;
	public Image tSprite;
	public Text tName;
	public Text tDamage;
	public Text tFireRate;
	public Text tRange;

	void Start() {
		infoParent.SetActive(false);
		stat = transform.GetComponent<MyTower>().tower;
	}

	public void OnEnter () {
		infoParent.SetActive(true);
		tSprite.sprite = stat.mySprite;
		tSprite.preserveAspect = true;
		tName.text = stat.myName;
		tDamage.text = stat.damage.ToString();
		tFireRate.text = stat.fireRate.ToString();
		tRange.text = stat.range.ToString();
	}

	public void OnExit() {
		infoParent.SetActive(false);
	}
}