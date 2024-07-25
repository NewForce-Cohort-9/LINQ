using System.Linq;
using System.Security.Cryptography.X509Certificates;

//JS
// array methods - .map, .find, .filter, .push, .length, .sort 

// C#
// LINQ methods - .Count, .Where, .Select, .OrderBy, .GroupBy

//lambdas function
// unnamed or anonymous function that we utilize with our fat arrow => to return a value

// Find the words in the collection that start with the letter 'L'
List<string> fruits = new List<string>() {"Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry"};

List <string> LFruits = (from singleFruit in fruits where singleFruit.StartsWith("L") select singleFruit).ToList();

for(int i = 0; i < LFruits.Count(); i++)
{
    // Console.WriteLine(LFruits[i]);
}

List<string> newLFruits = fruits.Where(singleFruit => singleFruit.StartsWith("L")).ToList();

for(int i = 0; i < newLFruits.Count(); i++)
{
    // Console.WriteLine(newLFruits[i]);
}

// Which of the following numbers are multiples of 4 or 6
List<int> numbers = new List<int>()
{
    15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
};

List<int> fourSixMultiples = numbers.Where(number => number % 4 == 0 || number % 6 == 0).ToList();

// fourSixMultiples.ForEach(fourSixMultiple => Console.WriteLine(fourSixMultiple));

// foreach(int singleNumber in fourSixMultiples)
// {
//     Console.WriteLine(singleNumber);
// }


// Order these student names alphabetically, in descending order (Z to A)
List<string> names = new List<string>()
{
    "Heather", "James", "Xavier", "Michelle", "Brian", "Nina",
    "Kathleen", "Sophia", "Amir", "Douglas", "Zarley", "Beatrice",
    "Theodora", "William", "Svetlana", "Charisse", "Yolanda",
    "Gregorio", "Jean-Paul", "Evangelina", "Viktor", "Jacqueline",
    "Francisco", "Tre"
};

List<string> descend = names.OrderByDescending(singleName => singleName).ToList();

// descend.ForEach(singleDescend => Console.WriteLine(singleDescend));

// Build a collection of these numbers sorted in ascending order
List<int> newNumbers = new List<int>()
{
    15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
};

List<int> ascend = numbers.OrderBy(singleNumber => singleNumber).ToList();

// ascend.ForEach(singleAscend => Console.WriteLine(singleAscend));

// Output how many numbers are in this list
List<int> newNewNumbers = new List<int>()
{
    15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
};

int howMany = newNewNumbers.Count();

// Console.WriteLine(howMany);

// How much money have we made?
List<double> purchases = new List<double>()
{
    2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
};

double money = purchases.Sum();

// Console.WriteLine(money);

// What is our most expensive product?
List<double> prices = new List<double>()
{
    879.45, 9442.85, 2454.63, 45.65, 2340.29, 34.03, 4786.45, 745.31, 21.76
};

double expensive = prices.Max();
double otherExpensive = prices.OrderBy(number => number).Last();

// Console.WriteLine(expensive);
// Console.WriteLine(otherExpensive);

List<int> wheresSquaredo = new List<int>()
{
    66, 12, 8, 27, 82, 34, 7, 50, 19, 46, 81, 23, 30, 4, 68, 14
};
/*
    Store each number in the following List until a perfect square
    is detected.

    Expected output is { 66, 12, 8, 27, 82, 34, 7, 50, 19, 46 } 

    Ref: https://msdn.microsoft.com/en-us/library/system.math.sqrt(v=vs.110).aspx
*/
List<int> nonSquares = wheresSquaredo.TakeWhile(square => !(Math.Sqrt(square) % 1 == 0)).ToList();

// nonSquares.ForEach(square => Console.WriteLine(square));

//same thing just long form without a LINQ function
List<int> seriouslyNotASquare = new List<int>();

for(int i = 0; i < wheresSquaredo.Count(); i++)
{
    if(Math.Sqrt(wheresSquaredo[i]) % 1 == 0)
    {
        break;
    }
    seriouslyNotASquare.Add(wheresSquaredo[i]);
}

// seriouslyNotASquare.ForEach(square => Console.WriteLine(square));


// Build a collection of customers who are millionaires

   
        List<Customer> customers = new List<Customer>() {
            new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
            new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
            new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
            new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
            new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
            new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
            new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
            new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
            new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
            new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
        };

        List<Customer> millionaires = customers.Where(customer => customer.Balance >= 1000000).ToList();

        millionaires.ForEach(singleMillionaire => Console.WriteLine(singleMillionaire.Name + " " + singleMillionaire.Balance + " " + singleMillionaire.Bank));

        /*
    Given the same customer set, display how many millionaires per bank.
    Ref: https://stackoverflow.com/questions/7325278/group-by-in-linq

    Example Output:
    WF 2
    BOA 1
    FTB 1
    CITI 1
*/
IEnumerable<IGrouping<string,Customer>> longGroupedMillionaires = (from customer in millionaires group customer by customer.Bank).ToList();

    IEnumerable<IGrouping<string,Customer>> groupedMillionaires = millionaires.GroupBy(singleMillionaire => singleMillionaire.Bank).ToList();
    
    // groupedMillionaires.ToList().ForEach(x => Console.WriteLine($"{x.Key} {x.Count()} "));

    longGroupedMillionaires.ToList().ForEach(x => Console.WriteLine($"{x.Key} {x.Count()} "));



