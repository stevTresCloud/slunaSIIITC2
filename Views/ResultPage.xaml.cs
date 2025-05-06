namespace slunaSIIITC2.Views;

public partial class ResultPage : ContentPage
{
    private Models.Contact _contact;

    public ResultPage(Models.Contact contact)
    {
        InitializeComponent();
        _contact = contact;
        DisplayData();
    }

    private void DisplayData()
    {
        infoLabel.Text = $"""
            Tipo: {_contact.IdentificationType}
            Identificación: {_contact.Identification}
            Nombres: {_contact.FirstName}
            Apellidos: {_contact.LastName}
            Fecha: {_contact.BirthDate:yyyy-MM-dd}
            Correo: {_contact.Email}
            Salario: ${_contact.Salary:0.00}
            Aporte IESS: ${_contact.IESSContribution:0.00}
            """;
    }

    private async void OnExportClicked(object sender, EventArgs e)
    {
        string path = Path.Combine(FileSystem.AppDataDirectory, "contacto.txt");
        await File.WriteAllTextAsync(path, infoLabel.Text);
        await DisplayAlert("Exportado", $"Archivo guardado en:\n{path}", "OK");
    }
}