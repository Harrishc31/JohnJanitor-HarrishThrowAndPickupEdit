using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject crosshair1, crosshair2;
    public Transform objTransform, cameraTrans, playerTrans;
    public bool interactable, pickedup;
    public Rigidbody objRigidbody;
    public float throwAmount;

    public GameObject stageObj;
    public GameObject pickupObj;

   // public Renderer stageRender;
    //public Renderer PickUpRender;
    //public Renderer stageRender;

    void start()
    {
       
    }
    

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            crosshair1.SetActive(false);
            crosshair2.SetActive(true);
            interactable = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            if(pickedup == false)
            {
                crosshair1.SetActive(true);
                crosshair2.SetActive(false);
                interactable = false;
            }
            if (pickedup == true)
            {
                objTransform.parent = null;
                objRigidbody.useGravity = true;
                crosshair1.SetActive(true);
                crosshair2.SetActive(false);
                interactable = false;
                pickedup = false;
            }
        }
    }
    void Update()
    {
        if (interactable == true)
        {
            if (Input.GetMouseButtonDown(0)) //pickup
            {
            
               // pickupObj.SetActive(true);
                objTransform.parent = cameraTrans;
                
                objRigidbody.useGravity = false;
                pickedup = true;
            }
            if (Input.GetMouseButtonUp(0)) //drop
            {
                //stageRender.enabled = true;
                // pickupObj.SetActive(false);
                objTransform.parent = null;
                objRigidbody.constraints &= ~RigidbodyConstraints.FreezeRotation;
                objRigidbody.useGravity = true;
                pickedup = false;
            }
            
            if(pickedup == true)
            {
                objRigidbody.constraints = RigidbodyConstraints.FreezeRotation;
                if (Input.GetMouseButtonDown(1)) //throw
                {
                   // stageObj.SetActive(true);
                   // pickupObj.SetActive(false);
                    objTransform.parent = null;
                    objRigidbody.useGravity = true;
                    objRigidbody.velocity = cameraTrans.forward * throwAmount * Time.deltaTime;
                    pickedup = false;
                }
                
            }
            else
            {
                objRigidbody.constraints &= ~RigidbodyConstraints.FreezeRotation;
            }
        }
    }
}