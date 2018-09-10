﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tower", menuName = "Tower")]
public class TowerStat : ScriptableObject
{
    public string myName;
    public int cost;
    public float range;
    public int damage;
    public float fireRate;

}
