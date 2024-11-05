using QuanLyDoDienTu.view;
using QuanLyDoDienTu.view.AdminForm;
using QuanLyDoDienTu.view.ClientForm;

namespace QuanLyDoDienTu
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new AdminMainForm());
        }
    }
}