# Weather Test

4Com technical test for prospective .NET developers.

## Improvements

The project could be improved in a number of ways, some improvements i would suggest are

1) Error checking/handling - most important
2) A lot more unit test / Integration test 
3) A better rule engine, that can handle a collection of rules
4) Static links need to be stored correctly, database, web.config depending how often these links are to changed
5) Better error handling on the front end
6) Better UI, i would of liked to use something like Angularjs and displayed more information

## Adding more api's

The WeatherAggregatorFactory returns a list of IWeatherAggregator that are called based on the WindUnit enum and TempUnit enum.
Adding a new API should be as easy as extending the enum,  creating a new object that implements the IWeatherAggregator interface and a new model to parse the returning json data. 
The AggregatorClient uses generic type T so this shouldn't need to be updated. 

## Unit Test

Currently there are only 6 unit tests, all tests pass. 



I've also added a random thread sleep to the api calls that emulate a slow response