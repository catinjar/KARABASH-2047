using UnityEngine;

public class GameState : MonoBehaviour
{
    private static GameState instance;

    public static GameState Instance
    {
        get
        {
            if (instance == null)
            {
                var gameObject = new GameObject();
                instance = gameObject.AddComponent<GameState>();
            }

            return instance;
        }
    }
    
    public float Score { get; set; }
    public float Health { get; set; } = 100;
    public float FlamethrowerAmmo { get; set; } = 100;
}
