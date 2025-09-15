using UnityEngine;

public class HpCore : MonoBehaviour
{
    public float maxHp;
    public float hp;
    public bool died = false;

    public virtual void Damage(float damage)
    {
        if (isHpSmallThenZero(damage))
            Die();
        else
            hp -= damage;
        hp = hp > maxHp ? maxHp : hp;
    }

    public virtual void Die()
    {

    }


    #region ºñ±³½Ä
    public virtual bool isHpSmallThenZero(float damage)
    {
        return hp - damage <= 0 ? true : false;
    }
    #endregion
}
