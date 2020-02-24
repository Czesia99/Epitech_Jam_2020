using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mySpawn : MonoBehaviour
{
    public GameObject ballPrefab;

    public void onSpawn(Vector3 position)
    {
        GameObject JunkInstance;
        JunkInstance =  Instantiate(ballPrefab);
        JunkInstance.transform.position = position;
        JunkInstance.GetComponent<Rigidbody2D>().AddForce(new Vector2(10f * 100, 10f * 100));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono);
            Vector3 adjustZ = new Vector3(worldPoint.x, worldPoint.y, ballPrefab.transform.position.z);

            onSpawn(adjustZ);
        }
    }
}
