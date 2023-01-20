namespace BornToMove
{
    public class MoveBLL
    {
        public List<Move> GetAllMoves()
        {
            return new MoveDAL().GetAllMoves();
        }

        public List<Move> GetMove(int Id)
        {
            return new MoveDAL().GetMove(Id);
        }

        public void SetMove(string name, string description, int sweatRate) 
        {
            new MoveDAL().SetMove(name, description, sweatRate);
        }
    }
}