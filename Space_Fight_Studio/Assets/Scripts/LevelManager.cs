using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public GameObject[] myGameobject;
    public bool onInstantiateStart = false;
    public float Duration;
    private float _duration = 0;
    public bool Trigger = false;
    private bool Active = false;
    public float spawnTime;
    public float spawnDelay;
    /// <summary>
    /// Change Properties of Objects Generated
    ///
    /// </summary>
    public Vector2 spawnForce;
    public bool incrementX;
    public float incrementXBy = 10;
    public bool incrementY;
    public float incrementYBy = 10;
    public float gravityScale = 1f;
    public Transform position;
    // Start is called before the first frame update
    // void Start()
    // {
        
    // }
    void Awake()
    {
        if (onInstantiateStart)
            setActive(true);
    }
    public bool isActive()
    {
        return (Active);
    }
    public void setActive(bool active)
    {
        if (active && !isActive()) {
            Active = active;
            InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
        }
        else if (!active) {
            Active = active;
        }

    }
    public void SpawnObject() {
        float arrayLen = myGameobject.Length;
        int i = (int)Random.Range(0f, arrayLen);
        GameObject JunkInstance;
    
        JunkInstance = Instantiate(myGameobject[i]);
        JunkInstance.transform.SetParent(position, false);
        // JunkInstance.transform = position;
        JunkInstance.GetComponent<Rigidbody2D>().gravityScale = gravityScale;
        JunkInstance.GetComponent<Rigidbody2D>().AddForce(spawnForce);
        if (incrementX && Mathf.Abs(spawnForce.x) <= 1000)
            spawnForce.x += incrementXBy;
        if (incrementY &&  Mathf.Abs(spawnForce.y) <= 1000)
            spawnForce.y += incrementYBy;
        if (!isActive())
            CancelInvoke("SpawnObject");
    }
    // Update is called once per frame
    void Update()
    {
        if (Trigger) {
            setActive(true);
            Trigger = false;
        }
        if (isActive()) {
            Duration -= Time.deltaTime;
            if (Duration <= 0) {
                setActive(false);
                Duration = _duration;
            }
        }
    }
}
