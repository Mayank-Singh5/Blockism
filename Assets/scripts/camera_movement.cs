using UnityEngine;

public class camera_movement : MonoBehaviour
{
    private Transform player_transform;
    private Vector3 pos = new Vector3(0,2,-6);
    void Update()
    {
        GameObject player = GameObject.Find("Player");
        player_transform = player.transform;
        transform.position = player_transform.position + pos;
    }
}