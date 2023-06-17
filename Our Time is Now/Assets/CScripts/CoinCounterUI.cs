using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinCounterUI : MonoBehaviour
{
    public Data data;
    public TextMeshProUGUI text;
    public int coins;
    public void SetStartingCoins(int startingcoins)
    {
        coins = startingcoins;
    }

    public void addCoins(int amount)
    {
        coins += amount;
    }

    public void displayCoins()
    {
        text.text = coins.ToString();
    }


        private void OnDestroy()
        {
            data.coins = coins;
        }

    private void Start()
    {
        data = GameObject.Find("Data").GetComponent<Data>();

        SetStartingCoins(data.coins);
    }

}
