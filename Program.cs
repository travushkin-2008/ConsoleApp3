using System;
using System.Collections.Generic;
using System.Linq;

// описание класса FootballTeam
class FootballTeam
{
    public string Name { get; set; }  // Название команды
    public string Coach { get; set; } // Тренер
    public int Points { get; set; }   // Количество набранных очков
    public int Place { get; set; }    // Текущее место таблицы
}

class Program
{
    static void Main(string[] args)
    {
        // создаем коллекцию объектов FootballTeam
        List<FootballTeam> teams = new List<FootballTeam>();

        // заносим объекты в коллекцию
        teams.Add(new FootballTeam()
        {
            Name = "Метеор",
            Coach = "Иванов",
            Points = 12,
            Place = 10
        });
        teams.Add(new FootballTeam()
        {
            Name = "Вымпел",
            Coach = "Петров",
            Points = 16,
            Place = 7
        });
        teams.Add(new FootballTeam()
        {
            Name = "Комета",
            Coach = "Сидоров",
            Points = 25,
            Place = 1
        });
        teams.Add(new FootballTeam()
        {
            Name = "Арсенал",
            Coach = "Григорьев",
            Points = 22,
            Place = 4
        });
        teams.Add(new FootballTeam()
        {
            Name = "Буровик",
            Coach = "Дорогин",
            Points = 18,
            Place = 6
        });

        Show(teams, "Начальное содержание");

        // вставляем перед объектом с Названием = Комета новый объект
        int cometIndex = teams.FindIndex(t => t.Name == "Комета");
        if (cometIndex != -1)
        {
            teams.Insert(cometIndex, new FootballTeam()
            {
                Name = "Звезда",
                Coach = "Тетерин",
                Points = 14,
                Place = 9
            });
        }
        Show(teams, "Вставлена команда Звезда перед Кометой");

        // ищем в коллекции объект с индексом 2 (ID = 2) и удаляем его
        if (teams.Count > 2)
        {
            FootballTeam teamToRemove = teams[2];
            teams.Remove(teamToRemove);
            Show(teams, "Удален объект с индексом 2");
        }

        // ищем в коллекции все объекты, у которых очки >= 18
        List<FootballTeam> winners = teams.FindAll(x => x.Points >= 18);
        Show(winners, "Команды с очками >= 18 (Winners)");

        // сортировка объектов коллекции по названию
        teams.Sort(CompareName);
        Show(teams, "Сортировка по названию");

        // сортировка объектов коллекции по текущему месту
        teams.Sort(ComparePlace);
        Show(teams, "Сортировка по месту");

        // Упорядочить все объекты коллекции по свойствам Название и Текущее место
        var sortedTeams = teams.OrderBy(t => t.Name).ThenBy(t => t.Place).ToList();
        ShowCustom(sortedTeams, "Сортировка по Названию и Месту (LINQ)");

        Console.ReadKey();
    }

    // метод – показывает свойства объектов коллекции
    static void Show(List<FootballTeam> col, string comment)
    {
        Console.Write("//////////////");
        Console.Write(" " + comment + " ");
        Console.WriteLine("//////////////");
        // цикл по объектам коллекции
        foreach (FootballTeam team in col)
        {
            Console.Write($"Индекс = {col.IndexOf(team)}; ");
            Console.WriteLine($"Команда: {team.Name}, Тренер: {team.Coach}, Очки: {team.Points}, Место: {team.Place}");
        }
        Console.WriteLine();
    }

    // метод для вывода с использованием LINQ сортировки
    static void ShowCustom(List<FootballTeam> col, string comment)
    {
        Console.Write("//////////////");
        Console.Write(" " + comment + " ");
        Console.WriteLine("//////////////");
        // цикл по объектам коллекции
        foreach (FootballTeam team in col)
        {
            Console.WriteLine($"Команда: {team.Name}, Тренер: {team.Coach}, Очки: {team.Points}, Место: {team.Place}");
        }
        Console.WriteLine();
        Console.WriteLine("Работу выполнил Травушкин Степан 23ИС");
    }

    // метод сравнения объектов класса FootballTeam по месту:
    static int ComparePlace(FootballTeam t1, FootballTeam t2)
    {
        if (t1.Place < t2.Place) return -1;
        if (t1.Place == t2.Place) return 0;
        else return 1;
    }

    // метод сравнения объектов класса FootballTeam по алфавиту названий:
    static int CompareName(FootballTeam t1, FootballTeam t2)
    {
        // используем стандартный метод сравнения строк по алфавиту
        int n = t1.Name.CompareTo(t2.Name);
        return n;
    }
    
}



