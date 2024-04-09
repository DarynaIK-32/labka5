/*Створити суперклас Персона підкласи Студент, Студент бюджету, Студент контракту, 
 * Студент заочки. Подумати, які з вищенаведених підкласів також можуть бути суперкласами.  
 * За допомогою конструктора задати курс навчання персони. Визначити, чи отримує студент стипендію. 
 * Визначити вартість навчання на контракті та кількість пар в тиждень. Вивести дату початку сесії.*/

using System;

abstract class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }

    public Person(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }

    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Iм'я: {FirstName} {LastName}, Вiк: {Age}");
    }
}

class Student : Person
{
    public int Course { get; set; }

    public Student(string firstName, string lastName, int age, int course) : base(firstName, lastName, age)
    {
        Course = course;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Курс: {Course}");
    }
}

class BudgetStudent : Student
{
    public bool HasScholarship { get; set; }

    public BudgetStudent(string firstName, string lastName, int age, int course, bool hasScholarship) : base(firstName, lastName, age, course)
    {
        HasScholarship = hasScholarship;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Стипендiя: {HasScholarship}");
    }
}

class ContractStudent : Student
{
    public decimal TuitionFee { get; set; }
    public int WeeklyClasses { get; set; }

    public ContractStudent(string firstName, string lastName, int age, int course, decimal tuitionFee, int weeklyClasses) : base(firstName, lastName, age, course)
    {
        TuitionFee = tuitionFee;
        WeeklyClasses = weeklyClasses;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Цiна навчання у грн.: {TuitionFee}, Занять на тиждень: {WeeklyClasses}");
    }
}

class DistanceStudent : Student
{
    public DateTime SessionStartDate { get; set; }

    public DistanceStudent(string firstName, string lastName, int age, int course, DateTime sessionStartDate) : base(firstName, lastName, age, course)
    {
        SessionStartDate = sessionStartDate;
    }

    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine($"Початок сесii: {SessionStartDate.ToString("dd.MM.yyyy")}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Student student = new Student("Сiкорський", "Данило", 20, 2);
        student.DisplayInfo();

        BudgetStudent budgetStudent = new BudgetStudent("Безсмертна", "Алiна", 21, 3, true);
        budgetStudent.DisplayInfo();

        ContractStudent contractStudent = new ContractStudent("Крупська", "Софiя", 22, 4, 45000, 12);
        contractStudent.DisplayInfo();

        DistanceStudent distanceStudent = new DistanceStudent("Шевчук", "Олександр", 23, 1, new DateTime(2024, 6, 10));
        distanceStudent.DisplayInfo();
    }
}
