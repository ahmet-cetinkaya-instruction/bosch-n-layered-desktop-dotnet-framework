using Core.Exceptions;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsUI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += Application_ThreadException;
            Application.Run(new Form1());
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            // Gelen exceptiona göre davranışlar..
            // Backlog: switch yapısına çevirilecek.
            if(e.Exception is ValidationException)
            {
                var validationError = (ValidationException)e.Exception;
                HandleValidationException(validationError);
            }
            if(e.Exception is BusinessException)
            {
                var businessException = (BusinessException)e.Exception;
                MessageBox.Show(businessException.ErrorMessage, "Business Hatası");
            }
            Console.WriteLine("Exception fırlatıldı!!!!");
        }

        private static void HandleValidationException(ValidationException validationError)
        {
            string message = "";
            foreach (var item in validationError.Errors)
            {
                message += item.ErrorMessage + "\n";
            }
            MessageBox.Show(message, "Validasyon Hatası");
        }
    }
}
