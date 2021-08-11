﻿using System;
using System.IO;
using System.Collections.Generic;
using HETS1Design;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace HETS1Design
{
    [TestClass]
     public class TestCasesTest
    {
        //Global variable used for testing
        string fileToCheckContent;
        //string inputFileToCheckContent;
        //string outputFileToCheckContent;


        //Works in a similar manner to "Before" in JUnit
        [TestInitialize]
        public void Initialize()
        {
            Submissions.ResetSubmissions();
            TestCases.ResetTestCases();
            fileToCheckContent = File.ReadAllText(@"..\..\..\Assets\Test Required FIles\TestCasesTest\GeneralTestCasesExample.txt");
            TestCases.ResetTestCases();
            //inputFileToCheckContent = File.ReadAllText(@"..\..\..\Assets\Test Required FIles\TestCasesTest\InputTestCasesExample.txt"); 
            //outputFileToCheckContent = File.ReadAllText(@"..\..\..\Assets\Test Required FIles\TestCasesTest\OutputTestCasesExample.txt");
        }

        [TestMethod]
        public void OnAddTestCaseTest()
        {
            //TODO            
        }

        [TestMethod]
        public void TestCasesBuilder_AddedSuccessfully()
        {
            //Arrange
            var inputFileText = "__[TC]\r\n3 4\r\n__[TC]\r\n35"; 
            var outputFileTest = "__[TC]\r\n1\r\n__[TC]\r\nWrong input"; 
            var listSize = 2; //1 test case added
            //Act
            TestCases.TestCasesBuilder(inputFileText, outputFileTest);
            //Assert
            Assert.AreEqual(listSize, TestCases.testCases.Count);            
        }

        [TestMethod]
        public void TestCasesBuilder_NotAddedSuccessfully()
        {
            TestCases.ResetTestCases();
            //Arrange
            var inputFileText = "__[TC]\r\n3 4\r\n__[TC]\r\n35"; 
            var outputFileTest = "__[TC]\r\n1";
            var listSize = 2; //Suposedely 2 test cases (but tester forgot to add the output field)
                              

            //Assert+Act
            Assert.ThrowsException<Exception>(() => TestCases.TestCasesBuilder(inputFileText, outputFileTest));
            Assert.AreNotEqual(listSize, TestCases.testCases.Count);
            Assert.AreEqual(0, TestCases.testCases.Count);
        }

        [TestMethod]
        public void CountTestCases_Test()
        {
            //Arrange
            //Act
            var result = TestCases.CountTestCases(fileToCheckContent);
            //Assert
            Assert.AreEqual(5, result);
            Assert.AreNotEqual(4, result);
            Assert.AreNotEqual(6, result);
        }

        [TestMethod]
        public void TC_or_TNC_ContainsEither()
        {
            //Arrange
            //Act
            var result1 = TestCases.TC_or_TNC("__[TC]\r\n4 5 6");
            var result2 = TestCases.TC_or_TNC("__[TNC]\r\n7");
            //Assert
            Assert.IsTrue(result1);
            Assert.IsFalse(result2);
        }

        [TestMethod]
        public void TestCasesSeparator_Seperates()
        {
            //Arrange
            //Act
            var result = TestCases.TestCasesSeparator(fileToCheckContent);           

            //Assert
            string[] expected = { "__[TC]\r\n9 5", "__[TNC]\r\n3 4\r\n1\r\n__[Bound] 5 9\r\n10", "__[TNC]\r\n7 3", "__[TC] 19\r\n", "__[TC] bla bla\r\n75" };
            List<string> expectedList = new List<string>(expected);

            CollectionAssert.AreEqual(expectedList, result);
        }

        [TestMethod]
        public void RemoveTCTNC_Removed()
        {
            //Arrange
            var testCase = "__[TC]\r\n3 4";
            //Act
            var result = TestCases.RemoveTCTNC(testCase);
            //Assert
            Assert.AreEqual("3 4", result);
        }

        [TestMethod]
        public void MultiplyTestCasesByBoundary_Multiplies()
        {
            //TODO (how to validate recursive method?)
        }

        [TestMethod]
        public void MultiplyTestCasesByEP_Multiplies()
        {
            //TODO (how to validate recursive method?)
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Submissions.ResetSubmissions();
            TestCases.ResetTestCases();
        }

    }
}
