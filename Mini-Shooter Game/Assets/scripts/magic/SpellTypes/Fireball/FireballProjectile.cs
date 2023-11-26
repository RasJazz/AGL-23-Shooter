using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballProjectile : MonoBehaviour
{

    private float _timeAlive;
    public FireballSpell FireballSpell { private get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {
        _timeAlive += Time.deltaTime;
        if (_timeAlive >= 5)
        {
            Destroy(gameObject);
        }
    }
}
