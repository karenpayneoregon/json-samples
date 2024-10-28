# About

Example for removing `diacritics` from a string in C# using a custom `JsonConverter` in JsonHelperLibrary, `DiacriticsConverter`.

```csharp
List<Human> people =
[
    new() { FirstName = "María", LastName = "García" },
    new() { FirstName = "José", LastName = "Rodríguez" },
    new() { FirstName = "Luis", LastName = "González" },
    new() { FirstName = "Carlos", LastName = "Fernández" },
    new() { FirstName = "Andrés", LastName = "López" },
    new() { FirstName = "Manuel", LastName = "Sánchez" },
    new() { FirstName = "Francisco", LastName = "Pérez" },
    new() { FirstName = "Juan", LastName = "Gómez" },
    new() { FirstName = "Fernando", LastName = "Díaz" },
    new() { FirstName = "Sergio", LastName = "Hernández" },
    new() { FirstName = "Álvaro", LastName = "Alvarado" },
    new() { FirstName = "Diego", LastName = "Ramírez" }
];

string jsonString = JsonSerializer.Serialize(people, _options);
```

**Output**:

```json
[
	{ "FirstName": "Maria", "LastName": "Garcia" },
	{ "FirstName": "Jose", "LastName": "Rodriguez" },
	{ "FirstName": "Luis", "LastName": "Gonzalez" },
	{ "FirstName": "Carlos", "LastName": "Fernandez" },
	{ "FirstName": "Andres", "LastName": "Lopez" },
	{ "FirstName": "Manuel", "LastName": "Sanchez" },
	{ "FirstName": "Francisco", "LastName": "Perez" },
	{ "FirstName": "Juan", "LastName": "Gomez" },
	{ "FirstName": "Fernando", "LastName": "Diaz" },
	{ "FirstName": "Sergio", "LastName": "Hernandez" },
	{ "FirstName": "Alvaro", "LastName": "Alvarado" },
	{ "FirstName": "Diego", "LastName": "Ramirez" }
]
```
