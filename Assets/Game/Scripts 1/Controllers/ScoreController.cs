using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace KiksAr.ShootingGame.Controller
{

    public class ScoreController : MonoBehaviour
    {
        public static ScoreController scoreControllerInstance;
        public Text scoreText;
        public Text countText;
        private  int count;

        [SerializeField] private Image won;
        [SerializeField] private Image lost;
        [SerializeField] private Button restart;
   
        [SerializeField] private GameObject result;

        
       
       private void Awake()
       {
           scoreControllerInstance = this;
          
        
       }
       void Start()
       {
             scoreText.text = PlayerPrefs.GetInt("Score").ToString();
       }
       void OnEnable()
       {
            restart.onClick.AddListener(RestartGame);
          
       }
       void OnDisable()
       {
           restart.onClick.AddListener(RestartGame);
       }
       private void RestartGame()
       {
           SceneManager.LoadScene(0);
       }
       public void UpdateScore(float score)
       {
           if(score < 2)
           {
               count += 10;
           }
           else if(score >= 2 && score < 4)
           {
               count += 5;
           }
           else
           {
               count += 2;
           }


          
           countText.text = count.ToString();


       }
       public bool ReturnScore()
       {
           if(count / Shooter.shooterInstance.totalBullets > (Shooter.shooterInstance.totalBullets * 10 / 2)) return true;
           else return false;
           
        
       }
       public void ResetScore()
       {
          
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + count);
           scoreText.text = PlayerPrefs.GetInt("Score").ToString();
            count = 0;
           
       }
       public void GameWon()
       {
           result.SetActive(true);
           won.gameObject.SetActive(true);
           ResetScore();

       }
       public void GameLost()
       {
           result.SetActive(true);
           lost.gameObject.SetActive(true);
           ResetScore();
       }

    }
}
