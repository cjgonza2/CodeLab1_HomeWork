using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HW7CameraLook : MonoBehaviour
{

    public float sphereRadius = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 eyePosition = transform.position;
        Vector3 mousePos = Input.mousePosition;

        mousePos.z = Camera.main.nearClipPlane;

        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector3 dir = mouseWorldPos - eyePosition;
        dir.Normalize();

        RaycastHit hitter = new RaycastHit();

        if (Physics.SphereCast(eyePosition, sphereRadius, dir, out hitter))
        {
            //Debug.Log("hitSomething");
            if (Input.GetMouseButton(0) && (hitter.collider.gameObject.tag == "Relic"))
            {
                SceneManager.LoadScene("Lose Scene");
            } else if (Input.GetMouseButton(0) && (hitter.collider.gameObject.tag == "Solution"))
            {
                SceneManager.LoadScene("Win Scene");
            }
        }
    }
}
