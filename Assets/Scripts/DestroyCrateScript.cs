using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCrateScript : MonoBehaviour {
    private Animator anim;
    // Start is called before the first frame update
    void Start() {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Crate" || collision.gameObject.tag == "Door") {
            //Destroy(collision.gameObject);
            Debug.Log("BRUH");
            anim.SetBool("bonking", true);

            collision.gameObject.SetActive(false);
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Crate" || collision.gameObject.tag == "Door") {
            //Destroy(collision.gameObject);
            anim.SetBool("bonking", false);
        }
    }
}
