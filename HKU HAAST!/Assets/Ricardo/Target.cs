using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Perish()
    {
        Destroy(this.gameObject);
    }
}
