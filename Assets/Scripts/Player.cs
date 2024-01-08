using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] MovementComponent movement = null;
    [SerializeField] Controls controls = null;

    [SerializeField] InputAction move = null;
    [SerializeField] InputAction rotate = null;
    //[SerializeField] InputAction jump = null;

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
        movement = GetComponent<MovementComponent>();
        if (!movement) return;
        movement.Init(this);
    }
}
