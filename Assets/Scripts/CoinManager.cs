using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CoinManager : Singleton<CoinManager>
{
    Dictionary<Coin.CoinTypes, Coin> coinsDictionary = new();
    [SerializeField] List<Coin> coinsList = null;

    [SerializeField, Range(0, 100)] int coinsNumber = 50;
    [SerializeField, Range(0, 100)] int RedCoinPercentChance = 10;

    public int CoinsNumber => coinsNumber;

    [SerializeField] Transform point = null;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Coin _coin in coinsList)
        {
            coinsDictionary.Add(_coin.CoinType, _coin);
        }
        PlaceCoinsInWorld();
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

    void PlaceCoinsInWorld()
    {
        for (int i = 0; i < coinsNumber; i++)
        {
            Coin _coin = GetRandomCoin();
            Vector3 _coinPos = RandomPointOnPlatform();
            Instantiate(_coin, new Vector3(_coinPos.x, _coinPos.y + _coin.Height, _coinPos.z), Quaternion.identity);
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

    Vector3 RandomPointOnPlatform()
    {
        Vector3[] _platformSize = PlatformManager.Instance.GetRandomPlatform();
        Debug.Log($"{_platformSize[0]} {_platformSize[1]}");
        Vector3 _result = Vector3.zero;
        if (_platformSize.Length < 2) return Vector3.zero;
        _result.x = UnityEngine.Random.Range(_platformSize[0].x, _platformSize[1].x);
        _result.y = _platformSize[0].y + .5f;
        _result.z = UnityEngine.Random.Range(_platformSize[0].z, _platformSize[1].z);
        return _result;
    }
}
