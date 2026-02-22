# CleanArch — Backend Template

A personal .NET backend template built to avoid rewriting the same boilerplate every time. Clean Architecture, JWT auth, PostgreSQL. Not perfect, works.

Feel free to clone it, rename it, and build on top of it.

---

## Stack

- **.NET 10** — ASP.NET Core Web API
- **PostgreSQL** — via Npgsql + EF Core
- **JWT** — authentication with BCrypt password hashing
- **Docker** — Postgres runs locally via Docker Compose

---

## Project Structure

```
CleanArch.Domain          — entities, nothing else, no dependencies
CleanArch.Application     — interfaces, use cases, DTOs
CleanArch.Infrastructure  — EF Core, repositories, external services (email, PDF, tokens, etc.)
CleanArch.Api             — controllers, middleware, entry point
```

Dependencies only point inward. Domain knows nothing, Api knows everything.

---

## Using as a Template

This repo includes a `dotnet new` template. Clone it once, install it locally, and reuse it anywhere on your machine with automatic renaming — no manual find & replace needed.

### 1. Clone and install

```bash
git clone https://github.com/MihajloSremac/dotnet-clean-arch-template.git
dotnet new install ./CleanArch-BE
```

### 2. Use it anywhere

```bash
dotnet new cleanarch -n MyProject -o MyProject
```

This creates a new folder called `MyProject` with all namespaces, filenames, and references already renamed from `CleanArch` to `MyProject`.

### Uninstall

```bash
dotnet new uninstall CleanArch.Template
```

---

## Getting Started

### 1. Database

Start the local PostgreSQL instance with Docker:

```bash
docker-compose up -d
```

### 2. Secrets

The app needs a connection string and JWT settings. These should **never** go in `appsettings.json` — use your IDE's built-in user secrets manager instead.

- **Rider** — right click the Api project → Tools → .NET User Secrets
- **Visual Studio** — right click the Api project → Manage User Secrets

Your secrets file should look like this:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=yourdb;Username=youruser;Password=yourpassword"
  },
  "JwtSettings": {
    "Secret": "your_random_32+_char_secret",
    "Issuer": "CleanArch",
    "Audience": "CleanArchUsers",
    "ExpiryMinutes": 60
  }
}
```

### 3. Migrations

```bash
dotnet ef migrations add InitialCreate --project CleanArch.Infrastructure --startup-project CleanArch.Api
dotnet ef database update --project CleanArch.Infrastructure --startup-project CleanArch.Api
```

### 4. Run

```bash
dotnet run --project CleanArch.Api
```

Use [Postman](https://www.postman.com) or any HTTP client to test the endpoints. For protected routes, get a token from `/api/auth/login` and pass it as a `Bearer` token in the `Authorization` header.

**Auth** — `POST /api/auth/register` · `POST /api/auth/login`

**Users** — `POST /api/users` · `PUT /api/users` · `GET /api/users/{id}` · `GET /api/users/by-email?email=`

Register and login are the only public endpoints. 

---

## Notes

- CORS is fully open by default — lock it down to your frontend URL before going to production
- `appsettings.json` only holds structure and safe placeholders, real values go in user secrets locally and environment variables in production
