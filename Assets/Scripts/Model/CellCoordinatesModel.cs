namespace BomberPig
{
    [System.Serializable]
    public struct CellCoordinatesModel
    {
        public int Row;
        public int Column;

        public static bool operator ==(CellCoordinatesModel lhs, CellCoordinatesModel rhs)
        {
            return (lhs.Row == rhs.Row && lhs.Column == rhs.Column);
        }
        public static bool operator !=(CellCoordinatesModel lhs, CellCoordinatesModel rhs)
        {
            return !(lhs == rhs);
        }

    }
}
