using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace KartRacing.Scripts
{
    public class PowerUp : MonoBehaviour
    {
        [SerializeField] private GameObject pickupEffect;
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player") && this.gameObject.activeSelf)
            {
                PickUp();
            }
        }

        private void Start()
        {
            if (pickupEffect.activeSelf)
            { 
                pickupEffect?.SetActive(false);
            }
            
        }

        private void PickUp()
        {
            this.pickupEffect?.SetActive(true);
            this.gameObject.SetActive(false);
            Invoke("Deactivate",5f);
        }

        private void Deactivate()
        {
            this.gameObject.SetActive(true);
            this.pickupEffect?.SetActive(false);
            
        }
    }
}