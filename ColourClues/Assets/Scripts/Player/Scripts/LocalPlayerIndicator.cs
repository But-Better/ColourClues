using Mirror;
using UnityEngine;

/// <summary>
/// Adds Local Player Indication
/// <see cref="NetworkBehaviour"/> (Mirror)
/// </summary>
public class LocalPlayerIndicator : NetworkBehaviour
{
    public Color colorIndicator = Color.red;
    private SpriteRenderer _ownSprite;
    
    // Start is called before the first frame update
    void Start()
    {
        _ownSprite = gameObject.GetComponent<SpriteRenderer>();
        if (isLocalPlayer)
        {
            _ownSprite.color = colorIndicator;
        }
    }
    
}
