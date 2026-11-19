
using System;
using System.Collections.Generic;
using System.Linq;

// ==========================================
// 1. MODELS
// ==========================================

var students = new List<Student>
{
    new(1, "Ali", 21),
    new(2, "Reza", 24),
    new(3, "Sara", 22),
    new(4, "Mina", 19),
    new(5, "Amir", 25),
    new(6, "Neda", 20),
    new(7, "Hassan", 23),
    new(8, "Zahra", 21)
};

var courses = new List<Course>
{
    new(1, "C#"),
    new(2, "ASP.NET Core"),
    new(3, "SQL Server"),
    new(4, "Docker"),
    new(5, "Python")
};

var enrollments = new List<Enrollment>
{
    new(1, 1, 18),
    new(1, 2, 19),
    new(2, 1, 15),
    new(2, 3, 17),
    new(3, 2, 20),
    new(3, 3, 18),
    new(4, 1, 12),
    new(5, 1, 19),
    new(5, 2, 17),
    new(5, 4, 20),
    new(6, 3, 16),
    new(7, 2, 14)
};

// Helper method for printing results
void Print<T>(string title, IEnumerable<T> items)
{
    Console.WriteLine($"\n--- {title} ---");

    foreach (var item in items)
        Console.WriteLine(item);
}

void Section(string title)
{
    Console.WriteLine($"\n\n========== {title} ==========");
}

// ==========================================
// 2. WHERE - FILTERING
// ==========================================

Section("WHERE");

var adults = students.Where(s => s.Age >= 21);

Print("Students older than or equal to 21", adults);

// Multiple conditions
var result1 = students.Where(s =>
    s.Age >= 21 && s.Name.StartsWith("A"));

Print("Multiple conditions", result1);

// Where with index
var result2 = students.Where((student, index) => index % 2 == 0);

Print("Where with index", result2);


// ==========================================
// 3. SELECT - PROJECTION
// ==========================================

Section("SELECT");

// Select a single property
var names = students.Select(s => s.Name);

Print("Student names", names);

// Select multiple properties
var studentInfo = students.Select(s => new
{
    s.Name,
    s.Age
});

Print("Student information", studentInfo);

// Transform data
var formattedNames = students.Select(s =>
    $"{s.Name} - {s.Age} years old");

Print("Formatted names", formattedNames);

// Select with index
var numberedStudents = students.Select((s, index) =>
    $"{index + 1}. {s.Name}");

Print("Numbered students", numberedStudents);


// ==========================================
// 4. ORDERING
// ==========================================

Section("ORDERING");

// Ascending
var orderedByAge = students.OrderBy(s => s.Age);

Print("Order by age", orderedByAge);

// Descending
var orderedByAgeDesc = students.OrderByDescending(s => s.Age);

Print("Order by age descending", orderedByAgeDesc);

// Multiple sorting
var multipleSorting = students
    .OrderBy(s => s.Age)
    .ThenBy(s => s.Name);

Print("Order by age and then name", multipleSorting);

// Reverse
Print("Reverse", students.AsEnumerable().Reverse());


// ==========================================
// 5. FIRST, LAST, SINGLE
// ==========================================

Section("ELEMENT OPERATORS");

// First
var firstStudent = students.First();

Console.WriteLine($"First: {firstStudent}");

// First with condition
var firstAdult = students.First(s => s.Age >= 24);

Console.WriteLine($"First adult: {firstAdult}");

// FirstOrDefault
var unknownStudent = students.FirstOrDefault(s => s.Id == 100);

Console.WriteLine($"Not found: {unknownStudent?.Name ?? "Not found"}");

// Last
var lastStudent = students.Last();

Console.WriteLine($"Last: {lastStudent}");

// LastOrDefault
var lastAdult = students.LastOrDefault(s => s.Age >= 24);

Console.WriteLine($"Last adult: {lastAdult}");

