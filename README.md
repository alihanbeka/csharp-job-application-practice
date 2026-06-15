# C# Job Application Practice

This is a beginner-level C# console application created to practice core programming concepts through a simple job application tracking system.

The project is part of my learning path toward backend and full-stack development.

## Features

- Add a job application
- List all job applications
- Change application status using predefined status options
- Delete an application
- Search applications by company name
- Save applications to a text file
- Load saved applications when the program starts
- Store applied date for each application
- Validate user input when selecting an application
- Support older saved records without applied date

## Practiced Concepts

- Classes and objects
- Properties
- Constructors
- Constructor overloading
- List<T>
- foreach loops
- for loops
- while loops
- if / else conditions
- Methods
- File reading and writing
- String splitting with `Split`
- Basic CRUD logic
- Input validation with `int.TryParse`
- Simple backward compatibility for older file formats

## How It Works

The application keeps job applications in a `List<Application>` while the program is running.

Each application has:

- Company name
- Position
- Status
- Applied date

When data changes, the application saves the list to `applications.txt`.

Saved records use a simple text format:

```text
CompanyName|Position|Status|AppliedDate
```

When the program starts, it reads `applications.txt` and loads previous applications back into the list.

If an older saved record does not include an applied date, the application loads it with `Unknown` as the date.

## Menu

```text
1 - Add application
2 - List applications
3 - Change status
4 - Delete application
5 - Search by company
6 - Exit
```

## Status Options

```text
1 - Applied
2 - Interview
3 - Rejected
4 - Offer
5 - Waiting
```

## Example Saved Data

```text
Garanti|Backend Developer|Applied|16.06.2026
Insider|Junior Developer|Interview|16.06.2026
```

## Learning Purpose

This project helps me practice fundamental programming skills before moving into more advanced backend development topics.

The main goal is to understand:

- How to model data with classes
- How to store multiple objects in a list
- How to implement basic CRUD operations
- How to validate user input
- How to save and load data from a file
- How to split code into smaller methods

## Next Steps

- Prevent empty company and position input
- Improve file format using JSON
- Add application details view
- Convert this console logic into a .NET Web API
