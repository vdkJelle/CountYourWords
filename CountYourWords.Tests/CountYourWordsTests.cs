namespace CountYourWords.Tests;

using CountYourWordsAssingment;

public class CountYourWordsTests
{
    [Fact]
    public void Run_WithNonExistantFile_ReturnsErrorCode()
    {
        int result = CountYourWords.RunProgram("doesntexist.txt");
        Assert.Equal(1, result);
    }

    [Fact]
	public void ParseFileContent_ShouldReturnOnlyAlphabeticWordsInLowerCase()
	{
		string input = ".... !! ## @ The brown fox jumped over the dog! 123 Big Brown Fox...";
		var expected = new List<string> { "the", "brown", "fox", "jumped", "over", "the", "dog", "big", "brown", "fox" };

		var result = CountYourWords.ParseFileContent(input);

		Assert.Equal(expected, result);
	}

	[Fact]
	public void CountWordOccurances_ShouldCountEachWordCorrectly()
	{
		var words = new List<string> { "big", "fox", "dog", "big" };

		var result = CountYourWords.CountWordOccurances(words);

		Assert.Equal(2, result["big"]);
		Assert.Equal(1, result["fox"]);
		Assert.Equal(1, result["dog"]);
	}
}
