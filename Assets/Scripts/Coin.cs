using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] CoinTypes coinType = CoinTypes.COIN;
    [SerializeField] int value = 1;
    [SerializeField] float height = 1;
    [SerializeField] float rotationSpeed = 150;

    public enum CoinTypes
    {
        COIN,
        RED_COIN
    };

    public CoinTypes CoinType => coinType;
    public int Value => value;
    public float Height => height;

    // Start is called before the first frame update
    void Start()
    {
        switch (coinType)
        {
            case CoinTypes.COIN:
                value = 1;
                height = 1;
                break;
            case CoinTypes.RED_COIN:
                value = 5;
                height = 1.5f;
                break;
            default:
                value = 0;
                height = 0;
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
