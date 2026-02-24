using UnityEngine;

public class Enemy : BaseEnemy
{
    



    
}
public abstract class BaseEnemy:MonoBehaviour{


    public float GravityScale = 1f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = GravityScale;
    }
    void Update()
    {
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);
        if(viewportPos.y <0f)
        {
            Destroy(gameObject);
        }
    }
    
    


}
