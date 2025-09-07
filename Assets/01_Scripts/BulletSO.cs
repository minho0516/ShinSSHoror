using UnityEngine;

[CreateAssetMenu(fileName = "Bullet_", menuName = "SO/Bullet")]
public class BulletSO : ScriptableObject
{
    public string BulletName;
    public float Speed;
    public int Damage;
}
