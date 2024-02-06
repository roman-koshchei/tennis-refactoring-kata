namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int p1point = 0;
        private int p2point = 0;

        public TennisGame2(string player1Name, string player2Name)
        {
            // player names aren't used, but keep to not break tests
            _ = player1Name;
            _ = player2Name;
        }

        public string GetScore()
        {
            if (p1point == p2point)
            {
                return p1point switch
                {
                    <= 2 => $"{Count(p1point)}-All",
                    _ => "Deuce"
                };
            }

            if (p1point < 4 && p2point < 4)
            {
                return $"{Count(p1point)}-{Count(p2point)}";
            }

            var difference = p1point - p2point;
            return difference switch
            {
                >= 2 => "Win for player1",
                <= -2 => "Win for player2",
                > 0 => "Advantage player1",
                _ => "Advantage player2"
            };
        }

        private static string Count(int points)
        {
            return points switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                3 => "Forty",
                _ => ""
            };
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
            {
                p1point += 1;
                return;
            }

            p2point += 1;
        }
    }
}