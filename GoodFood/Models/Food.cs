using System;
using SQLite;

namespace GoodFood.Models;

public class Food
{
	[PrimaryKey, AutoIncrement]
	public int Id { get; set; }
	public string Name { get; set; }
	public Enums.FoodType FoodType { get; set; }
	public Enums.Location Location { get; set; }
	public Enums.Status Status { get; set; }
	public DateTime ExpirationDate { get; set; }

	public Food(string name, Enums.FoodType foodType, Enums.Location location, Enums.Status status, DateTime expirationDate)
	{
		Name = name;
		FoodType = foodType;
		Location = location;
		Status = status;
		ExpirationDate = expirationDate;
	}

	public Food()
	{
	}


}
