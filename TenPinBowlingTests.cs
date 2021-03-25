using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeAddict
{
    [TestFixture]
    public class TenPinBowlingTests
    {
        [Test]
        public void ExampleTests()
        {
            Assert.AreEqual(20, TenPinBowling.BowlingScore("11 11 11 11 11 11 11 11 11 11"));
            Assert.AreEqual(300, TenPinBowling.BowlingScore("X X X X X X X X X XXX"));
            Assert.AreEqual(115, TenPinBowling.BowlingScore("00 5/ 4/ 53 33 22 4/ 5/ 45 XXX"));
            Assert.AreEqual(117, TenPinBowling.BowlingScore("00 70 3/ 7/ 5/ 09 16 7/ 36 XXX"));
        }
    }

    public static class TenPinBowling
    {
        public static int BowlingScore(string frames)
        {
            //add your magical code here.

            int totalScore = 0;

            var scoreFrames = GenerateScoreFrames(frames);

            foreach (var frame in scoreFrames)
            {
                totalScore += frame.Score();
            }

            return totalScore;
        }

        private static List<IFrame> GenerateScoreFrames(string frames)
        {
            List<IFrame> generatedFrames = new List<IFrame>();

            // split frames scores to array of string 
            var throws = frames.Split(new char[] { ' ' });

            for (int i = 0; i < throws.Length; i++)
            {
                if (throws[i].Equals("XXX"))
                {
                    generatedFrames.Add(new StrikeFrame(10, 10));
                }
                else if (throws[i].Equals("X"))
                {
                    int firstFollowingScore = ConvertThrowScore(throws, i, 1);

                    int secondFollowingScore = ConvertThrowScore(throws, i, 2);

                    generatedFrames.Add(new StrikeFrame(firstFollowingScore, secondFollowingScore));
                }
                else if (throws[i].Contains("/"))
                {
                    int nextBallThrowScore = 0;

                    string nextFollowingThrow;

                    if (i < throws.Length)
                    {
                        nextFollowingThrow = throws[i + 1];

                        if (nextFollowingThrow.Equals("XXX"))
                        {
                            nextBallThrowScore = 10;
                        }
                        else if (nextFollowingThrow.Equals("X"))
                        {
                            nextBallThrowScore = 10;
                        }
                        else
                        {
                            nextBallThrowScore = (int)Char.GetNumericValue(nextFollowingThrow.ToArray()[0]);
                        }
                    }
                    else if (i == throws.Length - 1)
                    {
                        nextFollowingThrow = throws[i];

                        if (nextFollowingThrow.Equals("XXX"))
                        {
                            nextBallThrowScore = 10;
                        }
                        else if (nextFollowingThrow.Equals("X"))
                        {
                            nextBallThrowScore = 10;
                        }
                        else
                        {
                            nextBallThrowScore = (int)Char.GetNumericValue(nextFollowingThrow.ToArray()[0]);
                        }
                    }

                    generatedFrames.Add(new SpareFrame(nextBallThrowScore));
                }
                else
                {
                    var throwScores = throws[i].ToArray();
                    int firstThrow = (int)Char.GetNumericValue(throwScores[0]);
                    int secondThrow = (int)Char.GetNumericValue(throwScores[1]);

                    generatedFrames.Add(new OpenFrame(firstThrow, secondThrow));
                }
            }

            return generatedFrames;
        }

        private static int ConvertThrowScore(string[] throws, int index, int offset = 0)
        {
            int score = 0;

            string indexThrow;

            if (index < throws.Length - offset)
            {
                indexThrow = throws[index + offset];

                if (indexThrow.Equals("XXX"))
                {
                    score = 10;
                }
                else if (indexThrow.Equals("X"))
                {
                    score = 10;
                }
                else
                {
                    score = (int)Char.GetNumericValue(indexThrow.ToArray()[0]);
                }
            }
            else if (index == throws.Length - offset)
            {
                indexThrow = throws[index];

                if (indexThrow.Equals("XXX"))
                {
                    score = 10;
                }
                else if (indexThrow.Equals("X"))
                {
                    score = 10;
                }
                else
                {
                    score = (int)Char.GetNumericValue(indexThrow.ToArray()[0]);
                }
            }

            return score;
        }
    }

    #region Frame

    public interface IFrame
    {
        int Score();
    }

    public class OpenFrame : IFrame
    {
        public int FirstThrow { get; private set; }

        public int SecondThrow { get; private set; }

        public OpenFrame(int firstThrow, int secondThrow)
        {
            FirstThrow = firstThrow;
            SecondThrow = secondThrow;
        }

        public int Score()
        {
            return FirstThrow + SecondThrow;
        }
    }

    public class SpareFrame : IFrame
    {
        public int NextBallThrow { get; set; }

        public SpareFrame(int nextBallThrow)
        {
            NextBallThrow = nextBallThrow;
        }

        public int Score()
        {
            return 10 + NextBallThrow;
        }
    }

    public class StrikeFrame : IFrame
    {
        int FirstFollowingBall, SecondFollowingBall;

        public StrikeFrame(int firstFollowingBall = 0, int secondFollowingBall = 0)
        {
            FirstFollowingBall = firstFollowingBall;
            SecondFollowingBall = secondFollowingBall;
        }

        public int Score()
        {
            return 10 + FirstFollowingBall + SecondFollowingBall;
        }
    }
    #endregion

}
