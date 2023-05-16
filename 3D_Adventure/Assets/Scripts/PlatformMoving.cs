using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMoving : MonoBehaviour
{
    [SerializeField]
    private Transform point1, point2;
    private float _speed = 3.0f;
    private bool _switch = false;
    // Start is called before the first frame update
    void Start()
    {
        _speed = 0.0f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!GameObject.FindWithTag("block2") && !GameObject.FindWithTag("block1")) {
            _speed = 3.0f;
        }
        if (_switch == false){
            transform.position = Vector3.MoveTowards(transform.position, point1.position, _speed * Time.deltaTime);
        }
        else if (_switch == true){
            transform.position = Vector3.MoveTowards(transform.position, point2.position, _speed * Time.deltaTime);
        }
        if (transform.position == point1.position){
            _switch = true;
        }
        else if (transform.position == point2.position){
            _switch = false;
        }
    }
    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Player")){
            other.transform.parent = this.transform;
        }
    }
    private void OnTriggerExit(Collider other){
        if (other.CompareTag("Player")){
            other.transform.parent = null;
        }
    }
}
