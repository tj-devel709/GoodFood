using GoodFood.Services;
using GoodFood.ViewModels;
namespace GoodFood.Views;

public partial class NewGroceriesPage : ContentPage
{
	FoodDatabase database;
	NewGroceriesViewModel ViewModel;

	public NewGroceriesPage(FoodDatabase foodDatabase, NewGroceriesViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
		database = foodDatabase;
		ViewModel = viewModel;
	}

	void ExpirationDatePicker_DateSelected(System.Object sender, Microsoft.Maui.Controls.DateChangedEventArgs e)
	{
		ViewModel.SelectedExpirationDate = e.NewDate;
	}
}
