using GoodFood.Views;

namespace GoodFood;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute("NewGroceriesPage", typeof(NewGroceriesPage));
		Routing.RegisterRoute("CategoryDetailsPage", typeof(CategoryDetailsPage));
	}
}

