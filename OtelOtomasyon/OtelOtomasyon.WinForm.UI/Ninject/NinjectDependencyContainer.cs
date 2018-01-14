using Ninject;
using OtelOtomassyon.BLL.Services.Abstracts;
using OtelOtomassyon.BLL.Services.Concretes;
using OtelOtomasyon.DAL;
using OtelOtomasyon.Repository.Abstract;
using OtelOtomasyon.Repository.Concrete;
using OtelOtomasyon.Repository.UOW.Abstract;
using OtelOtomasyon.Repository.UOW.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtelOtomasyon.WinForm.UI.Ninject
{
    public class NinjectDependencyContainer
    {
        public static IKernel RegisterDependency(IKernel kernel)
        {
            kernel.Bind<DbContext>().To<ProjectContext>();
            kernel.Bind<IMusteriService>().To<MusteriService>();
            kernel.Bind<IMusteriRepository>().To<MusteriRepository>();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
            kernel.Bind<ILoginService>().To<LoginService>();
            kernel.Bind<ILoginRepository>().To<LoginRepository>();

            return kernel;
        }
    }
}
