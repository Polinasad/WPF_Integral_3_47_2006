using WPF_Integral.Classes;

namespace WPF_Integral.Tests
{
    public class RectangleCalculatorTest
    {
        // Тест 1. Интеграл x^2 на [0; 10] = 1000/3 = 333,3333
        [Fact]
        public void Rectangle_XX_Return_Correct_Answer()
        {
            //Arrange (Подготовка)
            double upperLimit = 10;
            double lowerLimit = 0;
            int count = 1000000;
            Func<double, double> integralFunction = x => x * x;

            double expectedResult = 333.3333;

            //Act (Действия)
            RectangleCalculator calculator = new RectangleCalculator();
            double actualResult = calculator.Intagrate(lowerLimit, upperLimit, count, integralFunction);

            //Assert (Сравнение)
            Assert.Equal(expectedResult, actualResult, 0.01);
        }

        // Тест 2. Функция из варианта: 12x - ln(11x) - 11 на [1; 10] = 459,3931
        [Fact]
        public void Rectangle_Variant_Function_Return_Correct_Answer()
        {
            //Arrange (Подготовка)
            double upperLimit = 10;
            double lowerLimit = 1;
            int count = 1000000;
            Func<double, double> integralFunction = x => 12 * x - Math.Log(11 * x) - 11;

            double expectedResult = 459.3931;

            //Act (Действия)
            RectangleCalculator calculator = new RectangleCalculator();
            double actualResult = calculator.Intagrate(lowerLimit, upperLimit, count, integralFunction);

            //Assert (Сравнение)
            Assert.Equal(expectedResult, actualResult, 0.01);
        }

        // Тест 3. Интеграл константы 5 на [0; 10] = 5 * 10 = 50
        [Fact]
        public void Rectangle_Constant_Function_Return_Correct_Answer()
        {
            //Arrange (Подготовка)
            double upperLimit = 10;
            double lowerLimit = 0;
            int count = 1000;
            Func<double, double> integralFunction = x => 5;

            double expectedResult = 50;

            //Act (Действия)
            RectangleCalculator calculator = new RectangleCalculator();
            double actualResult = calculator.Intagrate(lowerLimit, upperLimit, count, integralFunction);

            //Assert (Сравнение)
            Assert.Equal(expectedResult, actualResult, 0.0001);
        }
    }
}
