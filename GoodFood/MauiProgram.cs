using GoodFood.Services;
using Microsoft.Extensions.Logging;
using GoodFood.Views;
using GoodFood.ViewModels;

namespace GoodFood;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		builder.Services.AddSingleton<KitchenPage>();
		builder.Services.AddSingleton<KitchenViewModel>();
		builder.Services.AddTransient<NewGroceriesPage>();
		builder.Services.AddTransient<NewGroceriesViewModel>();
		builder.Services.AddTransient<CategoryDetailsPage>();
		builder.Services.AddTransient<CategoryDetailsViewModel>();

		builder.Services.AddSingleton<FoodDatabase>();

		return builder.Build();
	}
}

