namespace MauiAppUtilisateurs.Models;

public class Person
{
    public int Id { get; set; }
    public string Nom { get; set; }
    public string Prenom { get; set; }
    public int Age { get; set; }

    public Person() { }

    public Person(int id, string nom, string prenom, int age)
    {
        Id = id;
        Nom = nom;
        Prenom = prenom;
        Age = age;
    }
}