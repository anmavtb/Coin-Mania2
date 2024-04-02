using System;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : Singleton<CoinManager>
{
    Dictionary<Coin.CoinTypes, Coin> coinsDictionary = new();
    [SerializeField] List<Coin> coinsList = null;

    [SerializeField, Range(0, 999)] int coinsNumber = 50;
    [SerializeField, Range(0, 100)] int RedCoinPercentChance = 10;

    [SerializeField] Transform parent = null;

    Vector3 playerSpawnPoint = Vector3.zero;
    [SerializeField, Range(0, 10)] float minDistAllowed = 0;

    public int CoinsNumber => coinsNumber;

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
            Vector3 _coinPos = RandomPointOnPlatform(PlatformManager.Instance.GetRandomPlatform());
            Instantiate(_coin, new Vector3(_coinPos.x, _coinPos.y + _coin.Height, _coinPos.z), Quaternion.identity, parent);
        }
    }

    /// <summary>
    /// Chose a random coin from the dictionnary and sent it back.
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// Chose a random point on top of the given platform and sent this point back.
    /// If this point is too close from the player spawn point (0,0,0) : call itself again to choose another point.
    /// </summary>
    /// <param name="_platformSize">The two corners of the given platform</param>
    /// <returns></returns>
    Vector3 RandomPointOnPlatform(Vector3[] _platformSize)
    {
        Vector3 _result = Vector3.zero;
        if (_platformSize.Length < 2) return Vector3.zero;
        _result.x = UnityEngine.Random.Range(_platformSize[0].x, _platformSize[1].x);
        _result.y = _platformSize[0].y + .5f;
        _result.z = UnityEngine.Random.Range(_platformSize[0].z, _platformSize[1].z);
        return _result;
    }
}