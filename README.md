# 📚 Migs.EnumMetadata

A lightweight C# library for extending enums with custom metadata properties.

## 📝 Description

This library allows you to attach additional metadata to enum values, enabling richer functionality and easier integration with other systems. 
It supports `.NET Standard 2.0`, `.NET 6.0`, and `.NET 8.0`.

## ✨ Features

- **Extend enums** with custom properties (e.g., descriptions, colors, or any custom data).
- **Type-safe** access to metadata.
- **Easy integration** with existing projects.
- **Multi-targeted** for `.NET Standard 2.0`, `.NET 6.0`, and `.NET 8.0`.

## 🛠️ Prerequisites

- .NET SDK (6.0 or 8.0) or a compatible IDE (Visual Studio, Rider, etc.).

## 📦 Installation

1. Clone the repository:
  ```bash
   git clone https://github.com/migs81/Migs.EnumMetadata.git
  ```
2. Navigate to the project directory:
  ```bash
   cd Migs.EnumMetadata
  ```
3. Restore dependencies:
  ```bash
   dotnet restore
  ```
4. Build the project:
  ```bash
   dotnet build
  ```

## 🚀 Usage

### 1. Define an Enum with Metadata

```csharp
public enum SortOrder
{
    [EnumMetadata(name: "Ascending", description: "Ascending sort order")]
    Asc,

    [Metadata("Descending", "Descending sort order")]
    Desc,
}
```

### 2. Access Metadata

```csharp
var sortOrder = SortOrder.Asc.GetAttribute<EnumMetadataAttribute>();
Console.WriteLine(sortOrder.Name); // Output: "Ascending"
Console.WriteLine(sortOrder.Description); // Output: "Ascending sort order"
```

### 3. Create custom attribute

```csharp

public class ColorAttribute : EnumMetadataAttribute
{
    public string Code { get; }

    public ColorAttribute(string name, string description, string code) : base(name, description)
    {
        Code = code ?? throw new ArgumentNullException(nameof(code));
    }
}
```
```csharp

public enum Colors
{
    [Color(name: "Cornflower blue", description: "Shade of medium-to-light blue", code: "#6495ED")]
    CornflowerBlue = 0,

    [Color(name: "Crimson red", description: "Rich, deep red color, inclining to purple. ", code: "#990000")]
    CrimsonRed,
}
```

### 4. Access custom attribute

```csharp

var cornflowerBlue = Color.CornflowerBlue.GetAttribute<ColorAttribute>();
Console.WriteLine(cornflowerBlue.Name); // Output: "Cornflower blue"
Console.WriteLine(cornflowerBlue.Description); // Output: "Shade of medium-to-light blue"
Console.WriteLine(cornflowerBlue.Code); // Output: "#6495ED"
```

## 📊 Benchmarks

This project includes a benchmark project to measure the performance of the library. 
You can find it in the `benchmarks/` folder.

### Running Benchmarks

1. Navigate to the benchmark project:
  ```bash
   cd benchmarks/Migs.EnumMetadata
  ```
2. Run the benchmarks using [BenchmarkDotNet](https://benchmarkdotnet.org/):
  ```bash
   dotnet run -c Release
  ```

## 📂 Project Structure

```
Migs.EnumMetadata/
├── src/
│   ├── Migs.EnumMetadata/              # Core library
├── benchmarks/                       
│   └── Migs.EnumMetadata.Benchmarks    # Benchmarks
├── tests/                       
│   └── Migs.EnumMetadata.Tests         # Unit tests
└── README.md                           # This file
```

## 🤝 Contributing

Contributions are welcome! Please open an issue or submit a pull request.

## 📄 License

This project is licensed under the [MIT License](LICENSE).

