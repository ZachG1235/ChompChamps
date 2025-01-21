using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSettings : MonoBehaviour
{

    public struct PLAYERSTATS
    {
        public int damage;
        public int level;
        public int defense;
        public int critConstant;
        public int maxHealth;
    }

    static public PLAYERSTATS stats;

    private void Awake()
    {
        stats.damage = 3;
        stats.level = 1;
        stats.defense = 3;
        stats.critConstant = 10;
        stats.maxHealth = 30;
    }

    

}
