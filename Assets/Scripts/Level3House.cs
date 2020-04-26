using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level3House : MonoBehaviour
{
    BoxCollider2D boxCollider2D;


    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        other.GetComponent<PlayerMovement>().Die();

        Debug.Log("LoadingScne");
        SceneManager.LoadScene("END");
    }


}