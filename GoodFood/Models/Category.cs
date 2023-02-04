using System;
namespace GoodFood.Models
{
	public class Category
	{
		public string Name { get; set; }
		public Image Image { get; set; }
		public int Count { get; set; }

		public Category()
		{
		}

		public Category(string name, Image image, int count)
		{
			Name = name;
			Image = image;
			Count = count;
		}

		public void UpdateCount (int newCount)
		{
			Count = newCount;
		}
	}
}

