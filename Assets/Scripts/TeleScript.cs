using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleScript : MonoBehaviour {
    public string sceneName = "Test_Level_1";
    public float transitiontime = 1f;
    public Animator Levelload;
    public bool TransitionAlive;
    public GameObject Transition; 
    void Start() {

        Transition.SetActive(false);
        TransitionAlive = false;
    }

    // Update is called once per frame
    void Update() {
        if (TransitionAlive == true) 
        {

            Transition.SetActive(true);

        }

    }

    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }


    IEnumerator LoadLevel(int LevelIndex) 
     {
        TransitionAlive = true;

        Levelload.SetTrigger("Start");

        yield return new WaitForSeconds(transitiontime);

         SceneManager.LoadScene(LevelIndex);
    }
}
