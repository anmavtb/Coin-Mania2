using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(AudioSource))]

public class Player : MonoBehaviour
{
    [SerializeField] MovementComponent movement = null;
    [SerializeField] Controls controls = null;
    [SerializeField] AudioSource audioData;

    [SerializeField] InputAction move = null;
    [SerializeField] InputAction rotate = null;
    //[SerializeField] InputAction jump = null;

    [SerializeField] int score = 0;

    public int Score => score;

    public InputAction Move => move;
    public InputAction Rotate => rotate;
    //public InputAction Jump => jump;

    private void Awake()
    {
        controls = new Controls();
    }

    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnEnable()
    {
        move = controls.Character.Move;
        move.Enable();
        rotate = controls.Character.Rotate;
        rotate.Enable();
        //jump = controls.Character.Jump;
        //jump.Enable();
        //jump.performed += Jump;
    }

    void Init()
    {
        score = 0;
        movement = GetComponent<MovementComponent>();
        if (!movement) return;
        movement.Init(this);
        audioData = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider _other)
    {
        Coin _coin = _other.gameObject.GetComponent<Coin>();
        if (!_coin) return;
        UpdateScore(_coin.Value);
        audioData.Play();
        Destroy(_coin.gameObject);
    }

    void UpdateScore(int _CoinValue)
    {
        score += _CoinValue;
    }
}
