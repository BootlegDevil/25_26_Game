using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isGrounded;
    public void Start()
    {
        GetComponent <BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}
