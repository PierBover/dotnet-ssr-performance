using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace dotnet_ssr_performance.Pages
{
	public readonly struct Tile
	{
		public Tile(float x, float y)
		{
			X = x;
			Y = y;
		}

		public float X { get; }
		public float Y { get; }
	}

	public class IndexModel : PageModel
	{
		public List<Tile> Tiles = [];

		public void OnGet()
		{
			const float wrapperWidth = 960;
			const float wrapperHeight = 720;
			const float cellSize = 10;
			const float centerX = wrapperWidth / 2;
			const float centerY = wrapperHeight / 2;

			float angle = 0;
			float radius = 0;

			while (radius < MathF.Min(wrapperWidth, wrapperHeight) / 2)
			{
				float x = centerX + MathF.Cos(angle) * radius;
				float y = centerY + MathF.Sin(angle) * radius;

				if (x >= 0 && x <= wrapperWidth - cellSize && y >= 0 && y <= wrapperHeight - cellSize)
				{
					this.Tiles.Add(new Tile(x, y));
				}

				angle += 0.2f;
				radius += cellSize * 0.015f;
			}
		}
	}
}