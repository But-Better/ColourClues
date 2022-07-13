using DefaultNamespace;
using Mirror;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class ColorOwner : MonoBehaviour {
    [SerializeField] private ColorClue colorClue;

    public ColorClue ColorClue
    {
        get => colorClue;
        set => colorClue = value;
    }

    private SpriteRenderer spriteRenderer;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
        
        spriteRenderer.color = ColorClue.Color;
    }
}
