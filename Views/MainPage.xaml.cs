using System.Text;
using Microsoft.Maui.Controls;
using slunaSIIITC2.Views;
using slunaSIIITC2.Models;

namespace slunaSIIITC2;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        string type = identificationPicker.SelectedItem?.ToString();
        string id = identificationEntry.Text?.Trim();
        string firstName = firstNameEntry.Text?.Trim();
        string lastName = lastNameEntry.Text?.Trim();
        string email = emailEntry.Text?.Trim();
        string salaryText = salaryEntry.Text?.Trim();
        double salary;

        if (string.IsNullOrWhiteSpace(type) || string.IsNullOrWhiteSpace(id) ||
            string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) ||
            string.IsNullOrWhiteSpace(email) || !double.TryParse(salaryText, out salary))
        {
            await DisplayAlert("Error", "Todos los campos deben estar correctamente llenos.", "OK");
            return;
        }

        if ((type == "CI" && id.Length != 10) || (type == "RUC" && id.Length != 13))
        {
            await DisplayAlert("Error", $"La longitud de {type} es inválida.", "OK");
            return;
        }

        var contact = new Models.Contact
        {
            IdentificationType = type,
            Identification = id,
            FirstName = firstName,
            LastName = lastName,
            BirthDate = birthDatePicker.Date,
            Email = email,
            Salary = salary
        };

        await Navigation.PushAsync(new ResultPage(contact));
    }

    private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        identificationEntry.Text = string.Empty;
    }
}