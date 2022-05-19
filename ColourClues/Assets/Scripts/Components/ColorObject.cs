using DefaultNamespace;
using Event;
using UnityEngine;
/// <summary>
/// A basic component that sets the color of the SpriteRenderer to the assigned color of the ColorClue on Start().
///
/// The components sets the alpha of this component to 0 when the value of the ColorClueEvent is not equal the assigned ColorClue.
/// </summary>
[RequireComponent(typeof(SpriteRenderer))]
public class ColorObject : BaseGameEventListener<ColorClue> {

    [SerializeField] private ColorClue colorClue;

    private SpriteRenderer spriteRenderer;

    public ColorClue ColorClue => colorClue;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();

        spriteRenderer.color = ColorClue.Color;
    }

    public override void OnEventRaised(ColorClue value) {
        base.OnEventRaised(value);

        if(ColorClue != value) {
            spriteRenderer.color = new Color(ColorClue.Color.r, ColorClue.Color.g, ColorClue.Color.b, 0);
        }
    }
}