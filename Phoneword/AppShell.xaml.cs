using Phoneword.Pages.FlyoutEx1;
using Phoneword.Pages.SharedResourcesEx1;

namespace Phoneword;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(CustomTipPage), typeof(CustomTipPage));

        Application.Current.UserAppTheme = AppTheme.Dark;

		Routing.RegisterRoute("astronomicalbodydetails", typeof(AstronomicalBodyPage));

	}
}
