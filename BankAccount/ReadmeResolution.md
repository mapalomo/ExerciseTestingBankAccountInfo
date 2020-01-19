##Problem 1:
	I decided to use Moq library to simulate the returned value for the method "GetAccountAmount" for this interface. This method is used in the method we are trying to test "RefreshAmount" and it´s the only command used in its implementation. In the future, if there is any modification in the code it´s possible the test for "RefreshAmount" fails.

##Problem 2:
	Add new method Async
	There is a new Async test named "RefreshAmountMultipleTimesTest" where I try to make some concurrence calls (just in case it is necessary because you mention this in the description of the problem 2).  

##Problem 3:
	Script bat created manually with dotnet commands.
	Option 2, from Github using its pipeline (created in the repository): build, Unit tests and packages 