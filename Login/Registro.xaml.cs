namespace Login;

public partial class Registro : ContentPage
{
    private Database _database; // Añade una variable para la base de datos

    public Registro(Database database)
    {
        InitializeComponent();
        _database = database; // Asigna la base de datos pasada al constructor a la variable local
        registroContrasena.Completed += (s, e) => Registrar_Clicked(s, e);
    }

    public async void Registrar_Clicked(object sender, EventArgs e)
    {
        var newUser = new User
        {
            Username = registroUsuario.Text,
            Password = registroContrasena.Text
        };

        var existingUser = await _database.GetUserAsync(newUser.Username);
        if (existingUser == null)
        {
            await _database.SaveUserAsync(newUser);
            await DisplayAlert("Registro", "usuario correctamente registrado", "OK");
            await DisplayAlert("Registro", "Te llevare al login", "Si");
            registroUsuario.Text = null;
            registroContrasena.Text = null;
            await Navigation.PushAsync(new MainPage());
        }
        else
        {
            await DisplayAlert("Registro", "el usuario ya existe", "OK");
        }
    }
}
