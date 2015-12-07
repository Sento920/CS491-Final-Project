using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {

    public GameObject Master;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (CompareTag("Player"))
        {
            //Add score.
            Destroy(this.gameObject);
        }
    }
}
