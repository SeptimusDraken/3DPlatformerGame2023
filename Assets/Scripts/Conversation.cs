using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

//Meant to be called Finish sequence
public class Conversation : MonoBehaviour
{

    //Setting paramaters
    [SerializeField] private AudioSource finishSound;

    public GameObject cam;

    private bool levelCompleted = false;

    //On start set paramaters and get objects
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
        cam = GameObject.Find("EndCamera");
        cam.SetActive(false);
    }

    //On collision to finish level after 4 game seconds.
    //Set active camera true to not lose the character.
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player" )
        {
            finishSound.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 4f);
            Debug.Log("Finished");
            Destroy(collision.gameObject);
            cam.SetActive(true);
        }
    }


    //change scene once game object has been collided 
    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
