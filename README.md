# gr-homework

Readable, clean, unit-tested, simple, modular.

*Cleanliness note:* I didn't spend time on a proper .gitignore, sorry for the packages/debug files!

## Step 1 - Build a system to parse and sort a set of records

### High Level Requirements

Create a *command line app* that *takes as input a file* with a set of records in one of three formats described below,
and *outputs (to the screen) the set of records sorted* in one of three ways.

### Input

A record consists of the following *5 fields*: last name, first name, email, date of birth and favorite color.  
*The input is 3 files*, each containing records stored in a different format.  
You may generate these files yourself, and you can make certain assumptions if it makes solving your problem easier.  

- The *pipe-delimited file* lists each record as follows:
    - LastName | FirstName | Email | FavoriteColor | DateOfBirth
- The *comma-delimited file* looks like this:
    - LastName, FirstName, Email, FavoriteColor, DateOfBirth
- The *space-delimited file* looks like this:
    - LastName FirstName Email FavoriteColor DateOfBirth

You may assume that the *delimiters (commas, pipes and spaces) do not appear anywhere in the data values* themselves.

Write a program in a language of your choice to *read in records from these files* and *combine them into a single set of records*.

### Output

Create and *display 3 different views* of the data you read in:

- Output 1 – sorted by favorite color then by last name ascending.
- Output 2 – sorted by birth date, ascending.
- Output 3 – sorted by last name, descending.
- Display dates in the format M/D/YYYY.

### My Checklist (identified requirements)

1. Command line app
1. Takes as input a file
1. Outputs (to the screen) the set of records
1. Read records with 5 fields
1. Read records with 3 different formats
1. Combine them into a single set
1. Output
1. Sort 1
1. Sort 2
1. Sort 3
1. Format dates M/D/YYYY
1. Review for readability, cleanliness, unit-testedness, simplicty, modularity.

## Step 2 - Build a REST API to access your system

### High Level Requirements
Tests for this section are required as well.

Within the same code base, build a standalone REST API with the following endpoints:
- POST /records - Post a single data line in any of the 3 formats supported by your existing code
- GET /records/color - returns records sorted by favorite color
- GET /records/birthdate - returns records sorted by birthdate
- GET /records/name - returns records sorted by last name

It's your choice how you render the output from these endpoints as long as it well structured data. *These endpoints should return JSON*.
To keep it simple, *don't worry about using a persistent datastore*.

### My Tip
Use this PowerShell cmdlet to test: Invoke-WebRequest http://localhost:#####/records -Method POST -Body "Mouse Mickey mickey@disney.com Red 2/1/1910" -ContentType "text/plain"
