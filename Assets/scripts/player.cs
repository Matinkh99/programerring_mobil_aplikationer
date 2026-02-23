using UnityEngine;
using UnityEngine.SceneManagement;


public class player : MonoBehaviour
{
    public DodgerAttributes dodgerAttributes;
    public int startingHealth = 3;
    public int startingScore = 0;

    [SerializeField] float moveSpeed;
    Rigidbody2D rb;
    [SerializeField] inputsys inputsys;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dodgerAttributes = new DodgerAttributes(startingHealth, startingHealth , startingScore);

            
           
        rb = GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("myenemy"))
        {
            int newHealth = dodgerAttributes.get_health()-1;
            dodgerAttributes.setcurr(newHealth);
            Debug.Log("player hit! Health :" + dodgerAttributes.get_health());
            Destroy(collision);
            if (dodgerAttributes.get_health() <= 0)
            {
                RestartGame();
            }
            
        }
    }
    void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        int moveDir = 0;
        Vector2 screenPos;
        if(inputsys.IsPresssing(out screenPos))
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint
            (new Vector3(screenPos.x , screenPos.y , 0f));
            if(touchPos.x <0)
            {
                moveDir = -1;
            }
            else
            {
                moveDir = 1;



            }
            


        }
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(rb.position);
            if ((viewportPos.x <= 0f && moveDir < 0) || (viewportPos.x >= 1 && moveDir > 0))
            {
                moveDir = 0;
            }
           
            rb.linearVelocityX = moveDir * moveSpeed;

    }

  
}
