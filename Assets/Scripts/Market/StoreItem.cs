using UnityEngine;

[CreateAssetMenu(fileName = "new Item", menuName = "Store Item")]
public class StoreItem : ScriptableObject
{
    public int cost;
    public new string name;
    public Sprite image;
}