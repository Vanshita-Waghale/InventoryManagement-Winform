using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MangoManWinform.Navigation;

namespace MangoManWinform
{
    internal static class Program
    {
            [STAThread]
            static void Main()
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                // Show login form first
                FrmLogin login = new FrmLogin();

            if (login.ShowDialog() == DialogResult.OK)
            {
                Application.Run(new Navigation.frmNavigationDashboard());
            }

            else
            {
                    // Login failed or user closed the form
                    Application.Exit();
                }
            }
        }
    }