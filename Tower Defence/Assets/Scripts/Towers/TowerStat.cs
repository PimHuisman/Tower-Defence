using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Tower", menuName = "Tower")]
public class TowerStat : ScriptableObject
{
    public string myName;
    public Sprite mySprite;
    public int cost;
    public float range;
    public int force;
    public float angle;
    public int damage;
    public float fireRate;
    public float projectileRespawnPercentage;

    [Header("Objects")]
    public GameObject tower;
    public GameObject ammo;

}
