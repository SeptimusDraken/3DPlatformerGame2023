using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Conversation : MonoBehaviour
{
    [SerializeField] private AudioSource finishSound;

    public GameObject cam;

    private bool levelCompleted = false;

    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
        cam = GameObject.Find("EndCamera");
        cam.SetActive(false);
    }

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

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
