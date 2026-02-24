
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour

{
    public player player;
  
    public void Update()
    {
        if(player!= null && player.dodgerAttributes != null)
        {
            scoreText.text = "Score:" + player.dodgerAttributes.getcurr();
            
           
        }
        if(transform.GetComponent<inputsys>().IsPresssing(out screenPos) && !gameStarted)
        {
             startSpawning();
            gameStarted = true;
        }
    }
   public GameObject[] enemyPrefab;
   [SerializeField] float spawnRate;
   bool gameStarted = false;
   int score = 0;
   Vector2 screenPos;
   [SerializeField] TextMeshProUGUI scoreText;

    void spawnEnemy()
    {
        float randomX = Random.Range(0f , 1f);
         Vector2 viewportPos = new Vector2(randomX , 1f );
         Vector2 worldPos = Camera.main.ViewportToWorldPoint(viewportPos);
         int randomNumber = Random.Range(0, enemyPrefab.Length);
         Instantiate(enemyPrefab[randomNumber] , worldPos , Quaternion.identity);
         score++;
         updateText(score);
    }
    void startSpawning()
    {
        InvokeRepeating("spawnEnemy" , 0.5f , spawnRate);
    }
    
    void updateText(int scoreCurr)
    {
    scoreText.text = scoreCurr.ToString();
    }
    

}
