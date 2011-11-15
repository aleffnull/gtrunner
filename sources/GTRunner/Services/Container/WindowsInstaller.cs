using System.Windows;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace GTRunner.Services.Container
{
	public class WindowsInstaller : IWindsorInstaller
	{
		#region IWindsorInstaller implementation

		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(AllTypes.FromThisAssembly().BasedOn<Window>());
		}

		#endregion IWindsorInstaller implementation
	}
}