using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnerTrigger : MonoBehaviour
{
    public GameObject myScript;
    void Awake()
    {
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            GameObject JunkInstance;
    
            JunkInstance = Instantiate(myScript);
            if (!JunkInstance.GetComponent<mySpawner>().isActive())
                JunkInstance.GetComponent<mySpawner>().setActive(true);

        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.tag == "Player") {
            int childs = transform.childCount;
            for (int i = childs - 1; i > 0; i--)
            {
                transform.GetChild(i).gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            }
        }
    }
}
