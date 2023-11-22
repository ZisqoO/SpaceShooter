using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy Type", menuName = "Enemy")]
public class Enemy_Type : ScriptableObject
{
    public GameObject enemyPrefab;
    public GameObject bulletPrefab;
    public GameObject explosionPrefab;
    public int health;
    public int damage;
    public int enemyTypeNo;
    public int scorePoint;
    public float barFillAmount;
    
}
