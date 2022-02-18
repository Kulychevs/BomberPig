using UnityEngine;


namespace BomberPig
{
    public interface IUnit
    {
        float GetSpeed { get; }
        Sprite SetCurrentSprite { set; }
    }
}
