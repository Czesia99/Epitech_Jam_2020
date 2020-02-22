using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    // public void onSpawn(Vector3 position)
    // {
    //     Instantiate(ballPrefab).transform.position = position;
    // }
    void Start()
    {
        // rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            Debug.Log("TESSST");
            // other.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(10, 10, 0));
        }
    }
}
