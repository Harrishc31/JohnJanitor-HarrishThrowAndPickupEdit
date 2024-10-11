using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{ 
    public GameObject pickupText;
    public GameObject WeaponOnPlayer;
    void Start()
    {
        WeaponOnPlayer.SetActive(false);
        pickupText.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "MainCamera")
        {
            pickupText.SetActive(true);
            
            if (Input.GetKey(KeyCode.E))
            {
                this.gameObject.SetActive(false);
                WeaponOnPlayer.SetActive(true);
                //insert code to disable gravity until weapon thrown
                //(temp fix: turned off gravity for the Player Child Weapons)
                pickupText.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        pickupText.SetActive(false);
    }

   
}
