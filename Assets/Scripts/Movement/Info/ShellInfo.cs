using UnityEngine;

[CreateAssetMenu (fileName = "Shell", menuName = "GameObjects/Shells")]
public class ShellInfo : ScriptableObject
{
    public int ID;
    public string Name;
    public float Speed;
}
