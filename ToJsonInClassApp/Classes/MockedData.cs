using Bogus;

namespace ToJsonInClassApp.Classes;
public class MockedData
{
    public static List<Person> GetPeople(int count = 2)
    {
        var faker = new Faker<Person>()
            .RuleFor(p => p.Id, f => f.IndexFaker + 1)
            .RuleFor(p => p.FirstName, f => f.Name.FirstName())
            .RuleFor(p => p.LastName, f => f.Name.LastName())
            .RuleFor(p => p.BirthDate, f => DateOnly.FromDateTime(f.Date.Past(40, DateTime.Today.AddYears(-18))));

        return faker.Generate(count);
    }
}
