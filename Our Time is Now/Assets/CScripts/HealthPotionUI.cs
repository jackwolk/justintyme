using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthPotionUI : MonoBehaviour
{
    public Data data;
    public TextMeshProUGUI text;
    public int healthPotions = 0;

    public void SetStartingCoins(int startingcoins)
    {
        healthPotions = startingcoins;
    }

    public void addCoins(int amount)
    {
        healthPotions += amount;
    }

    public void displayCoins()
    {
        text.text = healthPotions.ToString();
    }

    private void Update()
    {
        displayCoins();
    }

    private void OnDestroy()
    {
        data.healthPotions = healthPotions;
    }

    private void Start()
    {
        data = GameObject.Find("Data").GetComponent<Data>();

        SetStartingCoins(data.healthPotions);
    }

}
