using System.Windows.Forms;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace GTRunner.Services.Container
{
	public class FormsInstaller : IWindsorInstaller
	{
		#region IWindsorInstaller implementation

		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(AllTypes.FromThisAssembly().BasedOn<Form>());
		}

		#endregion IWindsorInstaller implementation
	}
}