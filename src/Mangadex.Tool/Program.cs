﻿using System.CommandLine;
using System.CommandLine.Invocation;

namespace Mangadex.Tool
{
	public static class Program
	{
		public static int Main(string[] args)
		{
			var rootCommand = new RootCommand
			{
				new Argument<int>(name: "manga-id", description: "Mangadex ID"),
				new Option<string>("--volume", getDefaultValue: () => "1", description: "Volume number"),
				new Option<string>("--chapter", getDefaultValue: () => "1", description: "Chapter number"),
				new Option<string>("--language", getDefaultValue: () => "gb", description: "Release language"),
				new Option<string>("--group", getDefaultValue: () => null, description: "Release group")
			};

			rootCommand.Description = "Download a manga from Mangadex";

			rootCommand.Handler = CommandHandler.Create<int, string, string, string, string>(CbzDownloader.Download);

			return rootCommand.InvokeAsync(args).Result;
		}
	}
}