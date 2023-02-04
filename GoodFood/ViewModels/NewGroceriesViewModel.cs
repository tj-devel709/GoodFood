using System;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using GoodFood.Models;
using GoodFood.Services;
using Microsoft.Toolkit.Mvvm.Input;

namespace GoodFood.ViewModels
{
	public partial class NewGroceriesViewModel : ObservableObject, IQueryAttributable
	{
		FoodDatabase Database;
		KitchenViewModel KitchenViewModel;

		public NewGroceriesViewModel(FoodDatabase database, KitchenViewModel kitchenViewModel)
		{
			Database = database;
			KitchenViewModel = kitchenViewModel;
			OperationName = "Add Food";
		}

		public void ApplyQueryAttributes(IDictionary<string, object> query)
		{
			if (query.TryGetValue("EditFoodItem", out object value))
			{
				EditFoodItem = value as Food;
				CanDelete = true;
				OperationName = "Edit Food";
				LoadFoodData(EditFoodItem);
			}
		}

		void LoadFoodData(Food food)
		{
			Name = food.Name;
			SelectedExpirationDate = food.ExpirationDate;
			SelectedLocationItem = food.Location;
			SelectedTypeItem = food.FoodType;
			SelectedStatusItem = food.Status;
		}

		[ICommand]
		async Task Create(string OperationName)
		{
			if (string.IsNullOrEmpty(Name))
			{
				await App.Current.MainPage.DisplayAlert("Almost There", "Please add a name", "Okay");
				return;
			}

			if (OperationName == "Add Food")
			{
				await Database.SaveItemAsync(new Food(Name, SelectedTypeItem, SelectedLocationItem, SelectedStatusItem, selectedExpirationDate));
				var items = await Database.GetItemsAsync();
			}

			if (OperationName == "Edit Food")
			{
				await Database.SaveItemAsync(EditFoodItem);
			}

			if (string.IsNullOrEmpty(Name))
			{
				await App.Current.MainPage.DisplayAlert("Almost There", "Please add a name", "Okay");
				return;
			}

			KitchenViewModel.KitchenItems = await Database.GetItemsAsync();
			KitchenViewModel.GoodCount = KitchenViewModel.KitchenItems.Where(t => t.Status == Enums.Status.Good).Count();
			KitchenViewModel.OkayCount = KitchenViewModel.KitchenItems.Where(t => t.Status == Enums.Status.Okay).Count();
			KitchenViewModel.BadCount = KitchenViewModel.KitchenItems.Where(t => t.Status == Enums.Status.Expired).Count();
			await Shell.Current.GoToAsync("..");
			EditFoodItem = null;
			CanDelete = false;
		}

		[ICommand]
		//void Delete ()
		async Task Delete()
		{
			await Database.DeleteItemAsync(EditFoodItem);

			KitchenViewModel.KitchenItems = await Database.GetItemsAsync();
			KitchenViewModel.GoodCount = KitchenViewModel.KitchenItems.Where(t => t.Status == Enums.Status.Good).Count();
			KitchenViewModel.OkayCount = KitchenViewModel.KitchenItems.Where(t => t.Status == Enums.Status.Okay).Count();
			KitchenViewModel.BadCount = KitchenViewModel.KitchenItems.Where(t => t.Status == Enums.Status.Expired).Count();

			// TODO until i can delete from previous list
			await Shell.Current.GoToAsync("../..");
			EditFoodItem = null;
			CanDelete = false;
		}

		[ObservableProperty]
		Food editFoodItem;

		[ObservableProperty]
		bool canDelete = false;

		[ObservableProperty]
		string name;

		[ObservableProperty]
		string operationName;

		[ObservableProperty]
		Enums.FoodType selectedTypeItem;

		[ObservableProperty]
		Enums.Location selectedLocationItem;

		[ObservableProperty]
		Enums.Status selectedStatusItem;

		[ObservableProperty]
		DateTime selectedExpirationDate;

		[ObservableProperty]
		Enums.FoodType[] typeItems =
		{
			Enums.FoodType.Fruit,
			Enums.FoodType.Vegetable,
			Enums.FoodType.Grain,
			Enums.FoodType.Dairy,
			Enums.FoodType.Meat,
			Enums.FoodType.Egg,
			Enums.FoodType.Fish,
			Enums.FoodType.Snack,
			Enums.FoodType.Leftovers,
		};

		[ObservableProperty]
		Enums.Location[] locationItems =
		{
			Enums.Location.Fridge,
			Enums.Location.Pantry,
			Enums.Location.Freezer,
			Enums.Location.Cabinet,
			Enums.Location.Basement,
			Enums.Location.Garage,
			Enums.Location.Outside,
			Enums.Location.Counter,
			Enums.Location.Table,
		};

		[ObservableProperty]
		Enums.Status[] statusItems =
		{
			Enums.Status.Good,
			Enums.Status.Expired,
			Enums.Status.Okay,
			Enums.Status.ThrownOut,
		};
	}
}

