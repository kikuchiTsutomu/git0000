using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EodrLngMembrane
{
    static class Program
    {
        private static ApplicationContext mainApplicationContext;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new EodrSampleForm());

            mainApplicationContext = new ApplicationContext();

            EodrLngMembraneCaltureForm caltureForm = new EodrLngMembraneCaltureForm();
            caltureForm.Closed += new EventHandler(ClosedCaltureForm);
            mainApplicationContext.MainForm = caltureForm;

            Application.Run(mainApplicationContext);
        }

        private static void ClosedCaltureForm(object sender, EventArgs e)
        {
            EodrLngMembraneMenuForm newForm = new EodrLngMembraneMenuForm();
            mainApplicationContext.MainForm = newForm;
            newForm.Show();
        }
    }
}
