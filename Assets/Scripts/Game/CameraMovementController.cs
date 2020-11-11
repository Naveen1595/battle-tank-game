using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    [SerializeField] GameObject player;
    private void Start()
    {
        
    }
    private void Update()
    {
        Vector3 pos = new Vector3(player.transform.position.x, gameObject.transform.position.y, player.transform.position.z);
        gameObject.transform.position = pos;
    }
}
