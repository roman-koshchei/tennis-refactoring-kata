namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int p1point = 0;
        private int p2point = 0;

        private string p1res = "";
        private string p2res = "";

        public TennisGame2(string player1Name, string player2Name)
        {
            // player names aren't used, but keep to not break tests
            _ = player1Name;
            _ = player2Name;
        }

        public string GetScore()
        {
            var score = "";
            if (p1point == p2point)
            {
                return p1point switch
                {
                    0 => "Love-All",
                    1 => "Fifteen-All",
                    2 => "Thirty-All",
                    _ => "Deuce"
                };
            }

            if (p1point < 4 && p2point < 4)
            {
                p1res = Count(p1point);
                p2res = Count(p2point);
                return $"{p1res}-{p2res}";
            }

            if (p1point >= 4 && (p1point - p2point) >= 2)
            {
                return "Win for player1";
            }
            if (p2point >= 4 && (p2point - p1point) >= 2)
            {
                return "Win for player2";
            }

            if (p1point > p2point)
            {
                return "Advantage player1";
            }

            if (p2point > p1point)
            {
                return "Advantage player2";
            }

            return score;
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