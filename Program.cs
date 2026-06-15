using System;
using System.Collections.Generic;
using System.IO;

class Application
{

    public string CompanyName { get;set;}
    public string Position { get;set;}
    public string Status { get;set;}

    public Application(string companyName, string position)
    {
        CompanyName = companyName;
        Position = position;
        Status = "Applied";
    }
    public Application(string companyName, string position, string status)
{
    CompanyName = companyName;
    Position = position;
    Status = status;
}

    public void Print()
    {
        Console.WriteLine("Company:" + CompanyName);
        Console.WriteLine("Position:" + Position);
        Console.WriteLine("Status:" + Status);
        Console.WriteLine("-----------------");
    }
    public void ChangeStatus(string newStatus)
    {
        Status = newStatus;


    }
}
class Program
{

    static void DeleteApplication(List<Application> applications)
    {
        int index = ReadApplicationIndex(applications);

        if (index == -1)
        {
            return;
        }

        applications.RemoveAt(index);
        SaveApplications(applications);

        Console.WriteLine("Application deleted.");
        Console.WriteLine();
    }
    static void ChangeApplicationStatus(List<Application> applications)
    {
        int index = ReadApplicationIndex(applications);
        if (index == -1)
        {
            return;

        }
        Console.WriteLine("New Status;");
        string newStatus = Console.ReadLine();
        applications[index].ChangeStatus(newStatus);
        SaveApplications(applications);

        Console.WriteLine("Status changed.");
        Console.WriteLine();

    }
    static void ListApplication(List<Application> applications)
    {
        if (applications.Count == 0)
        {
            Console.WriteLine("No applications found.");
            Console.WriteLine();
            return;
        }
        Console.WriteLine("Applications:");
        Console.WriteLine();

        foreach (Application application in applications)
        {
            application.Print();
        }

    }
    static void AddApplication(List<Application>applications)
    {
        Console.WriteLine("Company Name:");
        string companyName = Console.ReadLine();

        Console.WriteLine("Position:");
        string position = Console.ReadLine();

        Application newApplication = new Application(companyName, position);
        applications.Add(newApplication);
        SaveApplications(applications);

        Console.WriteLine("Application added.");
        Console.WriteLine();

    }
    static int ReadApplicationIndex(List<Application> applications)
    {
        if (applications.Count == 0)
        {
            Console.WriteLine("No applications found.");
            return -1;

        }
        while(true)
        {
            Console.WriteLine("Which application number");
            for (int i = 0; i < applications.Count; i++)
            {
                Console.WriteLine(i + "-" + applications[i].CompanyName + "/" + applications[i].Position + "/" + applications[i].Status);

            }
            string indexText = Console.ReadLine();
            bool isNumber = int.TryParse(indexText, out int index);
            if (isNumber == false)
            {
                Console.WriteLine("Please enter a valid number.");
                Console.WriteLine();
                continue;
            }

            if (index < 0 || index >= applications.Count) 
            {
                Console.WriteLine("Application number is out of range.");
                Console.WriteLine();
                continue;
            }
            return index;
            
        }
    }
    
    static List<Application> LoadApplications()
    {
        List<Application> applications = new List<Application>();

        if (File.Exists("applications.txt"))
        {
            string[] lines = File.ReadAllLines("applications.txt");

            foreach (string line in lines)
            {
                string[] parts = line.Split('|');

                string companyName = parts[0];
                string position = parts[1];
                string status = parts[2];

                Application application = new Application(companyName, position, status);
                applications.Add(application);
            }
        }

        return applications;
    }


    static void SaveApplications(List<Application> applications)
    {
        List<string> lines = new List<string>();

        foreach(Application application in applications)
        {
            string line = application.CompanyName + "|" + application.Position + "|" + application.Status;
            lines.Add(line);

        }

        File.WriteAllLines("applications.txt",lines);
    }

    static void Main()
    {
        List<Application> applications = LoadApplications();

        bool isRunning = true;
        while (isRunning)
        {
            Console.WriteLine("1 - Add application");
            Console.WriteLine("2 - List applications");
            Console.WriteLine("3 - Change status");
            Console.WriteLine("4 - Delete application");
            Console.WriteLine("5 - Exit");
            Console.WriteLine("Choose an option:");

            string choice = Console.ReadLine();
            if (choice == "1")
            {
                AddApplication(applications);
            }
            else if (choice == "2")
            {
                ListApplication(applications);
            }
            else if (choice == "3")
            {
                ChangeApplicationStatus(applications);

            }

            else if (choice == "4")
            {

                DeleteApplication(applications);
            }


           
            else if (choice == "5")
            {
                isRunning = false;

            }
            else
            {
                Console.WriteLine("Invalid option");
                Console.WriteLine();
            }

        }
     
    }



}