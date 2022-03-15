using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
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
        [SerializeField] private TMP_Text hitText;   
        private int perfecthit = 10;     
       
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
           restart.onClick.RemoveListener(RestartGame);
       }
       private void RestartGame()
       {
        //   SceneManager.LoadScene(0);
           count = 0;
            countText.text = count.ToString();
           scoreText.text = PlayerPrefs.GetInt("Score").ToString();
           Shooter.shooterInstance.RestartGame();
           result.SetActive(false);


       }
       public void UpdateScore(float score)
       {
           int textCount;
           if(score < 2)
           {
               textCount = 10;
               count += textCount;
           }
           else if(score >= 2 && score < 4)
           {
               textCount = 5;
               count += textCount;
           }
           else
           {
               textCount = 2;
               count += textCount;
           }


          hitText.text = "+" + textCount.ToString();
           countText.text = count.ToString();
           StartCoroutine(HitTextDisable());


       }
        IEnumerator HitTextDisable()
       {
           yield return new WaitForSeconds(1);
           hitText.text = "";
       }
       public bool ReturnScore()
       {
           if(count  > (Shooter.shooterInstance.totalBullets * perfecthit / 2)) return true;
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
           lost.gameObject.SetActive(false);
           ResetScore();

       }
       public void GameLost()
       {
           result.SetActive(true);
           lost.gameObject.SetActive(true);
           won.gameObject.SetActive(false);
           ResetScore();
       }

    }
}
