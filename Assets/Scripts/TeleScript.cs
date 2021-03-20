using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleScript : MonoBehaviour {
    public string sceneName = "Test_Level_1";

    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            SceneManager.LoadScene(sceneName);
        }
    }
}
