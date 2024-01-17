using System;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : Singleton<CoinManager>
{
    Dictionary<Coin.CoinTypes, Coin> coinsDictionary = new();
    [SerializeField] List<Coin> coinsList = null;

    [SerializeField, Range(0, 100)] int coinsNumber = 50;
    [SerializeField, Range(0, 100)] int RedCoinPercentChance = 10;

    public int CoinsNumber => coinsNumber;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Coin _coin in coinsList)
        {
            coinsDictionary.Add(_coin.CoinType, _coin);
        }
        PlaceCoins();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RemoveCoin()
    {
        coinsNumber--;
        if (coinsNumber <= 0)
        {
            Debug.Log("Gagné");
        }
    }

    void PlaceCoins()
    {
        for (int i = 0; i < coinsNumber; i++)
        {
            Coin _coin = GetRandomCoin();
            Instantiate(_coin, new Vector3(5, 2, i), Quaternion.identity);
        }
    }

    Coin GetRandomCoin()
    {
        Coin _randomCoin = null;
        int _rand = UnityEngine.Random.Range(0, 100);
        if (_rand < RedCoinPercentChance)
            coinsDictionary.TryGetValue(Coin.CoinTypes.RED_COIN, out _randomCoin);
        else
            coinsDictionary.TryGetValue(Coin.CoinTypes.COIN, out _randomCoin);
        return _randomCoin;
    }
}
