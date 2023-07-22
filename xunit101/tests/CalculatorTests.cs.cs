namespace tests;
using myapp;
public class CalculatorTests
{
    [Fact]
   public void AddReturnsCorrectSum()
   {
    // Arrange
    var calc= new Calculator();
    // Act
    var result=calc.Add(5,10);
    // Assert
    Assert.Equal(15,result);

   }   
   [Fact]
   public void SubtractReturnCorrectDifference()
   {
    // Arrange
    var calc=new Calculator();
    // Act
    var result= calc.Subtract(10,5);
    // Assert
    Assert.Equal(5,result);
   }
   [Fact]
   public void MultiplyReturnCorrectProduct()
   {
    // Arrange
    var calc=new Calculator();
    // Act
    var result=calc.Multiply(5,10);
    // Assert
    Assert.Equal(50,result);
   }
   [Fact]
   public void DivideReturnCorrectQuotient()
   {
    // Arrange
    var calc=new Calculator();
    // Act
    var result=calc.Divide(10,5);
    // Assert
    Assert.Equal(2,result); 
   }
}