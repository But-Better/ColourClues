using DefaultNamespace.Models;
using Event;
using UnityEngine;
/// <summary>
/// A basic component that sets the alpha value received from the raised event.
/// </summary>
[RequireComponent(typeof(ColorObject))]
[RequireComponent(typeof(SpriteRenderer))]
public class ColorObjectAlphaReceiver : BaseGameEventListener<AlphaValue> {

    private ColorObject colorObject;
    private SpriteRenderer spriteRenderer;

    private void Start() {
        colorObject = GetComponent<ColorObject>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public override void OnEventRaised(AlphaValue value) {
        base.OnEventRaised(value);

        var colorClue = colorObject.ColorClue;

        spriteRenderer.color = new Color(colorClue.Color.r, colorClue.Color.g, colorClue.Color.b, value.Value);
    }
}