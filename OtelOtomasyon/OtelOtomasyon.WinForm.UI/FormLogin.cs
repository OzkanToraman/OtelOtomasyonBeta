using Ninject;
using OtelOtomassyon.BLL.Services.Abstracts;
using OtelOtomasyon.DAL;
using OtelOtomasyon.Repository.Abstract;
using OtelOtomasyon.Repository.UOW.Abstract;
using OtelOtomasyon.WinForm.UI.Ninject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtelOtomasyon.WinForm.UI
{
    public partial class FormLogin : Form
    {

        public static string kullanici;
        protected IUnitOfWork _uow;
        protected ILoginService _loginService;
        public FormLogin()
        {
            var container = NinjectDependencyContainer.RegisterDependency(new StandardKernel());
            _uow = container.Get<IUnitOfWork>();
            _loginService = container.Get<ILoginService>();
            InitializeComponent();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            Login l = new Login()
            {
                UserName = txtUser.Text,
                Password = txtPassword.Text
            };
            var result = _loginService.LoginControl(l);

            if (result.IsValid==false)
            {
                MessageBox.Show(result.Errors.FirstOrDefault());
            }
            else
            {
                Login login = new Login();
                login = _uow.GetRepo<Login>().Where(x => x.UserName == txtUser.Text && x.Password == txtPassword.Text).FirstOrDefault();
                if (login == null)
                {
                    MessageBox.Show("Hatalı Kullanıcı Adı ya da Şifre!", "HATA");
                    txtUser.Focus();
                    txtUser.SelectAll();
                }
                else
                {
                    string Role = login.Role.RoleName;
                    kullanici = login.UserName;
                    FormAnasayfa frm = new FormAnasayfa(Role);
                    this.Hide();
                    frm.Show();
                }

            }
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnKapat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
