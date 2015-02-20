[![Build status](https://ci.appveyor.com/api/projects/status/vh2p923cxlwv8of5/branch/master?svg=true)](https://ci.appveyor.com/project/martijnhazebroek/drypants/branch/master)

# DryPants
Don't repeat yourself tools for .NET

## Feature overview
- Calendar class for common date related tasks;
- String extension methods for string interpolation (a.k.a. named format);
- Ruby-style language features;
- Exception management utility class;
- Etc. (check examples / GitHub)

## Get it on NuGet!

    Install-Package DryPants

## Examples

	// Output: DateTime containing the time 10 hours from now.
	10.Hours().FromNow();
	
	// Output: DateTime containing the date of 10 days ago. 	
	10.Days().Ago();

	// Output: DateTime containing the date of two days after the next workday. 	
	2.Days().After(Calendar.NextWorkday);

	// Output: The age of a person whose birthday is 1985-10-24.    
	new DateTime(1985, 10, 24).ToAge();   

	// Output: "01234".
	5.Times(Console.WriteLine);

	// Output: [5, 6, 7, 8, 9, 10].
	5.UpTo(10);

	// Output: "5:False 6:True 7:False 8:True 9:False 10:True".
	5.UpTo(10, i => Console.Write("{0}:{1} ".FormatParams(i, i.IsEven())));

	// Throws: An ArgumentNullException if the property MyProperty of object myObject is null.
	Throw.IfArgumentNull(() => myObject.MyProperty);

	// Output: "DryPants rocks!".
	"{Product} rocks!".FormatNamed(new { Product = "DryPants" });

	// Output: 10.00045M
	10.000456M.RoundDown(5);

	// Output: true
	ConsoleColor.Blue.IsOneOf(ConsoleColor.Blue, ConsoleColor.Red);

	// Output: All types that are instantiable + filter types which are dependant on other types that could not be loaded.
	Assembly.GetExecutingAssembly().GetInstantiableTypes();

	// Output: 
	//	Lorem Ipsum
	//	Second line
	//	Third line
	"Lorem Ipsum\nSecond line\nThird line".EachLine(Console.WriteLine);

	// Output: ['a', 'b', 'c',....'z']
	'a'.UpTo('z');

	// Output: 25
	'z'.ToAlphabetIndex()

	// Output: "Minus 2 is an even number."
	const int number = 2;    
    new StringBuilder().AppendFormatIf(number >= 0, "{0} is an ", number)
                       .AppendFormatIf(number < 0, "Minus {0} is an ", number * -1)
                       .AppendIf(2.IsEven(), "even")
                       .AppendIf(2.IsOdd(), "odd")
                       .Append(" number.")
		               .ToString();

	// Output: true.
	new DateTime(2012, 10, 31).IsLastDayOfMonth()

	// Feature: Strongly typed application settings.
	internal sealed class AppSettings : DryAppSettings
	{
	    public Version Version
	    {
	        get { return GetAppSettingFor(() => Version); }
	    }

  		public DirectoryInfo InstallationDir
        {
        	get { return GetAppSettingFor(() => InstallationDir); }
        }
		// etc.
	}

	// Output:  "01/01/2010 - 01/31/2010",
    //          "02/01/2010 - 02/14/2010"
    var period = new Period(new DateTime(2010, 1, 1), new DateTime(2010, 2, 14))
	period.EachMonth(Console.WriteLine);
