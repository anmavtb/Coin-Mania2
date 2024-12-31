using UnityEngine;
using TMPro;

public class Coin_Counter : Singleton<Coin_Counter>
{
    [SerializeField] TMP_Text counterTextUI;
    [SerializeField] string contentText = "Coins Left : ";

    [SerializeField, ReadOnly] int maxCoins;
    [SerializeField, ReadOnly] int actualCoins;

    // Start is called before the first frame update
    void Start()
    {
        maxCoins = actualCoins = CoinManager.Instance.CoinsNumber;
        UpdateCounter();
    }

    // Update is called once per frame
    void Update()
    {
        actualCoins = CoinManager.Instance.CoinsNumber;
        UpdateCounter();
    }

    void UpdateCounter()
    {
        counterTextUI.text = contentText + actualCoins + " / " + maxCoins;
    }
}