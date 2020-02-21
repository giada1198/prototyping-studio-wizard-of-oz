using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float xMin, xMax, zMin, zMax;
    float smooth = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovementInput();
        HandleRotationInput();
        HandleShootInput();
    }

    void HandleMovementInput()
    {
        float _horizontal = Input.GetAxis("Horizontal");
        float _vertical = Input.GetAxis("Vertical");
        print(_horizontal);
        transform.Translate(Vector3.forward*movementSpeed*Time.deltaTime);
        // Vector3 _movement = new Vector3(_horizontal, 0, _vertical);
        // _movement = Quaternion.Euler(0, 90, 0) * _movement;
        // transform.Translate(_movement*movementSpeed*Time.deltaTime, Space.World);
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, xMin, xMax), 0, Mathf.Clamp(transform.position.z, zMin, zMax));
        
        if (Input.GetKey("right")){
            transform.eulerAngles += new Vector3(0, -9, 0);
        }
        if (Input.GetKey("left")){
            transform.eulerAngles += new Vector3(0, 9, 0);
        }

        // Rotate the cube by converting the angles into a quaternion.
        // Quaternion target = Quaternion.Euler(0, tiltAroundY, 0);
        // Dampen towards the target rotation
        // transform.rotation = Quaternion.Slerp(transform.rotation, target,  Time.deltaTime * smooth);
    
    
    
    }

    void HandleRotationInput()
    {
        RaycastHit _hit;
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit))
        {
            // transform.LookAt(new Vector3(_hit.point.x, transform.position.y, _hit.point.z));
        }
    }

    void HandleShootInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayerGun.Instance.Shoot();
            Debug.Log("Pressed primary button.");
        }
    }
}
