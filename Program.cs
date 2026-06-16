using System;
using System.Collections.Generic;
using System.IO;

class Application
{

    public string CompanyName { get;set;}
    public string Position { get;set;}
    public string Status { get;set;}
    public string AppliedDate { get; set; }

    public Application(string companyName, string position)
    {
        CompanyName = companyName;
        Position = position;
        Status = "Applied";
        AppliedDate = DateTime.Now.ToShortDateString();

    }
    public Application(string companyName, string position, string status, string appliedDate)
    {
        CompanyName = companyName;
        Position = position;
        Status = status;
        AppliedDate = appliedDate;
    }

    public void Print()
    {
        Console.WriteLine("Company:" + CompanyName);
        Console.WriteLine("Position:" + Position);
        Console.WriteLine("Status:" + Status);
        Console.WriteLine("Applied Date:" + AppliedDate);
        Console.WriteLine("-----------------");
    }
    public void ChangeStatus(string newStatus)
    {
        Status = newStatus;


    }
}
class Program
{
    static void SearchByPosition(List<Application> applications)
    {
        if (applications.Count == 0)
        {
            Console.WriteLine("No applications found.");
            Console.WriteLine();
            return;
        }

        string searchText = ReadRequiredText("Position search:");
        if (searchText == null)
        {
            return;
        }
        bool found = false;

        foreach (Application application in applications)
        {
            if (application.Position.ToLower().Contains(searchText.ToLower()))
            {
                application.Print();
                found = true;
            }
        }

        if (found == false)
        {
            Console.WriteLine("No matching applications found.");
            Console.WriteLine();
        }
    }
    static string ReadRequiredText(string message)
    {
        while (true)
        {
            Console.WriteLine(message + " (B - Back to menu)");
            string value = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("This field is required");
                Console.WriteLine();
                continue;
            }

            if (value.Trim().ToLower() == "b")
            {
                return null;
            }

            return value.Trim();
        }
    }

    static void SearchByCompany(List<Application> applications)
    {
        if (applications.Count == 0)
        {
            Console.WriteLine("No applications found.");
            Console.WriteLine();
            return;
        }
        string searchText = ReadRequiredText("Company search:");
        if (searchText == null)
        {
            return;
        }
        bool found = false;

        foreach (Application application in applications)
        {
            if(application.CompanyName.ToLower().Contains(searchText.ToLower()))
            {
                application.Print();
                found = true;

            }
        }
        if (found == false)
        {
            Console.WriteLine("No matching applications found.");
            Console.WriteLine();
        }
    }
    static string ReadStatus()
    {
        while (true)
        {
            Console.WriteLine("Choose new status:");
            Console.WriteLine("1 - Applied");
            Console.WriteLine("2 - Interview");
            Console.WriteLine("3 - Rejected");
            Console.WriteLine("4 - Offer");
            Console.WriteLine("5 - Waiting");
            Console.WriteLine("B - Back to menu");
            
            string choice= Console.ReadLine();
            if (choice == "1")
            {
                return "Applied";

            }
            else if (choice == "2")
            {
                return "Interview";

            }
            else if (choice == "3")
            {
                return "Rejected";
            }
            else if (choice == "4")
            {
                return "Offer";
            }
            else if (choice == "5")
            {
                return "Waiting";
            }
            else if (choice.Trim().ToLower() == "b")
            {
                return null;
            }
            else
            {
                Console.WriteLine("Invalid status option.");
                Console.WriteLine();
            }

        }

    }
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
        string newStatus = ReadStatus();
        if (newStatus == null)
        {
            return;
        }
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
        string companyName = ReadRequiredText("Company Name:");
        if (companyName == null)
        {
            return;
        }
        string position = ReadRequiredText("Position:");
        if (position == null)
        {
            return;
        }

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
            Console.WriteLine("Which application number (B - Back to menu)");
            for (int i = 0; i < applications.Count; i++)
            {
                Console.WriteLine(i + "-" + applications[i].CompanyName + "/" + applications[i].Position + "/" + applications[i].Status);

            }
            string indexText = Console.ReadLine();
            if (indexText.Trim().ToLower() == "b")
            {
                return -1;
            }
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

                if (parts.Length == 3)
                {
                    string companyName = parts[0];
                    string position = parts[1];
                    string status = parts[2];
                    string appliedDate = "Unknown";

                    Application application = new Application(companyName, position, status, appliedDate);
                    applications.Add(application);
                }
                else if (parts.Length == 4)
                {
                    string companyName = parts[0];
                    string position = parts[1];
                    string status = parts[2];
                    string appliedDate = parts[3];

                    Application application = new Application(companyName, position, status, appliedDate);
                    applications.Add(application);
                }
            }
        }

        return applications;
    }


    static void SaveApplications(List<Application> applications)
    {
        List<string> lines = new List<string>();

        foreach(Application application in applications)
        {
            string line = application.CompanyName + "|" + application.Position + "|" + application.Status +"|" + application.AppliedDate;
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
            Console.WriteLine("5 - Search by company");
            Console.WriteLine("6 - Search by position");
            Console.WriteLine("7 - Exit");
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
                SearchByCompany(applications);
            }
            else if (choice == "6")
            {
                SearchByPosition(applications);
            }
            else if (choice == "7")
            {
                isRunning = false;
            }
            else
            {
                Console.WriteLine("Invalid option.");
                Console.WriteLine();
            }

        }
        }



}
