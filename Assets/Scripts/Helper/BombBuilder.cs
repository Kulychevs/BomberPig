using UnityEngine;


namespace BomberPig
{
    public sealed class BombBuilder : IBombBuilder
    {
        private readonly GameObject _bomb;

        public BombBuilder(GameObject bomb)
        {
            _bomb = bomb;
        }

        public GameObject BuildBomd(Vector2 position, int orderInLayer)
        {
            var go = GameObject.Instantiate(_bomb, position, Quaternion.identity);
            go.GetComponent<SpriteRenderer>().sortingOrder = orderInLayer;

            return go;
        }
    }
}
