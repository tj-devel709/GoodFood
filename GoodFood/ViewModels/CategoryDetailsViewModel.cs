using System;
using GoodFood.Services;
using GoodFood.Views;
using GoodFood.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;

namespace GoodFood.ViewModels
{
	[QueryProperty(nameof(ItemList), "foodList")]
	public partial class CategoryDetailsViewModel : ObservableObject
	{
		FoodDatabase Database;

		[ObservableProperty]
		List<Food> itemList;

		[ICommand]
		async void SelectedFood(object sender)
		{
			var collectionView = sender as CollectionView;
			var EditFoodItem = collectionView.SelectedItem as Food;
			
			var navigationParameter = new Dictionary<string, object>
			{
				{ "EditFoodItem", EditFoodItem }
			};
			await Shell.Current.GoToAsync(nameof(NewGroceriesPage), navigationParameter);
		}

		public CategoryDetailsViewModel(FoodDatabase foodDatabase)
		{
			Database = foodDatabase;
		}
	}
}

