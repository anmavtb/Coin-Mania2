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

    [SerializeField, Range(0, 10)] float minDistAllowedFromPlayer = 0;
    
    Vector3 playerSpawnPoint = Vector3.zero;

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
        Debug.Log("Left : " + coinsNumber);
        if (coinsNumber <= 0)
        {
            EndGame.Instance.GameEnd();
        }
    }

    void PlaceCoinsInWorld()
    {
        // Fetch all platforms
        Transform[] platforms = PlatformManager.Instance.GetAllPlatforms();
        List<Vector3> precomputedPositions = new();

        // Precompute valid positions for each platform
        foreach (Transform platform in platforms)
        {
            Vector3[] platformCorners = PlatformManager.Instance.GetPlatformCorners(platform);

            if (platformCorners.Length < 2) continue;

            for (int i = 0; i < coinsNumber / platforms.Length; i++) // Spread coins evenly
            {
                Vector3 randomPosition = GenerateValidPosition(platformCorners);

                if (IsFarFromPlayer(randomPosition))
                {
                    precomputedPositions.Add(randomPosition);
                }
            }
        }

        // Place coins in precomputed positions
        foreach (Vector3 position in precomputedPositions)
        {
            Coin _coin = GetRandomCoin();
            Instantiate(_coin, new Vector3(position.x, position.y + _coin.Height, position.z), Quaternion.identity, parent);
        }
    }

    Vector3 GenerateValidPosition(Vector3[] platformCorners)
    {
        return new Vector3(
            UnityEngine.Random.Range(platformCorners[0].x, platformCorners[1].x),
            platformCorners[0].y + 0.5f,
            UnityEngine.Random.Range(platformCorners[0].z, platformCorners[1].z)
        );
    }

    bool IsFarFromPlayer(Vector3 position)
    {
        return Vector3.Distance(position, playerSpawnPoint) > minDistAllowedFromPlayer;
    }

    /// <summary>
    /// Choose a random coin from the dictionnary and send it back.
    /// </summary>
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