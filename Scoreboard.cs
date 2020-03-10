using System.Collections.Generic;
using System.Linq;
using System;

namespace scoreboard_service
{
    class Scoreboard
    {
        private List<Pair> scores = new List<Pair>();

        public void Add(string name, int score)
        {
            scores.Add(new Pair(name, score));
            Sort();
        }

        public void Sort()
        {
            int i = 0;
            while (scores[i].CompareScore(scores.Last()) > 0)
            {
                i++;
            }
            scores.Insert(i, new Pair(scores.Last().name, scores.Last().score));
            scores.RemoveAt(scores.Count - 1);
        }

        public void Print()
        {
            Console.WriteLine("High scores:");
            foreach (Pair pair in scores)
            {
                Console.WriteLine($"{scores.IndexOf(pair) + 1}: {pair.name} {pair.score}");
            }
        }
    }

    struct Pair
    {
        public readonly string name;
        public readonly int score;
        public Pair(string name, int score)
        {
            this.name = name;
            this.score = score;
        }
        public int CompareScore(Pair pair)
        {
            return this.score - pair.score;
        }
    }
}
