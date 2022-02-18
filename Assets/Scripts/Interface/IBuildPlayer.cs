using UnityEngine;


namespace BomberPig
{
    public interface IBuildPlayer
    {
        public UnitView BuildPlayer(GameObject player, Vector2 position);
    }
}
