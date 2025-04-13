namespace squispeS1T1M
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnCalcular_Clicked(object sender, EventArgs e)
        {
            // Validación de campos vacíos
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtNacimiento.Text) ||
                string.IsNullOrWhiteSpace(txtSalario.Text))
            {
                await DisplayAlert("Error", "Todos los campos son obligatorios", "OK");
                return;
            }

            // Validación de formato numérico
            if (!int.TryParse(txtNacimiento.Text, out int anioNacimiento) ||
                !decimal.TryParse(txtSalario.Text, out decimal salario))
            {
                await DisplayAlert("Error", "Ingrese datos numéricos válidos en Año de nacimiento y Salario", "OK");
                return;
            }

            int anioActual = DateTime.Now.Year;

            // Validación del rango de año
            if (anioNacimiento < 1920 || anioNacimiento > anioActual)
            {
                await DisplayAlert("Error", $"El año de nacimiento debe estar entre 1920 y {anioActual}", "OK");
                return;
            }

            int edad = anioActual - anioNacimiento;

            // Validaciones de edad
            if (edad < 18)
            {
                await DisplayAlert("Edad no válida", "Es menor de edad no es posible aporte al IESS", "OK");
                return;
            }
            else if (edad > 60)
            {
                await DisplayAlert("Jubilación", "Usted está aprobado para su jubilación. ¡FELICIDADES!", "OK");
                return;
            }

            // Cálculo del aporte al IESS (9.45%)
            decimal aporte = salario * 0.0945m;

            // Mostrar alerta con los datos
            string mensaje = $"Bienvenido {txtName.Text} {txtApellido.Text}\n" +
                             $"Tienes {edad} años\n" +
                             $"Tu aporte mensual es {aporte:C}";

            await DisplayAlert("Resultado", mensaje, "OK");

            lblResultado.Text = mensaje;
        }
    }

}
