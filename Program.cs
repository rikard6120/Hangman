using Application;



var numberOfGuesses = 10;
var word = "JAZZ";
var result = new List<char>();
var usedLetters = new List<char>();
var listWord = word.ToCharArray().ToList();
var letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray().ToList();

foreach (var i in listWord)
{
    result.Add('_');
} 


while(true){
    if( numberOfGuesses == 0 ){
        Console.WriteLine("Tyvärr, du har förlorat. Bättre lycka nästa gång.");
        break;
    }
    Console.WriteLine("Använda bokstäver: " + ListService.ListToString(usedLetters));
    var guess = Console.ReadLine() ?? " ";
    guess = guess.ToUpper();
    if (char.TryParse(guess, out var guessChar))
    {
        usedLetters.Add(guessChar);
        if (letters.Contains(guessChar))
        {
            int index = letters.IndexOf(guessChar);
            letters.RemoveAt(index);

            if (listWord.Contains(guessChar))
            {
                for (int i = 0; i < listWord.Count; i++)
                {
                    if( listWord[i] == guessChar )
                    {
                        result[i] = guessChar;
                    }
                }
                Console.WriteLine(ListService.ListToString(result));

                if( !result.Contains('_'))
                {
                    Console.WriteLine("Grattis.");
                    break;
                }
            }
            else
            {
                numberOfGuesses--;
                string number = numberOfGuesses.ToString();
                Console.WriteLine("Fel, du har " + number + " gissningar kvar");
            } 
        }
        else 
        {
            Console.WriteLine("Inte giltig gissning!");
        }
    }
}