// Single
var student = students.Single(s => s.Id == 1);

Console.WriteLine($"Single: {student}");

// SingleOrDefault
var studentOrDefault = students.SingleOrDefault(s => s.Id == 100);

Console.WriteLine($"SingleOrDefault: {studentOrDefault}");

// ElementAt
var thirdStudent = students.ElementAt(2);

Console.WriteLine($"Third student: {thirdStudent}");

// ElementAtOrDefault
var missingStudent = students.ElementAtOrDefault(100);

Console.WriteLine($"Missing student: {missingStudent}");


// ==========================================
// 6. ANY, ALL, CONTAINS
// ==========================================

Section("QUANTIFIERS");

bool hasAdult = students.Any(s => s.Age >= 25);

Console.WriteLine($"Has student age >= 25: {hasAdult}");

bool allAdults = students.All(s => s.Age >= 18);

Console.WriteLine($"All students are adults: {allAdults}");

bool containsAli = students.Select(s => s.Name).Contains("Ali");

Console.WriteLine($"Contains Ali: {containsAli}");


// ==========================================
// 7. AGGREGATION
// ==========================================

Section("AGGREGATION");

int count = students.Count();

Console.WriteLine($"Count: {count}");

int adultCount = students.Count(s => s.Age >= 21);

Console.WriteLine($"Adult count: {adultCount}");

int totalAge = students.Sum(s => s.Age);

Console.WriteLine($"Total age: {totalAge}");

double averageAge = students.Average(s => s.Age);

Console.WriteLine($"Average age: {averageAge}");

int minAge = students.Min(s => s.Age);

Console.WriteLine($"Min age: {minAge}");

int maxAge = students.Max(s => s.Age);

Console.WriteLine($"Max age: {maxAge}");


// ==========================================
// 8. DISTINCT, UNION, INTERSECT, EXCEPT
// ==========================================

Section("SET OPERATORS");

var numbers1 = new List<int> { 1, 2, 3, 4, 5, 5 };
var numbers2 = new List<int> { 4, 5, 6, 7, 8 };

// Distinct
Print("Distinct", numbers1.Distinct());

// Union: combine without duplicates
Print("Union", numbers1.Union(numbers2));

// Intersect: common elements
Print("Intersect", numbers1.Intersect(numbers2));

// Except: elements in first but not second
Print("Except", numbers1.Except(numbers2));

// Concat: combine including duplicates
Print("Concat", numbers1.Concat(numbers2));


// ==========================================
// 9. SKIP, TAKE, PAGINATION
// ==========================================

Section("PAGINATION");

var firstThree = students.Take(3);

Print("Take 3", firstThree);

var skipThree = students.Skip(3);

Print("Skip 3", skipThree);

// Pagination
int pageNumber = 2;
int pageSize = 3;

var pagedStudents = students
    .Skip((pageNumber - 1) * pageSize)
    .Take(pageSize);

Print("Page 2", pagedStudents);

// TakeWhile
var takeWhile = students.TakeWhile(s => s.Age < 25);

Print("TakeWhile age < 25", takeWhile);

// SkipWhile
var skipWhile = students.SkipWhile(s => s.Age < 25);

Print("SkipWhile age < 25", skipWhile);


// ==========================================
// 10. GROUP BY
// ==========================================

Section("GROUP BY");

// Group students by age
var groupedByAge = students.GroupBy(s => s.Age);

foreach (var group in groupedByAge)
{
    Console.WriteLine($"\nAge: {group.Key}");

    foreach (var s in group)
        Console.WriteLine(s.Name);
}

// Group by age and calculate count
var ageStatistics = students
    .GroupBy(s => s.Age)
    .Select(g => new
    {
        Age = g.Key,
        Count = g.Count()
    });

Print("Age statistics", ageStatistics);

