using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] List<Coin> coinsList = new();

    public List<Coin> CoinsList => coinsList;

    // Start is called before the first frame update
    void Start()
    {
        coinsList = FindObjectsOfType<Coin>().ToList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RemoveItem(Coin _coin)
    {
        coinsList.Remove(_coin);
    }
}
