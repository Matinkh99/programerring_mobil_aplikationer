using UnityEngine;

public class EnemySlow : BaseEnemy
{
    void Awake()
    {
        GravityScale = 0.5f;
    }

}
