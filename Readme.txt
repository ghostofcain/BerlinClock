Note: I used VS 2019 since that's the only VS I have installed.
Note2: I had to upgrade the SpecFlow libraries because it wasn't working with my Visual Studio. It's now targetting the latest version of SpecFlow.

The implementation is in the BerlinClockImple.cs

I have tested the implementation using edge cases and the feature tests. I've added a couple of new features to the spec flow as well 
Since the tests are comprehensive, I only added limited number of integration tests to verify that the entire process glues together

I changed the implementation of TimeConverter to accept a factory in the constuctor that creates the IBerlinClock interface. This in turn allow us to write tests 
against the IBerlinClock interface and not the implementation using a factory.

To the best of my knowledge, this should implement the Berlin clock requirement as expected and should cover all permutations.

