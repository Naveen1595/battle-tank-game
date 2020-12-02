using UnityEngine;

public class TankMove : MonoBehaviour
{
    [SerializeField] Joystick joystick;
    private Rigidbody rb3d;
    private string m_moveTankName;
    private string m_turnTankName;
    private float moveTankValue;
    private float turnTankValue;
    private float speed = 5f;
    private void Start()
    {
        rb3d = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        moveTankValue = joystick.Vertical;
        turnTankValue = joystick.Horizontal;
    }
    private void FixedUpdate()
    {
        move();
        turn();
    }

    private void move()
    {
        Vector3 movement = transform.forward * moveTankValue * speed * Time.deltaTime;
        rb3d.MovePosition(rb3d.position + movement);
    }

    private void turn()
    {
        float turn = turnTankValue * 100f * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb3d.MoveRotation(rb3d.rotation * turnRotation);
    }
}
