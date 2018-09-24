using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyStrats : ScriptableObject
{
	public string myName;
	public int health;
	public float speed;
	public int attackDamage;
	public int attackCooldown;

}
