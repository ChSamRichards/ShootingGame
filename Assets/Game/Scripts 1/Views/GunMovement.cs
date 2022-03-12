using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KiksAr.ShootingGame.Model;

namespace KiksAr.ShootingGame.Views
{
    public class GunMovement : MonoBehaviour
    {
        public GunModel gunModel;
        private float gunSpeed;
      

        void Start()
        {
            gunSpeed = gunModel.gunSpeed;
       

        }
       public void MoveGun()
       {    
            float movement = Input.GetAxis("Horizontal");
            transform.position = new Vector3(Mathf.Clamp(transform.position.x + movement * gunSpeed * Time.deltaTime , -3f, 3f), 49, 13);

       }
    }
}
