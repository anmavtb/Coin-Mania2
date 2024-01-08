using UnityEngine;
//using UnityEngine.InputSystem;

public class MovementComponent : MonoBehaviour
{
    [SerializeField] Player owner = null;

    [SerializeField] float moveSpeed = 10;
    [SerializeField] float rotateSpeed = 100;
    [SerializeField] public float jumpHeight = 5;

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
    }

    public void Init(Player _owner)
    {
        owner = _owner;
    }

    void Move()
    {
        if (!owner) return;
        Vector2 _movementValue = owner.Move.ReadValue<Vector2>();
        transform.position += transform.forward * _movementValue.y * Time.deltaTime * moveSpeed;
        transform.position += transform.right * _movementValue.x * Time.deltaTime * moveSpeed;
    }

    void Rotate()
    {
        if (!owner) return;
        float _rotValue = owner.Rotate.ReadValue<float>();
        transform.eulerAngles += transform.up * _rotValue * Time.deltaTime * rotateSpeed;
    }

    //void Jump(InputAction.CallbackContext _context)
    //{
    //    transform.position += new Vector3(0, jumpHeight, 0);
    //}
}
