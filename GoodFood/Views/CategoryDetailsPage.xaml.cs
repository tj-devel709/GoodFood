using GoodFood.ViewModels;
namespace GoodFood.Views;

public partial class CategoryDetailsPage : ContentPage
{
	public CategoryDetailsPage(CategoryDetailsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}
