using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController : MonoBehaviour
{
    public float speed = 10.0F;
    public camMouseLook mouselook;
    private bool camDisabled = false;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //if (Time.frameCount % 1 != 0) return;
        var translation = Input.GetAxis("Vertical") * speed;
        var strafe = Input.GetAxis("Horizontal") * speed;
        translation *= Time.deltaTime;
        strafe *= Time.deltaTime;

        transform.Translate(strafe, 0, translation);

        if (Input.GetKeyDown("escape") && camDisabled == false)
        {
            Cursor.lockState = CursorLockMode.None;
            mouselook.sensitivity = 0;
            camDisabled = true;
        }
        else if (Input.GetKeyDown("escape") && camDisabled == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            mouselook.sensitivity = 1;
            camDisabled = false;
        }
    }
}
