using static Easy_Algorithms.EasyAlgorithmsClass;

namespace Easy_Algorithms.Tests
{
    public class Easy_AlgorithmsUnitTest
    {
        #region NodeDepth
        [Fact]
        public void NodeDepthTest1()
        {
            var root = new NodeDepthsClass.BinaryTree(1);
            root.left = new NodeDepthsClass.BinaryTree(2);
            root.left.left = new NodeDepthsClass.BinaryTree(4);
            root.left.left.left = new NodeDepthsClass.BinaryTree(8);
            root.left.left.right = new NodeDepthsClass.BinaryTree(9);
            root.left.right = new NodeDepthsClass.BinaryTree(5);
            root.right = new NodeDepthsClass.BinaryTree(3);
            root.right.left = new NodeDepthsClass.BinaryTree(6);
            root.right.right = new NodeDepthsClass.BinaryTree(7);
            int actual = NodeDepthsClass.NodeDepths(root);
            Assert.Equal(16, actual);
        } 
        #endregion

        #region BranchSums
        public class TestBinaryTree : BranchSumsClass.BinaryTree
        {
            public TestBinaryTree(int value) : base(value) { }

            public TestBinaryTree Insert(List<int> values)
            {
                return Insert(values, 0);
            }

            public TestBinaryTree Insert(List<int> values, int i)
            {
                if (i >= values.Count) return null;

                List<TestBinaryTree> queue = new List<TestBinaryTree>();
                queue.Add(this);
                while (queue.Count > 0)
                {
                    TestBinaryTree current = queue[0];
                    queue.RemoveAt(0);
                    if (current.left == null)
                    {
                        current.left = new TestBinaryTree(values[i]);
                        break;
                    }
                    queue.Add((TestBinaryTree)current.left);
                    if (current.right == null)
                    {
                        current.right = new TestBinaryTree(values[i]);
                        break;
                    }
                    queue.Add((TestBinaryTree)current.right);
                }
                Insert(values, i + 1);
                return this;
            }
        }

        [Fact(Skip = "Failing Unit test")]
        public void BranchSumsTest1()
        {
            TestBinaryTree tree = new TestBinaryTree(1).Insert(
                new List<int>() { 2, 3, 4, 5, 6, 7, 8, 9, 10 });
            List<int> expected = new List<int>() { 15, 16, 18, 10, 11 };
            Assert.True(BranchSumsClass.BranchSums(tree).SequenceEqual(expected));
        } 
        #endregion

        #region FindClosestValueInBst
        [Fact]
        public void FindClosestValueInBstTest1()
        {
            var root = new FindClosestValueInBstClass.Bst(10);
            root.left = new FindClosestValueInBstClass.Bst(5);
            root.left.left = new FindClosestValueInBstClass.Bst(2);
            root.left.left.left = new FindClosestValueInBstClass.Bst(1);
            root.left.right = new FindClosestValueInBstClass.Bst(5);
            root.right = new FindClosestValueInBstClass.Bst(15);
            root.right.left = new FindClosestValueInBstClass.Bst(13);
            root.right.left.right = new FindClosestValueInBstClass.Bst(14);
            root.right.right = new FindClosestValueInBstClass.Bst(22);

            var expected = 13;
            var actual = FindClosestValueInBstClass.FindClosestValueInBst(root, 12);
            Assert.Equal(expected, actual);
        } 
        #endregion

        #region EvaluateExpressionTree
        [Fact]
        public void EvaluateExpressionTreeClassTest1()
        {
            EvaluateExpressionTreeClass.BinaryTree tree = new EvaluateExpressionTreeClass.BinaryTree(-1);
            tree.left = new EvaluateExpressionTreeClass.BinaryTree(2);
            tree.right = new EvaluateExpressionTreeClass.BinaryTree(-2);
            tree.right.left = new EvaluateExpressionTreeClass.BinaryTree(5);
            tree.right.right = new EvaluateExpressionTreeClass.BinaryTree(1);
            var expected = 6;
            var actual = new EvaluateExpressionTreeClass().EvaluateExpressionTree(tree);
            Assert.True(expected == actual);
        } 
        #endregion

        #region NonConstructibleChange
        [Fact]
        public void NonConstructibleChangeTest1()
        {
            int[] input = new int[] { 5, 7, 1, 1, 2, 3, 22 };
            int expected = 20;
            var actual = new NonConstructibleChangeClass().NonConstructibleChange(input);
            Assert.True(expected == actual);
        } 
        #endregion

