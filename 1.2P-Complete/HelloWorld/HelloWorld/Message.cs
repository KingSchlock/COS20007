using System;

public class Message
{
	private string _prompt;
	
	public Message(string prompt)
	{
		_prompt = prompt;
	}

	public void PrintPrompt()
    {
		Console.WriteLine(_prompt);
    }
}
