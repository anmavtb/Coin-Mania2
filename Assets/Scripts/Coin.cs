using UnityEngine;
using static Coin;
using static Unity.VisualScripting.Dependencies.Sqlite.SQLite3;

public class Coin : MonoBehaviour
{
    [SerializeField] CoinTypes coinType = CoinTypes.COIN;
    [SerializeField] int value = 1;
    [SerializeField] float rotationSpeed = 150;

    public enum CoinTypes
    {
        COIN,
        RED_COIN
    };

    public CoinTypes CoinType => coinType;
    public int Value => value;

    // Start is called before the first frame update
    void Start()
    {
        switch (coinType)
        {
            case CoinTypes.COIN:
                value = 1;
                break;
            case CoinTypes.RED_COIN:
                value = 5;
                break;
            default:
                value = 1;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
    }

    void Rotate()
    {
        transform.eulerAngles += transform.up * Time.deltaTime * rotationSpeed;
    }
}
