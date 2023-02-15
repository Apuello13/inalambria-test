using domino_api.Models;

namespace domino_api.Utilities
{
    public static class Utils
    {
        static int maxLength = 7;
        static int minLength = 2;
        static int left = 0;
        static int right = 1;

        public static bool isValidLengthDominos(List<Domino> dominos) {
            int lengthDominos = dominos.Count;
            return !(lengthDominos >= minLength && lengthDominos <= maxLength);
        }

        public static bool isValidChainDomino(List<Domino> dominos) {
            //Not repeat the same numbers inverse
            int MAXIMUM = 1;
            bool hasDuplicates = dominos.GroupBy(domino => new { domino.Left, domino.Right })
                .Any(a => a.Count() > MAXIMUM);
            return hasDuplicates;
        }

        public static List<List<Domino>> generateCombinations(List<Domino> dominos, List<int[]> numbers) {
            List<int> numbersDomino = getDistintics(numbers);
            List<List<Domino>> combinations = new List<List<Domino>>();
            int countOfMiddle = dominos.Count - 1;
            bool isGenerateNumber = false;
            int numberCombination = numberOfCombinations(dominos.Count, numbersDomino.Count);
            for (int i = 0; i < numberCombination; i++) {
                List<Domino> singleCombination = new List<Domino>();
                int first = generateRandom(numbersDomino);
                numbersDomino = removeElement(numbersDomino, first);
                int jokeNumber = generateRandom(numbersDomino);
                numbersDomino = removeElement(numbersDomino, jokeNumber);
                singleCombination.Add(new Domino(first, jokeNumber));
                for (int j = 0; j < countOfMiddle; j++) {
                    Domino domino = new Domino(jokeNumber, first);
                    isGenerateNumber = !isGenerateNumber;
                    if (numbersDomino.Count == 0)
                    {
                        domino.Left = jokeNumber;
                        domino.Right = first;
                    }
                    if (isGenerateNumber) {
                        jokeNumber = generateRandom(numbersDomino);
                        numbersDomino = removeElement(numbersDomino, jokeNumber);
                        domino.Right = jokeNumber;
                    }
                    singleCombination.Add(domino);
                }
                numbersDomino = getDistintics(numbers);
                bool isExits = combinations
                    .FindAll(combination => 
                        combination.First().Left == singleCombination.First().Left).Count > 1;
                if(!isExits) combinations.Add(singleCombination);
            }
            return combinations;
        }

        public static int generateRandom(List<int> numbers) {
            Random rnd = new Random();
            int randomIndex = rnd.Next(numbers.Count);
            int randomNumber = numbers[randomIndex];
            return randomNumber;
        }

        public static List<int> removeElement(List<int> numbers, int number) {
            return numbers.FindAll(n => n != number);
        }

        public static List<int> getDistintics(List<int[]> numbers) {
            List<int> distincts = new List<int>();
            numbers.ForEach(number =>
            {
                distincts.Add(number[left]);
                distincts.Add(number[right]);
            });
            return distincts.Distinct().ToList();
        }

        public static List<Domino> convertDominosToObject(List<int[]> numbers) {
            List<Domino> dominos = new List<Domino>();
            numbers.ForEach(number => dominos.Add(new Domino(number[left], number[right])));
            return dominos;
        }

        public static int numberOfCombinations(int dominosCount, int quantityNumbers) {
            return (int) Math.Pow(dominosCount, quantityNumbers);
        }
    }
}
