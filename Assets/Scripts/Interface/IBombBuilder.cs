using UnityEngine;


namespace BomberPig
{
    public interface IBombBuilder
    {
        GameObject BuildBomd(Vector2 position, int orderInLayer);
    }
}
