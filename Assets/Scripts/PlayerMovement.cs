using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    //Setting paramaters
    private GameObject go;
    private GameObject bg;


    Vector3 force;
    Rigidbody rigi;
    public float speed;
    public float mouseSpeed;
    public float topSpeed;
    public float jumpPower;
    bool canJump;

    [SerializeField] private AudioSource jumpSoundEffect;
    //[SerializeField] private AudioSource landSoundEffect;
    [SerializeField] private AudioSource collectSoundEffect;

    //On start set paramaters and get objects
    void Start()
    {
        rigi = GetComponent<Rigidbody>();
        go = GameObject.Find("Game Over");
        bg = GameObject.Find("BG Music");
        go.SetActive(false);
    }

    //Testing game is playing and initalising change of music played then restart level
    //Get force
    //Jump paramaters once "Space" is get key down
    void Update()
    {
        if (!GameManager.playing)
        {
            bg.SetActive(false);
            go.SetActive(true);
            Invoke("RestartLevel", 4f);

            //return;
        }

        force.x = Input.GetAxis("Horizontal");
        force.z = Input.GetAxis("Vertical");
        force *= speed;

        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            jumpSoundEffect.Play();

            canJump = false;

            Vector3 temp = rigi.velocity;
            temp.y = 0;
            rigi.velocity = temp;

            rigi.AddForce(Vector3.up * jumpPower);
        }

        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * mouseSpeed);

    }
    //Once game over initalising restart level
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //Playing test, if not playing initilasing game over
    //Testing force applied
    private void FixedUpdate()
    {
        if (!GameManager.playing)
        {
            rigi.isKinematic = true;
            return;
        }

        rigi.AddRelativeForce(force);
        if (rigi.velocity.magnitude > topSpeed)
        {
            rigi.velocity = rigi.velocity.normalized * topSpeed;
        }
        // topSpeed = rigi.velocity.magnitude;
    }


    //Testing player on collision to floor
    //Proposed landing sound effect
    private void OnCollisionEnter(Collision collision)
    {
        foreach (ContactPoint x in collision.contacts)
        {
            if (x.point.y < transform.position.y - 0.1f)
            {
                //landSoundEffect.Play();
                canJump = true;
            }
        }
    }


    //Collectables & proposed collectbles
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Jump")
        {
            Destroy(other.gameObject);
            collectSoundEffect.Play();
        }

        if (other.tag == "Jump")
        {
            canJump = true;
        }

        if (other.tag == "ScoreUp")
        {
            GameManager.score += 100;
        }

        if (other.tag == "TimeUp")
        {
            GameManager.currentTimer += 5;
        }

        if (other.tag == "ScoreDown")
        {
            GameManager.score -= 500;
        }

        if (other.tag == "TimeDown")
        {
            GameManager.currentTimer -= 10;
        }
    }


}
