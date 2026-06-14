using System;
using System.Collections.Generic;

class Application
{

    public string CompanyName { get;set;}
    public string Position { get;set;}
    public string Status { get;set;}

    public Application(string companyName,string position)
    {
        CompanyName = companyName;
        Position = position;
        Status = "Applied";
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

    static void Main()
    {
        List<Application> applications = new List<Application>();

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
                Console.WriteLine("Company Name:");
                string companyName = Console.ReadLine();

                Console.WriteLine("Position:");
                string position = Console.ReadLine();

                Application newApplication = new Application(companyName, position);
                applications.Add(newApplication);

                Console.WriteLine("Application added.");
                Console.WriteLine();
            }
            else if (choice == "2")
            {
                Console.WriteLine("Applications:");
                Console.WriteLine();

                foreach (Application application in applications)
                {
                    application.Print();

                }
            }
            else if (choice == "3")
            {
                Console.WriteLine("Which application number?");

                for (int i = 0; i < applications.Count; i++)
                {
                    Console.WriteLine(i + "-" + applications[i].CompanyName + "/" + applications[i].Position + "/" + applications[i].Status);
                    string indexText = Console.ReadLine();
                    int index = Convert.ToInt32(indexText);

                    Console.WriteLine("New Status");
                    string newStatus = Console.ReadLine();

                    applications[index].ChangeStatus(newStatus);
                    Console.WriteLine("Status changed");
                    Console.WriteLine();

                }
                }

                else if (choice == "4")
                {
                    Console.WriteLine("Which application do you want to delete?");

                    for (int i = 0; i < applications.Count; i++)
                    {
                        Console.WriteLine(i + " - " + applications[i].CompanyName + " / " + applications[i].Position + " / " + applications[i].Status);

                    }

                string indexText = Console.ReadLine();
                int index = Convert.ToInt32(indexText);

                applications.RemoveAt(index);
                Console.WriteLine("Application deleted");
                Console.WriteLine();

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