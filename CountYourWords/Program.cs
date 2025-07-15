using System.Text.RegularExpressions;

namespace CountYourWordsAssingment;

public partial class CountYourWords
{
	[GeneratedRegex(@"\b[a-zA-Z]+\b")]
	private static partial Regex WordsRegex();

	private static bool HandleFileReadError(Exception e)
	{
		switch (e)
		{
			case FileNotFoundException:
				Console.WriteLine("Error: File not found");
				break;
			case UnauthorizedAccessException:
				Console.WriteLine("Error: Unauthorized access");
				break;
			case DirectoryNotFoundException:
				Console.WriteLine("Error: Directory not found");
				break;
			case PathTooLongException:
				Console.WriteLine("Error: Path too long");
				break;
			default:
				return false;
		}

		return true;
	}

	private static void PrintOutput(int numberOfWords, Dictionary<string, int> wordOccurances)
	{
		Console.WriteLine($"Number of words: {numberOfWords}\n");
		foreach (var entry in wordOccurances.OrderBy(word => word.Key))
		{
			Console.WriteLine($"{entry.Key} {entry.Value}");
		}
	}

	public static Dictionary<string, int> CountWordOccurances(List<string> parsedFileContent)
	{
		Dictionary<string, int> result = [];

		foreach (var word in parsedFileContent)
		{
			if (result.TryGetValue(word, out int value))
			{
				result[word] = ++value;
			}
			else
			{
				result[word] = 1;
			}
		}

		return result;
	}

	public static List<string> ParseFileContent(string fileContent)
	{
		List<string> result = [];

		var words = WordsRegex().Matches(fileContent);

		foreach (Match match in words)
		{
			result.Add(match.Value.ToLower());
		}

		return result;
	}

	public static int RunProgram(string filePath)
	{
		string fileContent;

		try
		{
			fileContent = File.ReadAllText(filePath);
		}
		catch (Exception e) when (HandleFileReadError(e))
		{
			Console.WriteLine($"Error: {e.Message}");
			return 1;
		}

		try
		{
			var parsed = ParseFileContent(fileContent);
			var count = parsed.Count;
			var wordOccurances = CountWordOccurances(parsed);
			PrintOutput(count, wordOccurances);
			return 0;
		}
		catch (RegexMatchTimeoutException)
		{
			Console.WriteLine("Error: Regex failed");
			return 1;
		}
	}

	private static int Main()
	{
		return RunProgram("input.txt");
	}
}
