using Trastuaro_V2.Datos;

namespace Trastuaro_V2
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            try
            {
                ConexionBD.Inicializar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"No se pudo inicializar la base de datos.\n\n{ex.Message}",
                    "Error de base de datos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            Application.Run(new Form1());
        }
    }
}