using System;
using System.IO;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        // Шлях до вхідного та вихідного файлів
        string inputFilePath = "input.txt";
        string outputFilePath = "output.txt";

        try
        {
            // Читання вмісту вхідного файлу
            string[] lines = File.ReadAllLines(inputFilePath);

            // Паттерн для пошуку IP-адрес у тексті
            string pattern = @"\b(?:\d{1,3}\.){3}\d{1,3}\b";

            // Змінна для підрахунку кількості знайдених IP-адрес
            int ipCount = 0;

            // Відкриття файлу для запису результату
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                // Ітерування по рядкам тексту
                foreach (string line in lines)
                {
                    // Пошук IP-адрес у поточному рядку
                    MatchCollection matches = Regex.Matches(line, pattern);

                    // Збільшення лічильника IP-адрес
                    ipCount += matches.Count;

                    // Заміна IP-адрес у поточному рядку за вказаними параметрами
                    string modifiedLine = Regex.Replace(line, pattern, ReplaceIpAddress);

                    // Запис модифікованого рядка у вихідний файл
                    writer.WriteLine(modifiedLine);
                }
            }

            // Вивід кількості знайдених IP-адрес
            Console.WriteLine($"Кількість знайдених IP-адрес: {ipCount}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Сталася помилка: {ex.Message}");
        }
    }

    // Метод для заміни IP-адреси за вказаними параметрами
    static string ReplaceIpAddress(Match match)
    {
        string ipAddress = match.Value;
        // Тут можна додати логіку для заміни IP-адреси, якщо потрібно
        return ipAddress; // Покищо повертаємо саму IP-адресу без змін
    }
}

//______________task2

using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        // Шлях до вхідного та вихідного файлів
        string inputFilePath = "input.txt";
        string outputFilePath = "output.txt";

        try
        {
            // Читання вмісту вхідного файлу
            string[] lines = File.ReadAllLines(inputFilePath);

            // Задана довжина слова, які ми шукаємо
            int desiredLength = 5; // Змініть це значення на бажану довжину слова

            // Вибір слів заданої довжини з усіх рядків тексту
            var wordsOfDesiredLength = lines
                .SelectMany(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries)) // Розділити рядок на слова
                .Where(word => word.Length == desiredLength); // Вибрати слова заданої довжини

            // Запис результатів у вихідний файл
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var word in wordsOfDesiredLength)
                {
                    writer.WriteLine(word);
                }
            }

            Console.WriteLine($"Слова довжини {desiredLength} були успішно записані у файл {outputFilePath}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Сталася помилка: {ex.Message}");
        }
    }
}

//______________________ task 3
using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        // Шлях до вхідного та вихідного файлів
        string inputFilePath = "input.txt";

        try
        {
            // Читання вмісту вхідного файлу
            string inputText = File.ReadAllText(inputFilePath);

            // Розділення тексту на слова за допомогою пробілів та розділових знаків
            string[] words = inputText.Split(new char[] { ' ', ',', '.', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            // Знаходження довжини найбільшого слова
            int maxLength = words.Max(word => word.Length);

            // Вилучення всіх слів найбільшої довжини з тексту
            string resultText = string.Join(" ", words.Where(word => word.Length < maxLength));

            // Вивід результату у консоль
            Console.WriteLine("Текст після вилучення слів найбільшої довжини:");
            Console.WriteLine(resultText);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Сталася помилка: {ex.Message}");
        }
    }
}

