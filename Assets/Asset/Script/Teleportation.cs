using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public GameObject Player, TeleportTarget;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == ("Player"))
        {
            StartCoroutine(Teleport());
            Debug.Log("StartCoroutine(Teleport());");
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == ("Player"))
        {
            StopAllCoroutines();
            Debug.Log("StopCoroutine(Teleport());");
        }  
    }

    IEnumerator Teleport()
    {
        yield return waitForKeyPress(KeyCode.E);
        Player.transform.position = new Vector2 (TeleportTarget.transform.position.x, TeleportTarget.transform.position.y);

        //yield break;
    }

    private IEnumerator waitForKeyPress(KeyCode key)
    {
        bool done = false;
        while (!done) // essentially a "while true", but with a bool to break out naturally
        {
            if (Input.GetKeyDown(key))
            {
                done = true; // breaks the loop
            }
            yield return null; // wait until next frame, then continue execution from here (loop continues)
        }
    }
}