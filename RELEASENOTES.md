### 1.0.0.4 (11-19-2012)

- **StringBuilder**: Added `AppendIf` and `AppendFormatIf` extension methods	
	- `builder.AppendFormat(2.IsEven(), "2 is an even number")`	
	-  `builder.AppendFormatIf(2.IsEven(), "{0} is an even number", 2)`

- **char**: Added `UpTo` and `ToAlphabetIndex` extension methods.
	-  `'a'.UpTo('z') // returns ['a', 'b', 'c', ..... 'z']`
	- `'z'.ToAlphabetIndex() // returns 25`



### 1.0.0.3 (11-13-2012)

- **Calendar** utility class
	-  `DateTime Yesterday`
	-  `DateTime Tomorrow`
	-  `DateTime NextWorkday`
	-  `DateTime PreviousWorkday`
	-  `int Weeknumber`
	-  `DateTime NextWeek`
	-  `DateTime PreviousWeek`
	-  `int DaysInCurrentMonth`
	-  `DateTime NextMonth`
	-  `DateTime PreviousMonth`
	-  `int DaysInCurrentYear`
	-  `bool CurrentYearIsLeapYear`

- **Throw** utility class
	-  `void IfArgumentNull<TProperty>(Expression<Func<TProperty>> expression)`
	-  `void IfArgumentNull(string paramName, object argument)`

- **DateTime** extension methods
	- `int ToAge (this DateTime birthday)`
	- `int GetDaysInMonth (this DateTime source)`
	- `int GetDaysInYear (this DateTime source)`
	- `bool IsLeapYear (this DateTime source)`
	- `bool IsWorkday (this DateTime source)`
	- `DateTime FirstDayOfMonth (this DateTime source)`
	- `DateTime LastDayOfMonth (this DateTime source)`
	- `DateTime FirstDayOfWeek (this DateTime source)`

- **Decimal** extension methods
	- `decimal RoundDown (this decimal source, int decimalPlaces)`
	- `decimal RoundUp (this decimal source, int decimalPlaces)`

- **Enum** extension methods
	- `bool IsOneOf(this Enum source, params Enum[] enumValues)`

- **Integer** extension methods
	- `TimeSpan Days(this int source)`
	- `TimeSpan Hours(this int source)`
	- `TimeSpan Days(this int source)`
	- `TimeSpan Minutes(this int source)`
	- `TimeSpan Seconds(this int source)`
	- `bool IsEven(this int source)`
	- `bool IsOdd(this int source)`
	- `Times(this int source, Action<int> action)`
	- `int[] UpTo(this int source, int limit)`
	- `int UpTo(this int source, int limit, Action<int> action)`
	- `int[] DownTo(this int source, int limit)`
	- `int DownTo(this int source, int limit, Action<int> action)`

- **TimeSpan** extension methods
	- `DateTime After(this TimeSpan source, DateTime dateTime)`
	- `DateTime Before(this TimeSpan source, DateTime dateTime)`
	- `DateTime Ago(this TimeSpan source)`
	- `DateTime FromNow(this TimeSpan source)`

- **String** extension methods
	- `string EachLine(this string source, Action<string> action)`
	- `string EachLine(this string source, string seperator, Action<string> action)`
	- `string FormatNamed(this string source, object propertySource)`
	- `string FormatParams(this string source, params object[] args)`

- **Assembly** extension methods
	- `Type[] GetInstantiableTypes(this Assembly assembly)`
