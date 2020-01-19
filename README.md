#Considerations to have in mind for the development

In the master Branch, there is the complete exercise solved: problem 1, problem 2 and problem 3 (all integrated).

There is another branch "features/problem1" with only the solution for the problem 1 and another branch with the solution for the problem 2 and 3 (in features/problem2and3).

##Problem 1:
	There is an interface which is used in a class using dependency injection. That´s why I decided to use Moq library to simulate the returned value for the method "GetAccountAmount" for this interface. This method is used in the method we are trying to test "RefreshAmount" and it´s the only command used in its implementation. In the future, if there is any modification in the code it´s possible the test for "RefreshAmount" fails.

##Problem 2:
	Changed the test to async ( you can see it in the features/problem2 branch or in the master with the final solution)
	There is a new Async test named "RefreshAmountMultipleTimesTest" where I try to make some concurrence calls (just in case it is necessary because you mention this in the description of the problem 2).  

##Problem 3:
	Script bat created manually with dotnet commands.
	Option 2, from bitbucket using its pipeline (created in the repository): build, Unit tests and packages --> https://bitbucket.org/mapalomo/evision/addon/pipelines/home