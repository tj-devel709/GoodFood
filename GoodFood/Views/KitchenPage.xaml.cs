using GoodFood.Services;
using GoodFood.ViewModels;
namespace GoodFood.Views;

public partial class KitchenPage : ContentPage
{
	FoodDatabase database;

	public KitchenPage(FoodDatabase foodDatabase, KitchenViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
		database = foodDatabase;
	}
}
