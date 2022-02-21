using UnityEngine;


namespace BomberPig
{
    public sealed class BombCreator
    {
        private readonly GameObject _bomb;

        public BombCreator(GameObject bomb)
        {
            _bomb = bomb;
        }

        public GameObject CreateBomb(Vector2 position, int orderInLayer)
        {
            var go = GameObject.Instantiate(_bomb, position, Quaternion.identity);
            go.GetComponent<SpriteRenderer>().sortingOrder = orderInLayer;

            return go;
        }
    }
}
