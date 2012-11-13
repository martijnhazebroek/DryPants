# DryPants
Don't repeat yourself tools for .NET

## Feature overview
- Calendar class for common date related tasks;
- String extension methods for string interpolation (a.k.a. named format).
- Ruby-style language features;
- Exception management utility class;
- Etc.

## Examples

	// Output: DateTime containing the date of 10 days ago. 	
	10.Days().Ago();

	// Output: The age of a person whose birthday is 1985-10-24.	
	new DateTime(1985, 10, 24).Age();	

	// Output: DateTime containing the date of two days after the next workday. 	
	2.Days().After(Calendar.NextWorkday);

	// Throws: An ArgumentNullException if the property MyProperty of object myObject is null.
	Throw.IfArgumentNull(() => myObject.MyProperty);

	// Output: "DryPants rocks!"
	"{Product} rocks!".FormatNamed(new { Product = "DryPants" });

	// Output: All types that are instantiable + filter types which are dependant on other types that could not be loaded.
	Assembly.GetExecutingAssembly().GetInstantiableTypes();

## Get it on NuGet!

    Install-Package DryPants