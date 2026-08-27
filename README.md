# Mediator Workshop

A small C# console application for the Mediator design-pattern workshop.

You will first work with aircraft that communicate directly. Then you will build a control tower that coordinates them as a Mediator.

## Requirements

Install the **.NET SDK**:

<https://dotnet.microsoft.com/download>

Check that it is installed:

```powershell
dotnet --version
```

## Clone the repository

Open PowerShell, Terminal, or Git Bash and run:

```bash
git clone https://github.com/Goglikooo/Mediator.git
cd Mediator
```

## Run the application

The C# project is inside the `Mediator` folder within the repository. From the repository root, run:

```bash
dotnet run --project .\Mediator\Mediator.csproj
```

Alternatively, enter the project folder first:

```bash
cd Mediator
dotnet run
```

The program runs as a console application. Its output appears in the terminal.

### Run with Visual Studio

1. Open the cloned repository in Visual Studio.
2. Open `Mediator.slnx` or the project folder.
3. Open `Mediator/Program.cs` if needed.
4. Start the application with the green **Start** button or press `Ctrl + F5`.

## Branches

The repository contains three branches. The spelling and capitalisation matter:

| Branch | Use it for |
|---|---|
| [`main`](https://github.com/Goglikooo/Mediator/tree/main) | First task: aircraft communicate without a Mediator. |
| [`SecondTask`](https://github.com/Goglikooo/Mediator/tree/SecondTask) | Second task: build the `ControlTower` Mediator. |
| [`Solution`](https://github.com/Goglikooo/Mediator/tree/Solution) | Complete reference solution. Use it after attempting the tasks. |

See the available branches with:

```bash
git branch -a
```

Switch to the first task:

```bash
git switch main
git pull origin main
```

Switch to the Mediator task:

```bash
git switch SecondTask
git pull origin SecondTask
```

Switch to the reference solution:

```bash
git switch Solution
git pull origin Solution
```

After switching branches, run the application again:

```bash
dotnet run --project .\Mediator\Mediator.csproj
```

## If Git cannot find a branch

Update your local list of branches:

```bash
git fetch --all --prune
```

Then try again. If necessary, create a local branch that tracks the remote branch:

```bash
git switch --track origin/SecondTask
```

For the solution branch:

```bash
git switch --track origin/Solution
```

## If Git says you have local changes

Commit or temporarily save your changes before switching branches. To temporarily save them:

```bash
git stash
```

Switch branches, then restore the changes later with:

```bash
git stash pop
```

## Quick start

```bash
git clone https://github.com/Goglikooo/Mediator.git
cd Mediator
git switch main
dotnet run --project .\Mediator\Mediator.csproj
```

Start with `main`, complete the first task, then switch to `SecondTask`. Use `Solution` only to compare your work after trying the exercises yourself.
