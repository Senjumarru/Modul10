using System;
using System.Collections.Generic;

abstract class OrganizationComponent
{
    public abstract string GetName();
    public abstract double GetSalary();
    public abstract int GetEmployeeCount();
    public virtual void Add(OrganizationComponent component) { }
    public abstract void DisplayStructure(int indent = 0);
}

class Employee : OrganizationComponent
{
    private string name;
    private string position;
    private double salary;

    public Employee(string name, string position, double salary)
    {
        this.name = name;
        this.position = position;
        this.salary = salary;
    }

    public override string GetName() => name;
    public override double GetSalary() => salary;
    public override int GetEmployeeCount() => 1;

    public override void DisplayStructure(int indent = 0)
    {
        Console.WriteLine(new String(' ', indent) + $"{position}: {name} (Зарплата: {salary})");
    }
}

class Department : OrganizationComponent
{
    private string name;
    private List<OrganizationComponent> components = new List<OrganizationComponent>();

    public Department(string name)
    {
        this.name = name;
    }

    public override string GetName() => name;

    public override double GetSalary()
    {
        double totalSalary = 0;
        foreach (var component in components)
        {
            totalSalary += component.GetSalary();
        }
        return totalSalary;
    }

    public override int GetEmployeeCount()
    {
        int count = 0;
        foreach (var component in components)
        {
            count += component.GetEmployeeCount();
        }
        return count;
    }

    public override void Add(OrganizationComponent component)
    {
        components.Add(component);
    }

    public override void DisplayStructure(int indent = 0)
    {
        Console.WriteLine(new String(' ', indent) + "Отдел: " + name);
        foreach (var component in components)
        {
            component.DisplayStructure(indent + 2);
        }
    }
}

class Program
{
    static void Main()
    {
        var company = new Department("Корпорация");

        var itDept = new Department("ИТ-отдел");
        itDept.Add(new Employee("Alinur", "Программист", 3000));
        itDept.Add(new Employee("Bauka", "Тестировщик", 2500));

        var hrDept = new Department("HR-отдел");
        hrDept.Add(new Employee("Khngld", "Рекрутер", 2000));

        var subDept = new Department("Подотдел ИТ");
        subDept.Add(new Employee("Aisyn", "Младший разработчик", 1500));
        itDept.Add(subDept);

        company.Add(itDept);
        company.Add(hrDept);

        Console.WriteLine("Структура компании:");
        company.DisplayStructure();

        Console.WriteLine($"\nОбщий бюджет компании: {company.GetSalary()}");
        Console.WriteLine($"Общее количество сотрудников: {company.GetEmployeeCount()}");
    }
}
