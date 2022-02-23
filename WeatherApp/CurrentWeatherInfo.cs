using System;
using System.Collections;
using System.Collections.Generic;

public class CurrentWeatherInfo
{
	public class coord
	{
		public double lon { get; set; }
		public double lat { get; set; }
	}

	public class weather
	{
		public int id { get; set; }
		public string main { get; set; }
		public string description { get; set; }
		public string icon { get; set; }
	}

	public class main
	{
		public double temp
		{
			get => temp;
			set => Math.Round(value);
		}
		public double feels_like
		{
			get => feels_like;
			set => Math.Round(value);
		}
		public double temp_min
		{
			get => temp_min;
			set => Math.Round(value);
		}
		public double temp_max
		{
			get => temp_max;
			set => Math.Round(value);
		}
		public double pressure { get; set; }
		public double humidity { get; set; }
	}

	public class wind
	{
		public double speed { get; set; }
	}

	public class sys
	{
		public string country { get; set; }
		public int sunrise { get; set; }
		public int sunset { get; set; }
	}

	public class root
	{
		public string name { get; set; }
		public sys sys { get; set; }
		public double dt { get; set; }
		public wind wind { get; set; }
		public main main { get; set; }
		public List<weather> weatherList { get; set; }
		public coord coordinate { get; set; }

	}
}
