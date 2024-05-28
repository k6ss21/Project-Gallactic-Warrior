using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    

    // Update is called once per frame
    void Update()
    {
        Invoke("Destroy", 1f);
    }

    void Destroy()
    {
        Destroy(this.gameObject);
    }
}
