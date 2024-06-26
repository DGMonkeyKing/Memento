using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlatformEffector2D))]
public class OneWayPlatform : MonoBehaviour
{
    private float _verticalInput = 0f;
    private Collider2D _collider;

    // Start is called before the first frame update
    void Start()
    {
        _collider = GetComponent<Collider2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        _verticalInput = Input.GetAxisRaw("Vertical");

        if(_verticalInput < 0f)
        {
            _collider.enabled = false;
        }
        else if(_verticalInput == 0 && _collider.enabled == false)
        {
            _collider.enabled = true;
        }
    }
}
