using UnityEngine;

[RequireComponent(typeof(AudioSource), typeof(MovementComponent))]

public class Player : Singleton<Player>
{
    MovementComponent movement = null;
    AudioSource audioData;

    [SerializeField] int score = 0;

    public int Score => score;

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Init()
    {
        score = 0;
        InputManager.Instance.enabled = true;
        movement = GetComponent<MovementComponent>();
        audioData = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider _other)
    {
        Coin _coin = _other.gameObject.GetComponent<Coin>();
        if (!_coin) return;
        UpdateScore(_coin.Value);
        audioData.Play();
        CoinManager.Instance.RemoveCoin();
        Destroy(_coin.gameObject);
    }

    void UpdateScore(int _CoinValue)
    {
        score += _CoinValue;
    }
}