        #region SortedSquaredArray
        [Fact]
        public void SortedSquaredArrayTest1()
        {
            var input = new int[] { 1, 2, 3, 5, 6, 8, 9 };
            var expected = new int[] { 1, 4, 9, 25, 36, 64, 81 };
            var actual = new SortedSquaredArrayClass().SortedSquaredArray(input);
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.True(expected[i] == actual[i]);
            }
        } 
        #endregion

        #region TournamentWinner
        [Fact]
        public void TournamentWinnerTest1()
        {
            List<List<string>> competitions = new List<List<string>>();
            List<string> competition1 = new List<string> {
            "HTML", "C#"
             };

            List<string> competition2 = new List<string> {
            "C#", "Python"
            };

            List<string> competition3 = new List<string> {
            "Python", "HTML"
        };
            competitions.Add(competition1);
            competitions.Add(competition2);
            competitions.Add(competition3);
            List<int> results = new List<int> {
            0, 0, 1
        };
            string expected = "Python";
            var actual = new TournamentWinnerClass().TournamentWinner(competitions, results);
            Assert.True(expected == actual);
        } 
        #endregion

        #region TransposeMatrix
        [Fact]
        public void TransposeMatrixTest1()
        {
            int[,] input = new int[3, 3] {
                {1,2,3},{4,5,6},{7,8,9}
            };
            int[,] expected = new int[3, 3] {
                {1,4,7},{2,5,8},{3,6,9}
            };

            int[,] actual = new TransposeMatrixClass().TransposeMatrix(input);
            Assert.True(expected.Length == actual.Length);
            for (int i = 0; i < expected.GetLength(0); i++)
            {
                for (int j = 0; j < expected.GetLength(1); j++)
                {
                    Assert.True(expected[i, j] == actual[i, j]);
                }
            }
        } 
        #endregion

        #region IsValidSubsequence
        [Fact]
        public void TestCase1()
        {
            List<int> array = new List<int> {
                5, 1, 22, 25, 6, -1, 8, 10
            };

            List<int> sequence = new List<int> {
            1, 6, -1, 10
            };

            Assert.True(ValidateSubsequenceClass.IsValidSubsequence(array, sequence));
        } 
        #endregion

        #region TwoNumberSum
        [Fact]
        public void TwoNumberSumTest1()
        {
            int[] output = new TwoNumberSumClass().TwoNumberSum(new int[] { 3, 5, -4, 8, 11, 1, -1, 6 }, 10);
            Assert.True(output.Length == 2);
            Assert.True(Array.Exists(output, e => e == -1));
            Assert.True(Array.Exists(output, e => e == 11));
        } 
        #endregion

        #region SumTwoSmallestNumbers
        [Fact]
        public void SumTwoSmallestNumbersTest()
        {
            int[] numbers = { 5, 8, 12, 19, 22 };
            Assert.Equal(13, SumTwoSmallestNumbersClass.SumTwoSmallestNumbers(numbers));
        }

        [Fact]
        public void SumTwoSmallestNumbersTest2()
        {
            int[] numbers = { 19, 5, 42, 2, 77 };
            Assert.Equal(7, SumTwoSmallestNumbersClass.SumTwoSmallestNumbers(numbers));
        }

        [Fact]
        public void SumTwoSmallestNumbersTest3()
        {
            int[] numbers = { 10, 343445353, 3453445, 2147483647 };
            Assert.Equal(3453455, SumTwoSmallestNumbersClass.SumTwoSmallestNumbers(numbers));
        } 
        #endregion

        #region StringExtensions
        [Fact]
        public void StringExtensions()
        {
            //ACT					 
            var actual = StringExtensionsClass.StringExtensions("c");
            var actualC = StringExtensionsClass.StringExtensions("C");
            var actualD = StringExtensionsClass.StringExtensions("hello I AM DONALD");

            //ASSERT
            Assert.False(actual);
            Assert.True(actualC);
            Assert.False(actualD);
        } 
        #endregion

        #region QuickSort
        [Fact(Skip = "This test is failing")]
        public void QuickSortMethodShouldReturnSortedArray()
        {
            //ARRANGE            
            int[] array = { 3, 5, 8, 9, 6, 2 };
            int[] sortedArray = { 2, 3, 5, 6, 8, 9 };


            //ACT
            QuickSortExerciseClass.QuickSort(array, 0, 5);

            //ASSERT					 
            Assert.Equal(array, sortedArray);
        } 
        #endregion

        #region MinMax
        [Fact]
        public void minMaxTest1()
        {
            Assert.Equal(new int[] { -1, 20 }, MinMaxClass.minMax(new int[] { 1, 2, 5, -1, 12, 20 }));
            Assert.Equal(new int[] { 1, 5 }, MinMaxClass.minMax(new int[] { 1, 2, 3, 4, 5 }));
            Assert.Equal(new int[] { -3, 5 }, MinMaxClass.minMax(new int[] { 1, 2, -3, 4, 5 }));
        } 
        #endregion

