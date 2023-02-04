using GoodFood.Services;
using GoodFood.ViewModels;
using GoodFood.Models;
namespace GoodFood;

public partial class App : Application
{
	FoodDatabase Database;
	KitchenViewModel KitchenViewModel;

	public App(FoodDatabase database, KitchenViewModel kitchenViewModel)
	{
		InitializeComponent();

		MainPage = new AppShell();
		Database = database;
		KitchenViewModel = kitchenViewModel;
	}

	protected override Window CreateWindow(IActivationState activationState)
	{
		Window window = base.CreateWindow(activationState);

		window.Created += async (s, e) =>
		{
			// For Testing Purposes Only!!!
			await Database.DeleteAllItemsForSureAsync();
			Database = null;
			Database = new FoodDatabase();

			KitchenViewModel.KitchenItems = await Database.GetItemsAsync();
			KitchenViewModel.GoodCount = KitchenViewModel.KitchenItems.Where(t => t.Status == Enums.Status.Good).Count();
			KitchenViewModel.OkayCount = KitchenViewModel.KitchenItems.Where(t => t.Status == Enums.Status.Okay).Count();
			KitchenViewModel.BadCount = KitchenViewModel.KitchenItems.Where(t => t.Status == Enums.Status.Expired).Count();
		};

		return window;
	}
}
