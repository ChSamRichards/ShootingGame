
using System.Collections.Generic;
using UnityEngine;
using KiksAr.ShootingGame.Views;
using UnityEngine.UI;

namespace KiksAr.ShootingGame.Controller
{
    public class Shooter : MonoBehaviour
    {
        public enum GameStatus
        {
            idle,
            lost,
            won,
            scorecheck,
            waittillallbullets_hit
        }
        [SerializeField] private bool enableLogs;
        [SerializeField] private bool deletePlayerPrefs;
        public GunMovement gunMovement;
        [SerializeField] private GameObject Prefab;
        [SerializeField] private Transform parent;
        [SerializeField] private ObstacleMovement obstacleMovement;
        public int totalBullets;
        public static Shooter shooterInstance;
        private Queue<GameObject> bullets = new Queue<GameObject>();
        
     
        private GameStatus gameStatus;
        public int flag;
        public int hitItems;
        private bool bulletsround1Finished;
        [SerializeField] private Text bulletsLeftText;
      
   
    
    
        void Awake()
        {

            if (shooterInstance != null)
            {
                Destroy(gameObject);
            }
            else    
            {
                shooterInstance = this;
                DontDestroyOnLoad(this.gameObject);
            }
           
            if(enableLogs) Debug.unityLogger.logEnabled = true;
            else Debug.unityLogger.logEnabled = false;
            

            if(deletePlayerPrefs) PlayerPrefs.DeleteAll();
            PoolBullets();

           

       }
       private void PoolBullets()
       {
            for(int i = 0; i < totalBullets; i++)
            {
               GameObject bullet = Instantiate(Prefab, Prefab.transform.position, Quaternion.identity, parent);
               bullet.SetActive(false);
               bullets.Enqueue(bullet);

            }
            gameStatus = GameStatus.idle;


       }
       public void EnqueBullets(GameObject bullet)
       {
           bullet.SetActive(false);
            bullets.Enqueue(bullet);
       }
       public void IncrementHitItems()
       {
           hitItems++;
       }
        void Update()
        {

            
                switch (gameStatus)
                {
                    case GameStatus.idle:
                        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
                        {

                      
                            if(flag < totalBullets)
                            {
                                bullets.Dequeue().SetActive(true);
                                flag++;
                            }
                            if(flag == totalBullets)
                            {
                                bulletsround1Finished = true;
                                gameStatus = GameStatus.waittillallbullets_hit;
                                
                                 
                            }
                        }
                           
                       
                           
                        break;
                    case GameStatus.won:    GameWon();
                        break;
                    case GameStatus.lost:      GameLost();
                        break;
                    case GameStatus.scorecheck: if(ScoreController.scoreControllerInstance.ReturnScore())
                                                    gameStatus = GameStatus.won;
                                                else
                                                    gameStatus = GameStatus.lost;
                        break;
                    case GameStatus.waittillallbullets_hit: 
                            if(bulletsround1Finished && hitItems == totalBullets)
                            {
                                
                                flag = 0;
                                hitItems = 0;
                                 gameStatus = GameStatus.scorecheck;

                            }
                        break;
                    default:    
                        break;
                }
                bulletsLeftText.text = (totalBullets - flag).ToString();

               
               
               



            
           
           
            gunMovement.MoveGun();
            obstacleMovement.MoveObstacle();
           




        }
     
        private void GameWon()
        {
            ScoreController.scoreControllerInstance.GameWon();
        }
        private void GameLost()
        {
            ScoreController.scoreControllerInstance.GameLost();
        }
        public void RestartGame()
        {
              bulletsLeftText.text = (totalBullets - flag).ToString();

            gameStatus = GameStatus.idle;
        }
        
    }
}
