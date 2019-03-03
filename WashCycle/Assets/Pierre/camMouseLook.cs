using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camMouseLook : MonoBehaviour
{
    private Vector2 _mouseLook;
    private Vector2 _smoothV;
    public float sensitivity = 5.0f;
    public float smoothing = 2.0f;

    GameObject character;

    // Start is called before the first frame update
    private void Start()
    {
        character = this.transform.parent.gameObject;    
    }

    // Update is called once per frame
    private void Update()
    {
//        if (Time.frameCount % 1 == 0)
//        {
            var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));

            md = Vector2.Scale(md, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
            _smoothV.x = Mathf.Lerp(_smoothV.x, md.x, 1f / smoothing);
            _smoothV.y = Mathf.Lerp(_smoothV.y, md.y, 1f / smoothing);
            _mouseLook += _smoothV;
            _mouseLook.y = Mathf.Clamp(_mouseLook.y, -90f, 90f);

            transform.localRotation = Quaternion.AngleAxis(-_mouseLook.y, Vector3.right);
            character.transform.localRotation = Quaternion.AngleAxis(_mouseLook.x, character.transform.up);
       // }
    }
}