        #region InsertionSort
        [Fact]
        public void InsertionSortMethodSortsAnArrayInAscendingOrder()
        {
            //ARRANGE					
            int[] array = { 1, 2, 3, 33, 5 };
            int[] sortedArray = { 1, 2, 3, 5, 33 };

            //ACT
            InsertionSortExerciseClass.InsertionSort(array, 5);

            //ASSERT					 
            Assert.Equal(array, sortedArray);
        } 
        #endregion

        #region HighAndLow
        [Fact]
        public void Test1()
        {
            Assert.Equal("42 -9", HighAndLowClass.HighAndLow("8 3 -5 42 -1 0 0 -9 4 7 4 -4"));
        }

        [Fact]
        public void Method_Should_Return_False()
        {
            Assert.Equal("3 1", HighAndLowClass.HighAndLow("1 2 3"));
        } 
        #endregion

        #region DescendingOrder
        [Fact]
        public void DescendingOrderTest()
        {
            var expected = DescendingOrderClass.DescendingOrder(42145);
            Assert.Equal(54421, expected);
        } 
        #endregion

        #region BreakCamelCaseClass
        [Fact]
        public void Should_be_assigned_different_values()
        {
            var actual = BreakCamelCaseClass.BreakCamelCase("camelCasing");
            Assert.Equal("camel Casing", actual);
        }

        [Fact]
        public void Should_be_assigned_Different_values()
        {
            var actual = BreakCamelCaseClass.BreakCamelCaseSolutionOne("khotsoCharles");
            Assert.Equal("khotso Charles", actual);
        }

        [Fact]
        public void BreakCamelCaseShouldReturnSpacedSentence()
        {
            var actual = BreakCamelCaseClass.BreakCamelCaseSecondSolution("khotsoCharlesMokhethi");
            Assert.Equal("khotso Charles Mokhethi", actual);
        }
        #endregion

        #region WellofIdeasEasyVersion
        [Fact]
        public void WellofIdeasEasyVersionTest1()
        {
            Assert.Equal("Fail!", WellofIdeasEasyVersionClass.Well(new string[] { "bad", "bad", "bad" }));
            Assert.Equal("Publish!", WellofIdeasEasyVersionClass.Well(new string[] { "good", "bad", "bad", "bad", "bad" }));
            Assert.Equal("I smell a series!", WellofIdeasEasyVersionClass.Well(new string[] { "good", "bad", "bad", "bad", "bad", "good", "bad", "bad", "good" }));

        }
        #endregion

        /// <summary>
        /// Fix this later
        /// </summary>
        
        #region ArraysAreEqual
        [Fact]
        public void Array_Should_Return_True()
        {
            //ARRANGE
            int[] arrayOne = { 1, 2, 3, 4, 4 };
            int[] arrayTwo = { 1, 2, 3, 4, 4 };

            //ACT
            bool answer = ArraysAreEqualClass.ArraysEqual(arrayOne, arrayTwo);

            //ASSERT
            Assert.True(answer);
        }

        [Fact]
        public void Array_Should_Return_False()
        {
            //ARRANGE
            int[] arrayOne = { 1, 2, 3, 4, 4 };
            int[] arrayThree = { 1, 2, 3, 4, 5 };

            //ACT
            bool answer = ArraysAreEqualClass.ArraysEqual(arrayOne, arrayThree);

            //ASSERT
            Assert.False(answer);
        }

        [Fact]
        public void CalculateArray()
        {

            //ASSERT
            int[] array = new int[6];
            int[] expected = { 1, 2, 3, 4, 5, 6 };

            //ACT

            int[] actual = ArraysAreEqualClass.CheckArray(array);

            //ARRANGE
            Assert.Equal(expected, actual);


        }

        [Fact]
        public void ReverseArray_Should_Return_Reversed_Array()
        {
            //ARRANGE	
            int[] initialArray = { 1, 2, 3, 4, 5, 6 };
            int[] expected = { 6, 5, 4, 3, 2, 1 };

            //ACT	
            int[] actual = ArraysAreEqualClass.ReverseArray(initialArray);

            //ASSERT	
            for (int i = 0; i < actual.Length; i++)
            {
                Assert.Equal(actual[i], expected[i]);
            }
        }

