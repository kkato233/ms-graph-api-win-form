using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MicrosftGraphApiWinForm
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += Application_ThreadException;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            Microsoft.Graph.ServiceException serviceException = e.Exception as Microsoft.Graph.ServiceException;
            if (serviceException != null)
            {
                ServiceExceptionDialog dlg = new ServiceExceptionDialog();
                dlg.SetException(serviceException);
                dlg.ShowDialog();
            } 
            else
            {
                MessageBox.Show(e.Exception.ToString());
            }
        }

        /// <summary>
        /// 現在のアプリケーションの アクセストークン
        /// </summary>
        public static string AccessToken;
    }
}
