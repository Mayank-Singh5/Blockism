using UnityEngine;
using UnityEngine.SceneManagement;
public class player_movement : MonoBehaviour
{
    private float x;
    private float side_force = 800f;
    private float force = 1000f;
    private Rigidbody rb;
    private float min_y = -8f;
    private float restart_time = 2f;

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Next()
    {
        // Invoke("self", restart_time);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (transform.position.y < min_y)
        {
            Restart();
        }
    }
    void FixedUpdate()
    {
        rb.AddForce(0, 0, force * Time.fixedDeltaTime,ForceMode.Force);
        x = Input.GetAxis("Horizontal");
        rb.AddForce(x * side_force * Time.fixedDeltaTime, 0, 0,ForceMode.Force);        
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Obstacle")
        {
            this.enabled = false;
            Invoke("Restart",restart_time);
        }
    }
}