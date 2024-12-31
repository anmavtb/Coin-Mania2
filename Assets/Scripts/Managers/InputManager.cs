using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : Singleton<InputManager>
{
    [SerializeField] Controls controls = null;
    [SerializeField] InputAction move = null;
    [SerializeField] InputAction rotate = null;
    [SerializeField] InputAction jump = null;

    public InputAction Move => move;
    public InputAction Rotate => rotate;
    public InputAction Jump => jump;

    [SerializeField] MovementComponent moveComponent = null;

    protected override void Awake()
    {
        base.Awake();
        controls = new();
    }

    private void OnEnable()
    {
        move = controls.Character.Move;
        move.Enable();

        rotate = controls.Character.Rotate;
        rotate.Enable();

        jump = controls.Character.Jump;
        jump.Enable();
        jump.performed += moveComponent.Jump;
    }

    private void OnDisable()
    {
        move.Disable();
        rotate.Disable();
        jump.Disable();
    }
}