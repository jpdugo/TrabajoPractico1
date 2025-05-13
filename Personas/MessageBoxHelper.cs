using System.Windows.Forms;

namespace Personas
{
    public static class MessageBoxHelper
    {
        public static void ShowError(Exception e)
        {
            MessageBox.Show($"Error: {e.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
