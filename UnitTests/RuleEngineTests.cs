using System;
using System.Collections.Generic;
using System.Text;
using BLL.Interfaces;
using BLL.WeatherRules;
using BO;
using NUnit.Framework;
using Shouldly;
using Xunit;

namespace UnitTests
{ 
    public class RuleEngineTests
    {
        private IWeatherRule _sut;

        public RuleEngineTests()
        {
            _sut = new _4ComRule();
        }

        [Fact]
        public void When_Temp_is_10c_the_value_returned_is_15c()
        {
            //arrange
            var data = new WeatherResult()
            {
                WindUnits = WindUnits.KPH,
                TempUnitChoosen = TempUnits.Celsius,
                AverageTemp = 10.0,
                Location = "Poole",
                AverageWindSpeed = 20
            };
            //act
            var result = _sut.ProcessAnyRule(data);
            //assert
            result.AverageTemp.ShouldBe(15);
        }

        [Fact]
        public void When_Temp_is_10_4c_the_value_returned_is_15c()
        {
            //arrange
            var data = new WeatherResult()
            {
                WindUnits = WindUnits.KPH,
                TempUnitChoosen = TempUnits.Celsius,
                AverageTemp = 10.4,
                Location = "Poole",
                AverageWindSpeed = 20
            };
            //act
            var result = _sut.ProcessAnyRule(data);
            //assert
            result.AverageTemp.ShouldBe(15);
        }

        [Fact]
        public void When_Temp_is_68f_the_value_returned_is_59f()
        {
            //arrange
            var data = new WeatherResult()
            {
                WindUnits = WindUnits.KPH,
                TempUnitChoosen = TempUnits.Fahrenheit,
                AverageTemp = 68.0,
                Location = "Poole",
                AverageWindSpeed = 20
            };
            //act
            var result = _sut.ProcessAnyRule(data);
            //assert
            result.AverageTemp.ShouldBe(59);
        }

        [Fact]
        public void When_Temp_is_68_4f_the_value_returned_is_59f()
        {
            //arrange
            var data = new WeatherResult()
            {
                WindUnits = WindUnits.KPH,
                TempUnitChoosen = TempUnits.Fahrenheit,
                AverageTemp = 68.4,
                Location = "Poole",
                AverageWindSpeed = 20
            };
            //act
            var result = _sut.ProcessAnyRule(data);
            //assert
            result.AverageTemp.ShouldBe(59);
        }

        [Fact]
        public void When_Wind_is_8kph_the_value_returned_is_12kph()
        {
            //arrange
            var data = new WeatherResult()
            {
                WindUnits = WindUnits.KPH,
                TempUnitChoosen = TempUnits.Fahrenheit,
                AverageTemp = 20,
                Location = "Poole",
                AverageWindSpeed = 8
            };
            //act
            var result = _sut.ProcessAnyRule(data);
            //assert
            result.AverageWindSpeed.ShouldBe(12);
        }

        [Fact]
        public void When_Wind_is_10mph_the_value_returned_is_7_5kph()
        {
            //arrange
            var data = new WeatherResult()
            {
                WindUnits = WindUnits.MPH,
                TempUnitChoosen = TempUnits.Fahrenheit,
                AverageTemp = 20,
                Location = "Poole",
                AverageWindSpeed = 10
            };
            //act
            var result = _sut.ProcessAnyRule(data);
            //assert
            result.AverageWindSpeed.ShouldBe(7.5);
        }
    }
}
