# OakTown Library Management System

A console-based library management system built in C# (.NET Framework) as part of a coursework assignment. The project models a small public library that tracks books, reference books, and magazines, supports borrowing/returning items, and includes a unit test suite.

## Overview

OakTown Library demonstrates core object-oriented programming principles:

- **Abstraction & inheritance** – `LibraryItem` is an abstract base class with `Book`, `ReferenceBook`, and `Magazine` as derived classes, each implementing its own borrowing cost calculation.
- **Encapsulation** – item state (availability, borrower) is managed through properties and methods rather than exposed directly.
- **Polymorphism** – borrowing cost and display logic vary per item type via method overriding.

## Features

- Browse a pre-loaded catalogue of books, reference books, and magazines
- Search items by title (keyword match) or exact ISBN
- Borrow and return items, with availability tracked per item
- Per-category borrowing cost calculation (e.g. reference books may be non-circulating)
- Member management

## Project Structure
OakTownLibrary/
├── OakTownLibrary/             # Main console application
│   ├── Book.cs
│   ├── ReferenceBook.cs
│   ├── Magazine.cs
│   ├── LibraryItem.cs          # Abstract base class
│   ├── Library.cs              # Core catalogue logic (search, sample data)
│   ├── Member.cs
│   └── Program.cs              # Entry point / console UI
└── OakTownLibraryTests/        # MSTest unit test project
    ├── BookTest.cs
    ├── MagazineTest.cs
    ├── ReferenceBookTest.cs
    └── LibraryTest.cs
## Tech Stack

- C# / .NET Framework
- MSTest for unit testing

## Running the Project

1. Open `OakTownLibrary/OakTownLibrary.sln` in Visual Studio.
2. Restore NuGet packages (Visual Studio will prompt automatically, or right-click the solution → Restore NuGet Packages).
3. Set `OakTownLibrary` as the startup project and run (F5).
4. To run the test suite, open Test Explorer and run all tests in `OakTownLibraryTests`.

## Author

Niduli — Computing student, coursework assignment.
