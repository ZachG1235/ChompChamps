using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    public GameObject userInterfaceButtons;
    public GameObject userInterface;

    public GameObject playerHPText;
    public GameObject enemyHPText;

    public struct EnemyStats
    {
        public int damage;
        public int defense;
        public int critConstant;
        public int maxHealth;
    }

    public EnemyStats enemyStats;

    public void InitEnemyStats(int difficulty)
    {
        enemyStats.damage = (int)(3 + (1.5f * difficulty));
        enemyStats.defense = (int)(0 + difficulty);
        enemyStats.critConstant = (int)(10 - difficulty);
        enemyStats.maxHealth = (int)(20 + (5.5f * difficulty));
        UpdateEnemyHealthText();
    }

    public void Awake()
    {
        // DEBUG
            // comment out this line when starting at BattleScene
        // InitEnemyStats(FoodType.foodStat.foodDifficulty);

            // comment out this line when starting at LobbyScene
        InitEnemyStats(1);


        UpdatePlayerHealthText();
    }


    // BATTLE FUNCTIONS -----------------------------
    // =================================
    public int GetDamageWithDefense(int inputDamage, int inputDefense)
    {
        int tempVal = inputDamage - inputDefense;
        if (tempVal < 2)
        {
            return 1;
        }
        return tempVal;
    }

    // function uses the crit constant and returns the damage,
    // if crit, damage is doubled
    public int GetDamageWithCritChance(int inputDamage, int inputCrit)
    {
        int tempVal = Random.Range(0, inputCrit);
        if (tempVal == inputCrit - 1)
        {
            Debug.Log("Critical Strike Occured.");
            return 2 * inputDamage;
        }
        return inputDamage;
    }

    public void UpdatePlayerHealthText()
    {
        playerHPText.GetComponent<TMPro.TextMeshProUGUI>().text = "Player HP: " + PlayerSettings.stats.maxHealth.ToString();
    }
    public void UpdateEnemyHealthText()
    {
        enemyHPText.GetComponent<TMPro.TextMeshProUGUI>().text = "Enemy HP: " + enemyStats.maxHealth.ToString();
    }


    public void LoadPictureScene()
    {
        SceneManager.LoadScene("CameraScreen");
    }

    public void AttackClicked()
    {
        userInterfaceButtons.SetActive(false);
        StartCoroutine(Attack(1));
    }

    public void SpecialClicked()
    {
        userInterfaceButtons.SetActive(false);
        StartCoroutine(Attack(2));
    }

    public void ItemsClicked()
    {
        userInterfaceButtons.SetActive(false);
        StartCoroutine(Attack(3));
    }




    IEnumerator Attack(int choice)
    {
        yield return new WaitForSeconds(1);

        // attack
        if (choice == 1)
        {
            int playerDamageDealt = (int)Random.Range((float)PlayerSettings.stats.damage * 0.95f, (float)PlayerSettings.stats.damage * 1.05f);
            playerDamageDealt = GetDamageWithCritChance(playerDamageDealt, PlayerSettings.stats.critConstant);
            DealDamageToEnemy(playerDamageDealt);
        }
        // special
        else if (choice == 2)
        {
            int playerDamageDealt = (int)Random.Range((float)PlayerSettings.stats.damage * 0.90f, (float)PlayerSettings.stats.damage * 1.1f);
            playerDamageDealt = GetDamageWithCritChance(playerDamageDealt, PlayerSettings.stats.critConstant);

            playerDamageDealt = (int)(playerDamageDealt * 1.5f);

            DealDamageToEnemy(playerDamageDealt);
        }
        // items
        else
        {
            // use an item
        }



        yield return new WaitForSeconds(2);
        // check if enemy is dead
        if (enemyStats.maxHealth <= 0)
        {
            userInterfaceButtons.SetActive(true);
            userInterface.SetActive(false);
            PlayerWon();
            yield break;
        }



        // enemy's turn
        int enemyChoice = (int)Random.Range(0, 3);

        // enemy chooses attack
        if (enemyChoice == 1)
        {
            int enemyDamageDealt = (int)Random.Range((float)enemyStats.damage * 0.95f, (float)enemyStats.damage * 1.05f);
            enemyDamageDealt = GetDamageWithCritChance(enemyDamageDealt, enemyStats.critConstant);

            DealDamageToPlayer(enemyDamageDealt);
        }
        // enemy chooses special
        else if (enemyChoice == 2)
        {
            // do special moves
            int enemyDamageDealt = (int)Random.Range((float)enemyStats.damage * 0.90f, (float)enemyStats.damage * 1.1f);
            enemyDamageDealt = GetDamageWithCritChance(enemyDamageDealt, enemyStats.critConstant);

            enemyDamageDealt = (int)(enemyDamageDealt * 1.5f);

            DealDamageToPlayer(enemyDamageDealt);
        }
        // enemy chooses item
        else
        {
             // do item moves
        }



        yield return new WaitForSeconds(1);
        // check if player is dead
        if (PlayerSettings.stats.maxHealth <= 0)
        {
            userInterfaceButtons.SetActive(true);
            userInterface.SetActive(false);
            PlayerLost();
            yield break;
        }


        // re-enable user choices
        userInterfaceButtons.SetActive(true);
    }


    public void DealDamageToEnemy(int damage)
    {
        // display to user that they dealt the damage to the enemy
        // not implmented
        Debug.Log("Player dealt: " + damage + " damage");

        enemyStats.maxHealth -= GetDamageWithDefense(damage, enemyStats.defense);

        UpdateEnemyHealthText();
    }

    public void DealDamageToPlayer(int damage)
    {
        // display to user that they were dealt damage
        // not implmented
        Debug.Log("Enemy dealt: " + damage + " damage");

        PlayerSettings.stats.maxHealth -= GetDamageWithDefense(damage, PlayerSettings.stats.defense);

        UpdatePlayerHealthText();
    }







    public void PlayerWon()
    {
        // implementation here
        SceneManager.LoadScene("LobbyScene");

    }

    public void PlayerLost()
    {
        // implementation here
        SceneManager.LoadScene("LobbyScene");

    }


}
