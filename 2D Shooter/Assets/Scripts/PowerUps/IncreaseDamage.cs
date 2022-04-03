using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.PowerUps
{
    public class IncreaseDamage : PowerUpBase
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
                ShootingController shootingController = gameObject.GetComponent<ShootingController>();
                if (shootingController != null)
                {
                    GameObject projectilePrefab = shootingController.projectilePrefab;
                    if (projectilePrefab != null)
                    {
                        Damage damage = projectilePrefab.GetComponent<Damage>();
                        damage.damageAmount += 5;
                    }
                }
            }
        }
    }

}
