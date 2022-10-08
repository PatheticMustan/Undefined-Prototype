using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour {
    void Start() {
        Cursor.visible = true;
    }

    void Update() {

    }
    public void OnClick() {
        Cursor.visible = false;
        SceneManager.LoadScene("Test_Level_1");
    }
}