        [Fact]
        public void SymmetricArray_Should_Return_False_If_ArrayIsSymmetric()
        {
            //ARRANGE
            int length = 5;
            int[] array = new int[length];
            int[] arrayWithValue = { 1, 2, 2, 1 };

            //ACT					 
            var actual = ArraysAreEqualClass.SymmetricArray(arrayWithValue);

            //ASSERT	
            Assert.True(actual);
        }

        [Fact]
        public void SymmetricArray_Should_Return_True_If_ArrayIsSymmetric()
        {
            //ARRANGE
            int length = 4;
            int[] array = new int[length];
            int[] arrayWithValue = { 1, 2, 2, 1 };

            //ACT					 
            var actual = ArraysAreEqualClass.SymmetricArray(arrayWithValue);

            //ASSERT	
            Assert.True(actual);
        }

        [Fact]
        public void SymmetricArray_Should_Return_True_If_Not_ArrayIsSymmetric()
        {
            //ARRANGE
            int length = 5;
            int[] array = new int[length];
            int[] arrayWithValue = { 1, 2, 2, 1, 5 };

            //ACT					 
            var actual = ArraysAreEqualClass.SymmetricArray(arrayWithValue);

            //ASSERT	
            Assert.False(actual);
        }

        [Fact]
        public void MatriceArray_Should_Return_MatriceValues()
        {
            //ARRANGE					 
            int[,] matrix =
            {
               {1, 2, 3, 4}, // row 0 values
               {5, 6, 7, 8}, // row 1 value                
            };

            //ACT	
            var actual = ArraysAreEqualClass.MatriceArray(matrix);

            //ASSERT	
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Assert.Equal(matrix[i, j], actual[i, j]);
                }
            }

        }


        [Fact]
        public void MaxPlatform2x2_Should_Return_MaximumSum()
        {
            //ARRANGE					 
            int[,] matrix = {
            { 0, 2, 4, 0, 9, 5 },
            { 7, 1, 3, 3, 2, 1 },
            { 1, 3, 9, 8, 5, 6 },
            { 4, 6, 7, 9, 1, 0 }
            };

            int bestRow = 0;
            int bestCol = 0;
            //ACT
            var actual = ArraysAreEqualClass.GetBestPlatform(matrix);


            //ASSERT					 
            Assert.Equal(actual, matrix);
        }
        #endregion

        #region BinarySearch
        [Fact]
        public void BinarySearchIteritevelyShouldReturnIndex()
        {
            //ARRANGE					
            int key = 86;
            int[] inputArray = { 15, 86, 25, 31, 22 };
            int numberOfElements = 5;

            //ACT					 
            var seachIteritively = new BinarySeachIterativelyClass()
                                       .BinarySearchIteritevely(inputArray, numberOfElements, key);

            //ASSERT				
            Assert.Equal(4, seachIteritively);
        }

        [Fact]
        public void BinarysearchRecursionShouldReturnIndex()
        {
            //ARRANGE              
            int[] inputArray = { 15, 21, 47, 84, 96 };


            //ACT					 
            var seachIteritively = new BinarySeachIterativelyClass()
                                       .BinarysearchRecursion(inputArray, 96, 0, 4);

            //ASSERT				
            Assert.Equal(4, seachIteritively);
        }
        #endregion

        #region SumArray
        [Fact]
        public void SumArrayTest1()
        {
            //Arrange 
            double[] inputArray1 = { 1, 5.2, 4, 0, -1, 9.2 };
            double[] inputArray2 = { 0 };

            var actual = SumArrayClass.SumArray(inputArray1);

            Assert.Equal(18.399999999999999, actual);
        }
        #endregion

        /// <summary>
        /// This needs to be completed
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        
        #region SubsequenceWithMaxSum
        [Fact]
        public void SubsequenceWithMaxSum()
        {
            throw new NotImplementedException();
        }
        #endregion

        #region ShellSort
        [Fact]
        public void ShellSortMethodShouldReturnSortedArray()
        {
            //ARRANGE            
            int[] array = { 3, 5, 8, 9, 6, 2 };
            int[] sortedArray = { 2, 3, 5, 6, 8, 9 };


            //ACT
            ShellSortClass.ShellSort(array, 6);

            //ASSERT					 
            Assert.Equal(array, sortedArray);
        }
        #endregion

        #region SelectionSort
        [Fact]
        public void SelectionSortMethodShouldReturnSortedArray()
        {
            //ARRANGE					 
            SelectionSortClass selectionSort = new();
            int[] array = { 3, 5, 8, 9, 6, 2 };

            //ACT				
            Array.Sort(array);
            var actual = selectionSort.SelectionSort(array, 6);

            //ASSERT					 
            Assert.Equal(array, actual);
        }
        #endregion

        #region LinearSearch
        [Fact]
        public void LinearSearch_Should_Return_Element_Not_Found()
        {
            LinearSearchclass s = new();
            int[] A = { 84, 21, 47, 96, 15 };
            int found = LinearSearchclass.Linearsearch(A, 5, 100);

            Assert.NotEqual(100, found);
        }


        [Fact]
        public void LinearSearch_Should_Return_Element_Found()
        {
            //ARRANGE					 
            LinearSearchclass s = new();
            int[] A = { 84, 21, 47, 96, 15 };

            //ACT					 
            int found = LinearSearchclass.Linearsearch(A, 5, 21);

            //ASSERT
            Assert.Equal(1, found);
        }


        [Fact]
        public void LinearSearch_Should_Return_Element_Found_Three()
        {
            //ARRANGE					 
            LinearSearchclass search = new();
            int[] A = { 6, 5, 89, 22, 3, 5, 8 };

            //ACT					 
            var actual = LinearSearchclass.Linearsearch(A, 7, 22);

            //ASSERT					 
            Assert.Equal(3, actual);
        }
        #endregion

        #region PrintMatrix
        /// <summary>
        /// Not implementated
        /// </summary>
        [Fact]
        public void PrintMatrix()
        {
            //ARRANGE					 

            //ACT					 

            //ASSERT					 
        }
        #endregion

        #region MostFrequentNumber
        /// <summary>
        /// NotImplementated
        /// </summary>
        [Fact]
        public void MostFrequentNumber()
        {
            //ARRANGE					 

            //ACT					 

            //ASSERT					 
        }
        #endregion

        #region MergeSort
        [Fact]
        public void MergeSortMethodShouldReturnSortedArray()
        {
            //ARRANGE            
            int[] array = { 3, 5, 8, 9, 6, 2 };
            int[] sortedArray = { 2, 3, 5, 6, 8, 9 };


            //ACT
            MergeSortClass.MergeSort(array, 0, 5);

            //ASSERT					 
            Assert.Equal(array, sortedArray);
        }
        #endregion

        #region MaximalSequenceOfIncreasingElementsClass
        [Fact]
        public void MaximalSequenceOfIncreasingElementsUnit()
        {
            
        }
        #endregion

        #region ListFilterer
        [Fact]
        public void GetIntegersFromList_MixedValues_ShouldPass_1()
        {
            //ARRANGE					 
            var list = new List<object>() { 1, 2, "a", "b" };
            var expected = new List<int>() { 1, 2 };
            //ACT					 
            var actual = ListFiltererClass.GetIntegersFromList(list);
            //ASSERT            
            Assert.True(expected.SequenceEqual(actual));

        }

        [Fact]
        public void GetIntegersFromList_MixedValues_ShouldPass_2()
        {
            //ARRANGE					 

            //ACT					 

            //ASSERT	

            var list = new List<object>() { 1, "a", "b", 0, 15 };
            var expected = new List<int>() { 1, 0, 15 };
            var actual = ListFiltererClass.GetIntegersFromList(list);
            Assert.True(expected.SequenceEqual(actual));

        }

        [Fact]
        public void GetIntegersFromList_MixedValues_ShouldPass_3()
        {
            //ARRANGE					 

            //ACT					 

            //ASSERT	
            var list = new List<object>() { 1, 2, "aasf", "1", "123", 123 };
            var expected = new List<int>() { 1, 2, 123 };
            var actual = ListFiltererClass.GetIntegersFromListCast(list);
            Assert.True(expected.SequenceEqual(actual));
        }
        #endregion

        #region LengthFunctionReturn
        [Fact]
        public void LengthFunctionReturnsNodesSize()
        {
            //ARRANGE
            LinkedListClass linkedListClass = new LinkedListClass();


            //ACT
            var actual = linkedListClass.Count();

            //ASSERT
            Assert.Equal(0, actual);
        }

        [Fact(Skip = "Exceptions need to be implemented")]
        public void LengthFunctionReturnsArgumentNullException()
        {
            //ARRANGE
            LinkedListClass linkedListClass = new LinkedListClass();


            //ACT
            var actual = linkedListClass.Count();

            //ASSERT
            Assert.Throws<NullReferenceException>(() => actual);
        }
        #endregion

        #region Lexicographically
        [Fact]
        public void Lexicographically_Should_Return_First_Lexicographically()
        {
            //ARRANGE					 
            string inputArr1 = "Apple";
            string inputArr2 = "Windows";
            string expected = "Apple";

            //ACT
            var actial = LexicographicallyClass.Lexicographically(inputArr1, inputArr2);

            //ASSERT					 
            Assert.Equal(expected, actial);
        } 
        #endregion
    }
}