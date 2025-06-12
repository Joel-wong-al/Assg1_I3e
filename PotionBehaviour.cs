using UnityEngine;

public class PotionBehaviour : MonoBehaviour
{
    public int value = 1;
    public void Collect(PlayerBehaviour player) //Allow player to collect coin and destory it//
    {
        Debug.Log("Plus one Point");
        player.ModifyScore(value);
        Destroy(gameObject);
    }

}
