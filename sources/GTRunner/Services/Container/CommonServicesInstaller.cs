using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace GTRunner.Services.Container
{
	public class CommonServicesInstaller : IWindsorInstaller
	{
		#region IWindsorInstaller implementation

		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(AllTypes.FromThisAssembly().Where(
				t => !string.IsNullOrEmpty(t.Namespace) && t.Namespace.Contains("Services.Common")));
		}

		#endregion IWindsorInstaller implementation
	}
}