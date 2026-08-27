Mediator Workshop

Small C# console project for the Mediator design-pattern workshop.

The example uses aircraft, a runway, and a control tower. You will first work with aircraft that communicate directly, and then build the control tower as a Mediator.

Requirements

Install the .NET SDK on your computer:

https://dotnet.microsoft.com/download

Check that it is installed:

dotnet --version

Clone the repository

Open PowerShell, Terminal, or Git Bash and run:

git clone <REPOSITORY-URL>
cd Mediator

Replace <REPOSITORY-URL> with the HTTPS URL of this GitHub repository. You can copy it from the green Code button on GitHub.

For example:

git clone https://github.com/your-name/Mediator.git
cd Mediator

Run the project locally

From the repository folder, run:

dotnet run

The project is a C# console application. The result will appear directly in the terminal.

If you use Visual Studio instead:

Open the repository folder or the solution file.

Open Program.cs.

Run the project with the green Start button or press Ctrl + F5.

Workshop branches

This repository contains three branches:

Branch

Purpose

main

Starting point: aircraft communicate directly without a Mediator. Complete the first exercise here.

secondTask

Second exercise: build the ControlTower Mediator.

solution

Complete reference implementation for checking your work.

Switch to a branch

First, see all available local and remote branches:

git branch -a

Switch to the first task:

git switch main
git pull origin main

Switch to the Mediator task:

git switch secondTask
git pull origin secondTask

Switch to the complete solution:

git switch solution
git pull origin solution

If your Git version does not support git switch, use git checkout instead:

git checkout secondTask

After changing branches, run the code again:

dotnet run

Important note about the solution

The solution branch is for checking your work after attempting the exercise. Try to solve the task first, then compare your code with the solution.

If you receive a project or branch error

Make sure you are inside the repository folder:

pwd

On PowerShell, you can also run:

Get-Location

You should see the folder containing the project files, including Program.cs and the .csproj file.

If the project was cloned but the branch list is not up to date, run:

git fetch --all

Then try switching branches again.

Quick start

git clone <REPOSITORY-URL>
cd Mediator
git switch main
dotnet run

Start with main, complete the first task, then switch to secondTask. Use solution only to compare your implementation.
