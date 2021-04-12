using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipMovement : MonoBehaviour
{
    [Header("Set in Inspector: Enemy")]
    public float speed = 10f; // The speed in m/s
    public float delay = 10;
    public string NewLevel = "End";
    public GameObject player;

    private bool active = false;
    void Start()
    {
        StartCoroutine(LoadLevelAfterDelay(delay));

    }
    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
        SceneManager.LoadScene(NewLevel);
    }


    //This is a Property: A method that acts like a field
    public Vector3 pos
    {
        get
        {
            return (this.transform.position);
        }
        set
        {
            this.transform.position = value;
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (active == true)
        {
            Move();
        }
    }
    //Enemy_1 Movement
    public virtual void Move()
    {
        Vector3 tempPos = pos;
        tempPos.y += speed * Time.deltaTime;
        pos = tempPos;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            player.SetActive(false);
            active = true;
        }

    }

}

