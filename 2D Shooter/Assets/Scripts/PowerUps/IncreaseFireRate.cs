using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.PowerUps
{
    public class IncreaseFireRate :PowerUpBase
    {
        public void DestroyThis()
        {
            Destroy(this.gameObject);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            GameObject gameObject = collision.gameObject;
            if (gameObject.tag == "Player")
            {
                DestroyThis();
                foreach (Transform item in gameObject.GetComponentsInChildren<Transform>())
                {
                    ShootingController shootingController = item.GetComponent<ShootingController>();
                    if (shootingController != null && shootingController.fireRate > 0.3)
                        shootingController.fireRate -= 0.05f; 
                }
            }
        }
    }
}
