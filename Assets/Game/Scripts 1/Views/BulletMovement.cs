
using UnityEngine;
using KiksAr.ShootingGame.Controller;
using KiksAr.ShootingGame.Model;

namespace KiksAr.ShootingGame.Views
{

    public class BulletMovement : MonoBehaviour
    {

        public BulletModel bulletModel;
        private Vector3 originalPosition;
        private Quaternion originalRotation;
        private bool hit;
        private ParticleSystem ps;
        private Rigidbody rb;
        private float speed;

        void Awake()
        {
             ps = this.transform.GetChild(0).GetComponent<ParticleSystem>(); 
             rb =    this.gameObject.GetComponent<Rigidbody>();
               speed =bulletModel.speed;
             
        }
        void Start()
        {
            originalPosition = this.transform.position;
            originalRotation = this.transform.rotation;
          
        }
        void OnEnable()
        {
            this.transform.position = new Vector3(Shooter.shooterInstance.gunMovement.transform.position.x,
                                                   Shooter.shooterInstance.gunMovement.transform.position.y,
                                                    Shooter.shooterInstance.gunMovement.transform.position.z + 2);      
            rb.AddForce(this.transform.forward * speed , ForceMode.Impulse);
            ps.Play();       

        }
        void OnDisable()
        {
            ps.Stop();
        }

        void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.name == "Obstacle")
            {
                Vector3 hitPos = new Vector3(transform.position.x ,transform.position.y, transform.position.z);

                ScoreUpdate(hitPos, collision.gameObject.transform.position);

                SetToORiginal();
                Shooter.shooterInstance.IncrementHitItems();



            }
          
        }
        private void ScoreUpdate(Vector3 hitPos, Vector3 obstaclePosition)
        {
            float distance = Vector3.Distance(hitPos, obstaclePosition);
            
            ScoreController.scoreControllerInstance.UpdateScore(distance);
            
        }
    
        private void SetToORiginal()
        {
            gameObject.SetActive(false);
            transform.position = originalPosition;
            transform.rotation = originalRotation;
            Shooter.shooterInstance.EnqueBullets(this.gameObject);




        }
    }
}
