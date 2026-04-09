using UnityEngine;

public class LuggagePiece : MonoBehaviour
{
    [field: SerializeField] private string PieceName {  get; set; }
    [field: SerializeField] private float BaseValue {  get; set; }
    [field: SerializeField] private float Multiplier {  get; set; }
    [field: SerializeField] private string Modifier {  get; set; }
    public void InitProperties(string pieceName, float baseValue, float multiplier, string modifier)
    {
        PieceName = pieceName;
        BaseValue = baseValue;
        Multiplier = multiplier;
        Modifier = modifier;
    }
}
