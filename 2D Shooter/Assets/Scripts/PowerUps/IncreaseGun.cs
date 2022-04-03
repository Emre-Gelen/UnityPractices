using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.PowerUps
{
    public class IncreaseGun : PowerUpBase
    {
        [Tooltip("The gun to be added to player.")]
        public GameObject gun = null;

        public void DestroyThis()
        {
            Destroy(this.gameObject);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            GameObject gameObject = collision.gameObject;
            int degree = UnityEngine.Random.Range(-60, 60);
            if (gameObject.tag == "Player" && gun != null)
            {
                DestroyThis();
                Instantiate(gun, gameObject.transform.position, Quaternion.EulerRotation(0, 0, degree), gameObject.transform);
            }
        }
    }
}
