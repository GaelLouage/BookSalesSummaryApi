# 📚 Book Sales Summary Service API

This is a minimal ASP.NET Core Web API that provides sales analytics for a collection of books stored in a JSON file. The API reads book sales data and exposes endpoints for sales summary, top-selling books, and filtering options.

## 🚀 Features

- 📈 Get total sales, revenue, average order value
- 🏆 Find the most sold book
- 💰 Sort books by revenue
- 🔍 Filter books by quantity sold

## 🛠️ Tech Stack

- ASP.NET Core 7
- Minimal API
- Newtonsoft.Json for JSON parsing
- Dependency Injection using `IOptions<T>`
- C# 10 / .NET 7

---

## 📂 Project Structure

Infra/
├── Dtos/
├── Helpers/
├── Mappers/
├── Models/
├── Services/
└── Interfaces/
Program.cs
books.json


---

## 🧪 API Endpoints

| Route                    | Description                             |
|-------------------------|-----------------------------------------|
| `GET /GetSalesSummaryAsync` | Returns overall sales summary            |
| `GET /GetTopSellingBook`    | Returns the most sold book title         |
| `GET /SortByRevenue`        | Returns books sorted by revenue          |
| `GET /GetWhere?quantity=x`  | Returns books where copies sold ≤ x      |

---

## ⚙️ Configuration

Set your JSON file path in `appsettings.json`:

```json
"BookService": {
  "FilePath": "C:\\Path\\To\\books.json"
}

Make sure the file is accessible and contains valid book data.
Example books.json

[
  {
    "Title": "Clean Code",
    "Author": "Robert C. Martin",
    "CopiesSold": 1200,
    "UnitPrice": 29.99
  },
  {
    "Title": "The Pragmatic Programmer",
    "Author": "Andy Hunt",
    "CopiesSold": 950,
    "UnitPrice": 34.99
  }
]

▶️ How to Run

git clone https://github.com/your-username/BookSalesSummaryServiceApi.git
cd BookSalesSummaryServiceApi
dotnet run

Then navigate to: https://localhost:5001/swagger
