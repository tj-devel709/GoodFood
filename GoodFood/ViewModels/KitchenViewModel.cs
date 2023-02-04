using System;
using GoodFood.Models;
using GoodFood.Views;
using GoodFood.Services;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace GoodFood.ViewModels;

public partial class KitchenViewModel : ObservableObject
{
    FoodDatabase FoodDatabase;

	[ObservableProperty]
	//[NotifyPropertyChangedFor(nameof(GoodCount))]
	List<Food> kitchenItems = new List<Food>();

    [ObservableProperty]
    int goodCount;

	[ObservableProperty]
	int okayCount;

	[ObservableProperty]
	int badCount;

	public KitchenViewModel(FoodDatabase foodDatabase)
    {
		FoodDatabase = foodDatabase;
    }

	[ICommand]
    async Task CreateNewFood()
    {
		await Shell.Current.GoToAsync(nameof(NewGroceriesPage));
	}

	[ICommand]
    async Task GoToCategoryDetails(string key)
    //void GoToCategoryDetails(string key)
    {
		List<Food> foodList;

		switch (key)
		{
			case "GoodFood":
				foodList = await FoodDatabase.GetGoodFoodAsync();
				break;
			case "OkayFood":
				foodList = await FoodDatabase.GetOkayFoodAsync();
				break;
			case "BadFood":
				foodList = await FoodDatabase.GetExpiredFoodAsync();
				break;
			default:
				return;
		}

		var navigationParameter = new Dictionary<string, object>
		{
			{ "foodList", foodList }
		};
		await Shell.Current.GoToAsync(nameof(CategoryDetailsPage), navigationParameter);
	}
}


