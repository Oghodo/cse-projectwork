using system;

class Program
{
    static void Main()
    {
        Resume resume = new Resume("Prince Omo");
        resume.AddJob(new Job("Software Developer", "TechCorp", 2023, 2025));
        resume.AddJob(new Job("Intern", "CodeBase Inc.", 2022, 2023));

        resume.Display();
    }
}

/*
 Enhancements:
 - Follows separation of concerns: Resume and Job have distinct responsibilities.
 - Each class is placed in its own file with matching name.
 - TitleCase for class and method names, _underscoreCamelCase for fields.
 - Clean indentation and spacing
 
/*