using System;
using SQLite;
using GoodFood.Models;

namespace GoodFood.Services;

public class FoodDatabase
{
	SQLiteAsyncConnection Database;

	public FoodDatabase()
	{
	}

	async Task Init()
	{
		if (Database is not null)
			return;

		Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
		var result = await Database.CreateTableAsync<Food>();
	}

	public async Task<List<Food>> GetItemsAsync()
	{
		await Init();
		return await Database.Table<Food>().ToListAsync();
	}

	public async Task<List<Food>> GetGoodFoodAsync()
	{
		await Init();
		return await Database.Table<Food>().Where(i => i.Status == Enums.Status.Good).ToListAsync();
	}

	public async Task<List<Food>> GetOkayFoodAsync()
	{
		await Init();
		return await Database.Table<Food>().Where(i => i.Status == Enums.Status.Okay).ToListAsync();
	}

	public async Task<List<Food>> GetExpiredFoodAsync()
	{
		await Init();
		return await Database.Table<Food>().Where(i => i.Status == Enums.Status.Expired).ToListAsync();
	}

	public async Task<List<Food>> GetThrownOutFoodAsync()
	{
		await Init();
		return await Database.Table<Food>().Where(i => i.Status == Enums.Status.ThrownOut).ToListAsync();
	}

	public async Task<Food> GetItemAsync(int id)
	{
		await Init();
		return await Database.Table<Food>().Where(i => i.Id == id).FirstOrDefaultAsync();
	}

	public async Task<int> SaveItemAsync(Food item)
	{
		await Init();
		if (item.Id != 0)
			return await Database.UpdateAsync(item);
		else
			return await Database.InsertAsync(item);
	}

	public async Task<int> DeleteItemAsync(Food item)
	{
		await Init();
		return await Database.DeleteAsync(item);
	}

	public async Task<int> DeleteAllItemsForSureAsync()
	{
		await Init();
		return await Database.DeleteAllAsync<Food>();
	}
}

