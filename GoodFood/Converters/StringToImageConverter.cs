using System;
using System.Globalization;

namespace GoodFood.Converters
{
	public class StringToImageConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			switch (value.ToString())
			{
				case "Fruit":
					return "apple.png";
				case "Vegetable":
					return "broccoli.png";
				case "Grain":
					return "grain.png";
				case "Dairy":
					return "milk.png";
				case "Meat":
					return "meat.png";
				case "Egg":
					return "egg.png";
				case "Fish":
					return "seafood.png";
				case "Snack":
					return "snack.png";
				case "Leftovers":
					return "leftover.png";
				case "Other":
					return "room_service.png";
				default:
					return "bad_food";
			}

		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return null;
		}
	}
}