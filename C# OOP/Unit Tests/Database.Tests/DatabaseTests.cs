using NUnit.Framework;
using System;
using System.Linq;


public class DatabaseTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ConstructorMustGetMorethan16Ints()
    {
        int[] nums = Enumerable.Range(1, 16).ToArray();
        Database database = new Database(nums);

        var expecterResult = 16;
        var actualResult = 16;
        Assert.AreEqual(actualResult, expecterResult);
    }

    [Test]

    public void ConstructorIfTheElementsAreMoreThan16Elements()
    {
        int[] nums = Enumerable.Range(1, 16).ToArray();
        Database database = new Database(nums);

        //actAssert
        Assert.Throws<InvalidOperationException>(() =>
        database.Add(10));

    }

    [Test]
    public void RemmoveShoudAddElementInTheLastIndex()
    {
        int[] nums = Enumerable.Range(1, 10).ToArray();
        Database database = new Database(nums);

        database.Remove();

        //Assert
        var expectedResult = 9;
        var actualResult = database.Fetch()[8];

        Assert.AreEqual(expectedResult, actualResult);

    }

    [Test]
    public void IfWeTryToDeleteElementFormEmptyDataBase()
    {

        Database database = new Database();

        Assert.Throws<InvalidOperationException>(() =>
        database.Remove());


    }

    [Test]

    public void TheFetchMethodShoudReturntheSameElements()
    {
        int[] nums = Enumerable.Range(1, 5).ToArray();
        Database database = new Database(nums);

        var item = database.Fetch();
        int[] expectedValue = { 1, 2, 3, 4, 5 };

        CollectionAssert.AreEqual(item, expectedValue);


    }
}

