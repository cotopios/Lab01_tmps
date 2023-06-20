using System;


interface IBuilder
{
    void SetName(string name);
    void SetAge(int age);
    void SetGender(string gender);
    void SetEmail(string email);
    void SetPhoneNumber(string phoneNumber);
    Person GetPerson();
}


class PersonBuilder : IBuilder
{
    private Person person = new Person();

    public void SetName(string name)
    {
        person.Name = name;
    }

    public void SetAge(int age)
    {
        person.Age = age;
    }

    public void SetGender(string gender)
    {
        person.Gender = gender;
    }

    public void SetEmail(string email)
    {
        person.Email = email;
    }

    public void SetPhoneNumber(string phoneNumber)
    {
        person.PhoneNumber = phoneNumber;
    }

    public Person GetPerson()
    {
        return person;
    }
}


class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Gender { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public void DisplayDetails()
    {
        Console.WriteLine("Nume: " + Name);
        Console.WriteLine("Vârstă: " + Age);
        Console.WriteLine("Gen: " + Gender);
        Console.WriteLine("E-mail: " + Email);
        Console.WriteLine("Număr de telefon: " + PhoneNumber);
    }
}

class Program
{
    static void Main(string[] args)
    {
      
        PersonBuilder builder = new PersonBuilder();
        builder.SetName("John Smith");
        builder.SetAge(30);
        builder.SetGender("Masculin");
        builder.SetEmail("john.smith@gmail.com");
        builder.SetPhoneNumber("0720123456");
        Person person = builder.GetPerson();

        
        Console.WriteLine("Detalii personale:");
        person.DisplayDetails();
    }
}
