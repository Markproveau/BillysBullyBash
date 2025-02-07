using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Enemy
{
    public string enemyName;
    public int cool;
    public int strength;
    public int wit;
    public int hp = 0;
    public int hPThresh;
    public int attackStrength;

    public bool takeDamage(int cool, int strength, int wit)
    {
        hp += (cool - this.cool) + (strength - this.strength) + (wit - this.wit);
        if (hp > hPThresh) return true;
        return false;
    }

    public int attack()
    {
        return attackStrength;
    }

}
