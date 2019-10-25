using UnityEngine;

public class OnStartScene : MonoBehaviour
{
    public string MusicName;

    void Start()
    {
        if(MusicName == null)
            Debug.LogError("Faltando o nome da música na cena!");
        else
            AudioManager.GetInstance().Play(MusicName);
    }
}
