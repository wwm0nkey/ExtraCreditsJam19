using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public float speed = 10.0F;
    public camMouseLook mouseLook;
    private bool _camDisabled = false;

    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        //if (Time.frameCount % 1 != 0) return;
        var translation = Input.GetAxis("Vertical") * speed;
        var strafe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;

        transform.Translate(strafe, 0, translation);

        if (Input.GetKeyDown("escape") && _camDisabled == false)
        {
            Cursor.lockState = CursorLockMode.None;
            mouseLook.sensitivity = 0;
            _camDisabled = true;
        }
        else if (Input.GetKeyDown("escape") && _camDisabled == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            mouseLook.sensitivity = 1;
            _camDisabled = false;
        }
    }
}
