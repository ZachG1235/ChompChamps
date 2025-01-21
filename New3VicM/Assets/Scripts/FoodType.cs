using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodType : MonoBehaviour
{
    public GameObject scriptHolder;

    public struct FOOD
    {
        public int foodDifficulty;
    }

    static public FOOD foodStat;

    private void Awake()
    {
        DontDestroyOnLoad(scriptHolder);
    }
}
