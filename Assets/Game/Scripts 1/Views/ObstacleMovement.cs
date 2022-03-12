
using UnityEngine;
using KiksAr.ShootingGame.Model;

namespace KiksAr.ShootingGame.Views
{
    public class ObstacleMovement : MonoBehaviour
    {
        public ObstaleModel obstaleModel;
        private float speed;
        private float wave;

        void Start()
        {
            wave = obstaleModel.wave;
            speed = obstaleModel.obstacleSpeed;
        }
        // Update is called once per frame
        public void MoveObstacle()
        {
           transform.position = new Vector3(Mathf.Sin(Time.time * speed) * wave, transform.position.y, transform.position.z);  

        }
    }
}
