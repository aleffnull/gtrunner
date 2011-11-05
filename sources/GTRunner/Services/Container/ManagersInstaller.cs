using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace GTRunner.Services.Container
{
	public class ManagersInstaller : IWindsorInstaller
	{
		#region IWindsorInstaller implementation

		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(AllTypes.FromThisAssembly().Where(t => t.Name.EndsWith("Manager")));
		}

		#endregion IWindsorInstaller implementation
	}
}