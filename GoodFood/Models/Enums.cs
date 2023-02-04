using System;
namespace GoodFood.Models;

public class Enums
{
	public enum FoodType
	{
		Fruit,
		Vegetable,
		Grain,
		Dairy,
		Meat,
		Egg,
		Fish,
		Snack,
		Leftovers,
		Other,
	}

	public enum Location
	{
		Fridge,
		Pantry,
		Freezer,
		Cabinet,
		Basement,
		Garage,
		Outside,
		Counter,
		Table,
	}

	public enum Status
	{
		Good,
		Expired,
		Okay,
		ThrownOut,
	}
}

