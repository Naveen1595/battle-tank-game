using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    [SerializeField] GameObject player;
    private void Update()
    {
        Vector3 playerPosition = new Vector3(player.transform.position.x, gameObject.transform.position.y, player.transform.position.z);
        gameObject.transform.position = playerPosition;
    }
}
