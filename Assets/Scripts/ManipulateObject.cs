using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class ManipulateObject : MonoBehaviour
{
    private MLInput.Controller controller;
    GameObject selectedGameObject;
    public GameObject attachPoint;
    public GameObject ControllerObject;
    bool trigger;

    // Start is called before the first frame update
    void Start()
    {
        MLInput.Start();
        controller = MLInput.GetController(MLInput.Hand.Left);
    }

    void UpdateTriggerInfo()
    {
        if(controller.TriggerValue > 0.8f)
        {
            if(trigger == true)
            {
                RaycastHit hit;
                if(Physics.Raycast(controller.Position, transform.forward, out hit))
                {
                    if(hit.transform.gameObject.tag == "Interactable")
                    {
                        selectedGameObject = hit.transform.gameObject;
                        selectedGameObject.GetComponent<Rigidbody>().useGravity = false;
                        attachPoint.transform.position = hit.transform.position;
                    }
                }
                trigger = false;
            }
        }

        if(controller.TriggerValue < 0.2f)
        {
            trigger = true;
            if(selectedGameObject != null)
            {
                selectedGameObject.GetComponent<Rigidbody>().useGravity = false;
                selectedGameObject = null;
            }
        }
    }


    void UpdateTouchPad()
    {
        if(controller.Touch1Active)
        {
            float x = controller.Touch1PosAndForce.x;
            float y = controller.Touch1PosAndForce.y;
            float force = controller.Touch1PosAndForce.z;

            if(force > 0)
            {
                if(x > 0.5 || x < -0.5)
                {
                    selectedGameObject.transform.localScale += (selectedGameObject.transform.localScale * x * Time.deltaTime);
                }

                if(y > 0.3 || y < -0.3)
                {
                    attachPoint.transform.position = Vector3.MoveTowards(attachPoint.transform.position, gameObject.transform.position, -y * Time.deltaTime);
                }
            }
        }
    }

    private void OnDestroy()
    {
        MLInput.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = controller.Position;
        transform.rotation = controller.Orientation;

        if(selectedGameObject)
        {
            selectedGameObject.transform.position = attachPoint.transform.position;
            selectedGameObject.transform.rotation = gameObject.transform.rotation;
        }

        UpdateTriggerInfo();
        UpdateTouchPad();
    }
}
