namespace BornToMove
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welkom! Het is tijd om te bewegen!\n");

            // get all moves
            Console.WriteLine("All moves:");
            List<Move> movesList = new MoveBLL().GetAllMoves();
            movesList.ForEach(move =>
            {
                // check String.Format for better view
                Console.WriteLine("Toets [" + move.Id + "]: " + move.Name + " | sweat rate: " + move.SweatRate);
            });

            // get 1 move
            Console.WriteLine("\n1 move:");
            int id = 3;
            List<Move> moveList = new MoveBLL().GetMove(id);
            moveList.ForEach(move =>
            {
                // check String.Format for better view
                Console.WriteLine(move.Name + " | sweat rate: " + move.SweatRate + "\n" + move.Description);
            });

            // add move:
            //string name = "Lunge";
            //string description = "Start rechtop. Stap met 1 been naar voren en zak door je knieen. Herhaal met andere been.";
            //int sweatRate = 4;

            //new MoveBLL().SetMove(name, description, sweatRate);

           
        }
    }
}