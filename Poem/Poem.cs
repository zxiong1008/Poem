using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poem
{
	public class Poems
	{
		Random rnd = new Random();

		public static void Main(string[] args)
		{
			Poems poem = new Poems();

			string[] s = new string[5];
			for (int i = 0; i < 5; i++)
			{
				s[i] = poem.Line().ToString();
				Console.WriteLine(s[i]);
			}

			File.WriteAllLines("F:\\Users\\Zengith\\Desktop\\Technical Test\\Poem1\\Poem\\Poem\\poem output.txt", s);
			//File.AppendText("F:\\Users\\Zengith\\Desktop\\Technical Test\\Poem1\\Poem\\Poem\\poem output.txt").WriteLine(s) ;

			//To keep console open, exit with any key
			Console.ReadKey();
		}

		public string Line()
		{
			Rules rule = new Rules();

			int rr = rnd.Next(3);
			if (rr == 2)
			{
				return "NOUN: " + rule.Noun(rnd);
			}
			else if (rr == 1)
			{
				return "PREPOSITION: " + rule.Preposition(rnd);
			}
			else
			{
				return "PRONOUN: " + rule.Pronoun(rnd);
			}
			//Read the file and display it line by line.

		}
	}
	public class Definition
	{
		public string definition(int n)
		{
			int counter = 0;
			string line;
			List<string> list = new List<string>();
			List<string> rule = new List<string>();
			StreamReader file = new StreamReader("F:\\Users\\Zengith\\Desktop\\Technical Test\\Poem1\\Poem\\Poem\\poem input.txt");
			while ((line = file.ReadLine()) != null)
			{
				//Console.WriteLine("{0}. {1} ", counter, line);

				list.Add(line);
				counter++;
			}
			for (int i = 0; i < list.Count; i++)
			{
				list[i] = list[i].Replace(" ", "");
				//Console.WriteLine("{0}. {1}", i, list[i]);
			}
			for (int i = 0; i < list.Count; i++)
			{
				//char[] c1 = list[i].ToCharArray(0, list[i].IndexOf(':') + 1);
				char[] c2 = list[i].ToCharArray(0, list[i].IndexOf('<'));
				//for (int j = 0; j < list[i].IndexOf(':'); j++)
				//{
				//	list[i] = list[i].Replace(c[0].ToString(), "");
				//}
				//foreach (char cc in c1)
				//{
				//	Console.Write("{0}", cc);
				//}
				string temp = "";

				foreach (char cc in c2)
				{
					temp += cc;
				}

				list[i] = temp;
				//Console.WriteLine(list[i]);
			}
			for (int i = 0; i < list.Count; i++)
			{
				char[] c1 = list[i].ToCharArray(0, list[i].IndexOf(':') + 1);

				string temp = "";
				foreach (char cc in c1)
				{
					temp += cc;
				}
				rule.Add(temp);
				list[i] = list[i].Replace(rule[i], "");
				rule[i] = rule[i].Replace(":", "");
				//Console.Write(rule[i]);
				//Console.WriteLine(list[i]);
			}

			List<string> definition = new List<string>();

			for (int i = n; i < n + 1; i++)
			{
				char[] c3 = list[i].ToCharArray();
				int[] ii = new int[c3.Length];
				int count = 0;
				int lastCount = 0;

				for (int j = 0; j < c3.Length; j++)
				{
					string temp = "";

					if (c3[j] == ('|'))
					{
						ii[count] = count;
						//Console.Write("{0} ",count);

						while (count >= lastCount)
						{
							temp += list[i].ElementAt(lastCount).ToString().Replace("|", "");
							lastCount++;
						}
						//Console.WriteLine(temp);
						lastCount = count;
						definition.Add(temp);
					}
					if (count == c3.Length - 1)
					{
						while (count >= lastCount)
						{
							temp += list[i].ElementAt(lastCount).ToString().Replace("|", "");
							lastCount++;
						}
						//Console.WriteLine(temp);
						definition.Add(temp);
					}

					count++;
				}
			}

			file.Close();
			return definition.ElementAt(new Random().Next(definition.Count())).ToString();


			//string file_name = "F:\\Users\\Zengith\\Desktop\\Technical Test\\Poem1\\Poem\\Poem\\poem input.txt";
			//string textLine = "";

			//StreamReader objReader = new StreamReader(file_name);

			//if (File.Exists(file_name) == true)
			//{
			//	do
			//	{
			//		textLine = textLine + objReader.ReadLine() + "\r\n";
			//	} while (objReader.Peek() != -1);
			//	objReader.Close();

			//	Console.WriteLine("{0}", textLine);
			//}
			//else
			//{
			//	Console.WriteLine("No such file " + file_name);
			//}
		}
	}
	public class Rules
	{
		////ADJECTIVES
		//List<string> adjList = new List<string> {
		//		"black", "white", "dark", "light", "bright", "murky",
		//		"muddy", "clear"};
		////NOUNS
		//List<string> nounList = new List<string>{
		//		"heart", "sun", "moon", "thunder", "fire", "time", "wind",
		//		"sea", "river", "flavor", "wave", "willow", "rain", "tree",
		//		"flower", "field", "meadow", "pasture", "harvest", "water",
		//		"father", "mother", "brother", "sister"};
		////PRONOUNS
		//List<string> pronounList = new List<string>{
		//		 "my", "your", "his", "her" };
		////VERBS
		//List<string> verbList = new List<string>{
		//		"runs", "walks", "stands", "climbs", "crawls", "flows", "flies",
		//		"transcends", "ascends", "descends", "sinks"};
		////PREPOSITIONS
		//List<string> prepList = new List<string>{ "above", "across", "against", "along",
		//		"among", "around", "before", "behind", "beneath", "beside",
		//		"between", "beyond", "during", "inside", "onto", "outside",
		//		"under", "underneath", "upon", "with", "without", "through"};

		Definition def = new Definition();

		string Adjective(Random rnd)
		{
			int rr = rnd.Next(3);
			//if (rr == 2)
			//{
			//	return "(a)" + adjList[rnd.Next(7)] + Noun(rnd);
			//}
			//else if (rr == 1)
			//{
			//	return "(a)" + adjList[rnd.Next(7)] + Adjective(rnd);
			//}
			//else
			//{
			//	return "(a)" + adjList[rnd.Next(7)] + " $END";
			//}
			if (rr == 2)
			{
				return "(a)" + def.definition(2) + Noun(rnd);
			}
			else if (rr == 1)
			{
				return "(a)" + def.definition(2) + Adjective(rnd);
			}
			else
			{
				return "(a)" + def.definition(2) + " $END";
			}

		}
		public string Noun(Random rnd)
		{
			int rr = rnd.Next(3);
			if (rr == 2)
			{
				return "(n)" + def.definition(3) + Verb(rnd);
			}
			else if (rr == 1)
			{
				return "(n)" + def.definition(3) + Preposition(rnd);
			}
			else
			{
				return "(n)" + def.definition(3) + " $END";
			}
		}
		public string Pronoun(Random rnd)
		{
			int rr = rnd.Next(2);
			if (rr == 1)
			{
				return "(pn)" + def.definition(4) + Adjective(rnd);
			}
			else
			{
				return "(pn)" + def.definition(4) + Noun(rnd);
			}
		}
		string Verb(Random rnd)
		{
			int rr = rnd.Next(3);
			if (rr == 2)
			{
				return "(v)" + def.definition(5) + Preposition(rnd);
			}
			else if (rr == 1)
			{
				return "(v)" + def.definition(5) + Pronoun(rnd);
			}
			else
			{
				return "(v)" + def.definition(5) + " $END";
			}
		}

		public string Preposition(Random rnd)
		{
			int rr = rnd.Next(3);
			if (rr == 2)
			{
				return "(p)" + def.definition(6) + Noun(rnd);
			}
			else if (rr == 1)
			{
				return "(p)" + def.definition(6) + Pronoun(rnd);
			}
			else
			{
				return "(p)" + def.definition(6) + Adjective(rnd);
			}
		}
	}
}
