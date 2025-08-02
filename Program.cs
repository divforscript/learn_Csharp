// Challenge: Write code to reverse each word in a message

string pangram = "The quick brown fox jumps over the lazy dog";

string[] eachWord = pangram.Split(" ");

int pangramLength = eachWord.Length;
string reversedSentence = new string("");

for (int i = 0; i < pangramLength; i++)
{
    char[] eachLetter = eachWord[i].ToCharArray();
    Array.Reverse(eachLetter);

    string reversedWord = String.Join("", eachLetter);

    eachWord[i] = reversedWord;
}

reversedSentence = String.Join(" ", eachWord);
Console.WriteLine(reversedSentence);



// Version 2:

// for (int i = 0; i < pangramLength; i++)
// {
//     char[] eachLetter = eachWord[i].ToCharArray();
//     Array.Reverse(eachLetter);

//     eachWord[i] = new string(eachLetter);
// }

// reversedSentence = String.Join(" ", eachWord);
// Console.WriteLine(reversedSentence);
