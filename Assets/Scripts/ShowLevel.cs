using UnityEngine;

public class ShowLevel : MonoBehaviour
{
    public Movimento player_mvt;

    void OnDestroy()
    {
        player_mvt.canMove = true;
    }
}