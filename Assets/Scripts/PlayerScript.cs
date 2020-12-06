using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    public float speed;
    private int totalGems;
    private int gemsPicked;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        totalGems += GameObject.FindGameObjectsWithTag("PickUp").Length;
        totalGems += GameObject.FindGameObjectsWithTag("PickUpBlue").Length;
    }

    private void Update()
    {
        speed = rb.velocity.magnitude;

        if (rb.position.y < 0f)
        {
            //Debug.Log("OffScreen");
            AudioManager.Instance.StopBallRoll();
            GameManager.Instance.Restart();
        }
    }

    void OnCollisionStay(Collision collision)
    {

        if (!AudioManager.Instance.isBallRoll() && speed >= 0.3f && collision.gameObject.tag == "Floor") {
            AudioManager.Instance.PlayBallRoll();
        }
        else if (AudioManager.Instance.isBallRoll() && speed < 0.3f && collision.gameObject.tag == "Floor") {
            AudioManager.Instance.StopBallRoll();
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (AudioManager.Instance.isBallRoll() && collision.gameObject.tag != "Floor")
        {
            Debug.Log("Not in floor");
            AudioManager.Instance.StopBallRoll();
        }
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("PickUp"))
        {
            AudioManager.Instance.PlayYellowGem();
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("PickUpBlue"))
        {
            AudioManager.Instance.PlayBlueGem();
            other.gameObject.SetActive(false);
        }

        if (++gemsPicked == totalGems)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //if (SceneManager.GetActiveScene().name != "mazelevel2") {

            //} else {
            //    SceneManager.LoadScene("endscene");
            //}
        }
    }
}