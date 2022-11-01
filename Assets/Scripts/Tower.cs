using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public bool installed;
    public bool grapped;
    public bool atStorage = true;

    // Start is called before the first frame update
    void Start()
    {
        installed = false;    
        grapped = false;    
        atStorage = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
