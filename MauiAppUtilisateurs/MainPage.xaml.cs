using Microsoft.Maui.Controls;
using System;
using MauiAppUtilisateurs.Models;
using System.Collections.ObjectModel;

namespace MauiAppUtilisateurs
{
    public partial class MainPage : ContentPage
    {
        int idIncrement = 1;

        // Utilisation de ObservableCollection pour permettre la mise à jour automatique de l'interface utilisateur
        public ObservableCollection<Person> Persons { get; set; } = new ();

        public MainPage()
        {
            InitializeComponent();
            BindingContext = this;

            // Ajout de quelques personnes à la liste lors de l'initialisation
            Persons.Add(new Person() { Id = idIncrement++, Nom = "Nadine", Prenom = "Amadou", Age = 24 });
            Persons.Add(new Person() { Id = idIncrement++, Nom = "Sarah", Prenom = "Alpha", Age = 25 });
            Persons.Add(new Person() { Id = idIncrement++, Nom = "Adam", Prenom = "Yves", Age = 35 });
        }

        private void Clicked_Btn_Ajouter(object sender, EventArgs e)
        {
            int age;
            if (int.TryParse(AgeEntry.Text, out age))
            {
                Person person = new Person(idIncrement, NomEntry.Text, PrenomEntry.Text, age);
                Persons.Add(person);
                idIncrement++;
            }
        }
        private void Selected_Person(object sender, SelectedItemChangedEventArgs e)
        {
            Person person = e.SelectedItem as Person;
            if (person != null)
            {
                  IdEntry.Text = person.Id.ToString();
                  NomEntry.Text = person.Nom;
                  PrenomEntry.Text = person.Prenom;
                  AgeEntry.Text = person.Age.ToString();
            }
        }

        private void Clicked_Btn_Supprimer(object sender, EventArgs e)
        {
            int id;
            int.TryParse(IdEntry.Text, out id);
            Person person = null;
            foreach (Person p in Persons)
            {
                if (p.Id.Equals(id))
                {
                    person = p;
                    break;
                }
            }
            Persons.Remove(person);
        }
        private void Clicked_Btn_Modifier(object sender, EventArgs e)
        {
            int id=int.Parse(IdEntry.Text);
            Person person = new Person();
            for (int i = 0; i < Persons.Count; i++)
            {
                if (Persons[i].Id.Equals(id))
                {
                    person.Id = Persons[i].Id;
                    person.Nom = NomEntry.Text;
                    person.Prenom = PrenomEntry.Text;
                    person.Age = int.Parse(AgeEntry.Text);
                    Persons[i] = person;
                    break;
                }
            }
        }
    }
}
