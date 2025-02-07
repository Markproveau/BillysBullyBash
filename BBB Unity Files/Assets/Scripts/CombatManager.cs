using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text textBox;

    [SerializeField]
    Image panelImage;

    List<Enemy> enemies;

    private float colorChangeSpeed = 0.5f;

    int billyAttack = 15;
    bool billyTurn = true;
    int billyHP = 0;

    // Start is called before the first frame update
    void Start()
    {
        enemies = CombatValues.enemies;
        
    }

    // Update is called once per frame
    void Update()
    {
        Color newColor = new Color(
         Mathf.PingPong(Time.time * colorChangeSpeed, 1),  // R
         Mathf.PingPong(Time.time * colorChangeSpeed * 0.8f, 1),  // G
         Mathf.PingPong(Time.time * colorChangeSpeed * 0.6f, 1)   // B
         );
        panelImage.color = newColor;

        displayCombatData();
        System.Threading.Thread.Sleep(1000);
        bool enemiesAlive = false;
        foreach (Enemy enemy in enemies)
        {
            if (enemy != null && enemy.hp <= enemy.hPThresh)
            {
                enemiesAlive = true;
                break;
            }
        }
        if (enemiesAlive) takeTurn();
    }

    void display(string text) { 
        textBox.text = text;
    }

    void displayCombatData()
    {
        string text = "Billy HP: " + billyHP + "\n";
        for (int i = 0; i < enemies.Count; i++)
        {
            text += "Enemy " + (i + 1) + ": " + enemies[i].enemyName;
            text += "\nCool: " + enemies[i].cool;
            text += "\nStrength: " + enemies[i].strength;
            text += "\nWit: " + enemies[i].wit;
            text += "\nHumiliation Point Threshold: " + enemies[i].hPThresh;
            text += "\nHP: " + enemies[i].hp;
            text += "\n\n";
        }
        display(text);
    }

    void takeTurn()
    {
        if (billyTurn)
        {
            //player chooses what to do
            int playerChoice = Random.Range(0, enemies.Count);
            int coolDamage = Random.Range(0, 2) * billyAttack;
            int strengthDamage = Random.Range(0, 2) * billyAttack;
            int witDamage = Random.Range(0, 2) * billyAttack;
            enemies[playerChoice].takeDamage(coolDamage, strengthDamage, witDamage);
            System.Console.WriteLine("Billy did: " + coolDamage + " Cool Damage, " + strengthDamage + " Strength Damage, " + witDamage + " Wit Damage\n " +
                "For a total of " + (coolDamage - enemies[playerChoice].cool + strengthDamage - enemies[playerChoice].strength + witDamage - enemies[playerChoice].wit)  +
                "after defenses to: " + enemies[playerChoice].enemyName); 


        }
        else
        {
            foreach (Enemy enemy in enemies)
            {
                if (enemy != null)
                {
                    billyHP += enemy.attack();
                    System.Console.WriteLine(enemy.enemyName + ": did " + enemy.attackStrength + " Damage");
                }
            }
        }

        billyTurn = !billyTurn;
    }
}
