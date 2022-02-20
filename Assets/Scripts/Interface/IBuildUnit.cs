using UnityEngine;


namespace BomberPig
{
    public interface IBuildUnit
    {
        public UnitView BuildPlayer(GameObject player, Vector2 position);
    }
}
