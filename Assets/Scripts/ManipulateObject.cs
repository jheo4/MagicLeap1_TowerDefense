using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class ManipulateObject : MonoBehaviour
{
    private MLInput.Controller controller;
    GameObject selectedObject;
    Tower selectedTower;
    public GameObject attachPoint;
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
                if(Physics.Raycast(controller.Position, transform.forward, out hit, 1))
                {
                    if(hit.transform.gameObject.tag == "Tower")
                    {
                        selectedTower = hit.collider.GetComponent<Tower>();

                        if(selectedTower.installed == false)
                        {
                            selectedObject = hit.transform.gameObject;
                            selectedObject.GetComponent<Rigidbody>().useGravity = false;
                            attachPoint.transform.position = hit.transform.position;

                            selectedTower.grapped = true;
                            selectedTower.atStorage = false;
                        }
                        else
                        {
                            selectedTower = null;
                        }
                    }
                }
                trigger = false;
            }
        }

        if(controller.TriggerValue < 0.2f)
        {
            trigger = true;
            if(selectedObject != null && selectedTower != null)
            {
               selectedObject.GetComponent<Rigidbody>().useGravity = true;
               selectedObject = null;

               selectedTower.grapped = false;
               selectedTower = null;
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
                    selectedObject.transform.localScale += (selectedObject.transform.localScale * x * Time.deltaTime);
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

        if(selectedObject)
        {
            selectedObject.transform.position = attachPoint.transform.position;
            selectedObject.transform.rotation = gameObject.transform.rotation;
        }

        UpdateTriggerInfo();
        UpdateTouchPad();
    }
}