// Group enrollments by course
var courseStatistics = enrollments
    .GroupBy(e => e.CourseId)
    .Select(g => new
    {
        CourseId = g.Key,
        StudentCount = g.Count(),
        AverageScore = g.Average(e => e.Score)
    });

Print("Course statistics", courseStatistics);


// ==========================================
// 11. INNER JOIN
// ==========================================

Section("INNER JOIN");

// Method Syntax
var studentCourses = students.Join(
    enrollments,
    student => student.Id,
    enrollment => enrollment.StudentId,
    (student, enrollment) => new
    {
        student.Name,
        enrollment.CourseId,
        enrollment.Score
    });

Print("Student enrollments", studentCourses);

// Join three collections
var fullJoin = students
    .Join(
        enrollments,
        s => s.Id,
        e => e.StudentId,
        (s, e) => new { s.Name, e.CourseId, e.Score }
    )
    .Join(
        courses,
        se => se.CourseId,
        c => c.Id,
        (se, c) => new
        {
            se.Name,
            Course = c.Title,
            se.Score
        });

Print("Student + Course + Score", fullJoin);

// Query Syntax
var queryJoin =
    from s in students
    join e in enrollments
        on s.Id equals e.StudentId
    join c in courses
        on e.CourseId equals c.Id
    select new
    {
        Student = s.Name,
        Course = c.Title,
        e.Score
    };

Print("Join using Query Syntax", queryJoin);


// ==========================================
// 12. GROUP JOIN
// ==========================================

Section("GROUP JOIN");

var groupJoin = students.GroupJoin(
    enrollments,
    s => s.Id,
    e => e.StudentId,
    (s, studentEnrollments) => new
    {
        Student = s.Name,
        Enrollments = studentEnrollments
    });

foreach (var item in groupJoin)
{
    Console.WriteLine($"\n{item.Student}");

    foreach (var enrollment in item.Enrollments)
        Console.WriteLine($"Course ID: {enrollment.CourseId}");
}


// ==========================================
// 13. LEFT JOIN
// ==========================================

Section("LEFT JOIN");

// Classical Left Join
var leftJoin =
    from s in students
    join e in enrollments
        on s.Id equals e.StudentId
        into enrollmentGroup
    from e in enrollmentGroup.DefaultIfEmpty()
    select new
    {
        Student = s.Name,
        CourseId = e?.CourseId,
        Score = e?.Score
    };

Print("Left Join", leftJoin);

// Courses without students
var emptyCourses = courses.Where(c =>
    !enrollments.Any(e => e.CourseId == c.Id));

Print("Courses without students", emptyCourses);

// ==========================================
// 14. DEFAULTIFEMPTY
// ==========================================

Section("DEFAULT IF EMPTY");

var emptyList = new List<string>();

var defaultResult = emptyList.DefaultIfEmpty("No Data");

Print("DefaultIfEmpty", defaultResult);


// ==========================================
// 15. TO LIST, TO ARRAY, TO DICTIONARY
// ==========================================

Section("CONVERSION");

var studentList = students.Where(s => s.Age >= 21).ToList();

Console.WriteLine($"List count: {studentList.Count}");

var studentArray = students.ToArray();

Console.WriteLine($"Array length: {studentArray.Length}");

var studentDictionary = students.ToDictionary(s => s.Id);

Console.WriteLine($"Student 1: {studentDictionary[1].Name}");


// ==========================================
// 16. EXPRESSION EXAMPLE
// ==========================================

Section("EXPRESSION AND QUERY");

// IEnumerable
IEnumerable<Student> enumerable = students.Where(s => s.Age > 20);

// IQueryable
IQueryable<Student> queryable = students.AsQueryable()
    .Where(s => s.Age > 20);

Print("IEnumerable", enumerable);

Print("IQueryable", queryable);


// ==========================================
// MODELS
// ==========================================

public record Student(int Id, string Name, int Age);

public record Course(int Id, string Title);

public record Enrollment(int StudentId, int CourseId, double Score);
