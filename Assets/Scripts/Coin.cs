using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] int value = 1;
    [SerializeField] float rotationSpeed = 150;

    public int Value => value;

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
