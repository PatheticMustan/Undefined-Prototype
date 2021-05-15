using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleScript : MonoBehaviour {
    public string sceneName = "Test_Level_1";
    public float transitiontime = 1f;
    public Animator Levelload;
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }


    IEnumerator LoadLevel(int LevelIndex) 
     {
        

        yield return new WaitForSeconds(transitiontime);

         SceneManager.LoadScene(LevelIndex);
    }
}
