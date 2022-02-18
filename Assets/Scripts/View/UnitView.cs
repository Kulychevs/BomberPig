using UnityEngine;


public sealed class UnitView : MonoBehaviour
{
    private SpriteRenderer _renderer;


    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }


    public void SetOrderInLayer(int sortingOrder)
    {
        _renderer.sortingOrder = sortingOrder;
    }

    public void SetPosition(Vector2 position)
    {
        transform.position = position;
    }

    public void SetSprite(Sprite sprite)
    {
        _renderer.sprite = sprite;
    }
}
