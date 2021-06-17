using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStats", menuName ="CreateEnemyStats", order = 1)]
public class EnemySOStatCreate : ScriptableObject
{
    public string enemyType;
    public float maxHealth;
    public float currenthealth;
    public float movespeed;
    public float damage;

}
