using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    private LevelManager myScript;
    public bool Spawn = false;
    void Awake()
    {
        myScript = gameObject.GetComponent<LevelManager>();

    }
    // void Start()
    // {
    //     myScript = gameObject.GetComponent<LevelManager>();
    // }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            myScript.Spawn = true;

            // other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(10, 10, 0));
        }
    }
}
