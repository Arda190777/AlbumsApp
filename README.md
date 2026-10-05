# AlbumsApp

**A music album catalogue built with ASP.NET Core MVC.**

A compact C# project demonstrating MVC request handling, Razor views, model validation and dependency injection through an album-service interface.

## Features

- Browse a seeded music album collection.
- Filter albums by genre and inspect album details.
- Add an album with validated title, artist, year, genre and cover information.
- Display a randomly selected featured album.
- Show feedback after creating an album.

**Stack:** .NET 8 · C# · ASP.NET Core MVC · Razor · In-memory repository

## Run locally

Install the .NET 8 SDK.

```powershell
git clone https://github.com/Arda190777/AlbumsApp.git
cd AlbumsApp
dotnet restore AlbumsApp.sln
dotnet run --project AlbumsApp/AlbumsApp.csproj
```

Open the localhost URL printed by ASP.NET. Cover images use external URLs and need network access.

## Build

```powershell
dotnet build AlbumsApp.sln
```

No automated test project is currently included.

## Design

`IAlbumService` defines catalogue operations and `AlbumRepository` implements them using a singleton in-memory list. The controller depends on the interface, and Razor views render the resulting models.

| Directory | Responsibility |
| --- | --- |
| `AlbumsApp/Controllers` | Catalogue routes and form handling |
| `AlbumsApp/Models` | Album, genre and form/view models |
| `AlbumsApp/Services` | Service interface and in-memory implementation |
| `AlbumsApp/Views` | Server-rendered pages |

Added albums disappear when the process restarts. Database persistence, authentication and production deployment are outside the current scope. This portfolio/learning project does not include a standalone license file.
