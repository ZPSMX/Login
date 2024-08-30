
namespace Login

{
    public partial class MainPage : ContentPage


    {
        private Database _database; // Declaración de la variable _database

        public MainPage()
        {
            InitializeComponent();
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "users.db3");
            _database = new Database(dbPath); // Inicialización de _database

            entradaContrasena.Completed += (s, e) => OnLoginClicked(s, e);



        }

        private async void NuevoUsuario_Cliked(object sender, EventArgs e)
        {
            // Pasar la instancia de la base de datos al crear la nueva página
            await Navigation.PushAsync(new Registro(_database));
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            var user = await _database.GetUserAsync(entradaUsuario.Text);
            if (user != null && user.Password == entradaContrasena.Text)
            {
                await DisplayAlert("Iniciando sesion", "Sesion iniciada correctamente", "OK");
                entradaUsuario.Text = null;
                entradaContrasena.Text=null;
            }
            else
            {
                await DisplayAlert("Iniciando sesion", "Error de usuario/contrasena", "OK");
                entradaUsuario.Text = null;
                entradaContrasena.Text = null;
            }
        }
    }
}
