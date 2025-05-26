using UnityEngine;
using UnityEngine.UIElements;

public class CSharpPractice : MonoBehaviour
{
    private void Start()
    {


    }
}

public static class MyClass
{
    public static int AddTwoNumbers(int x, int y)
    {
        return x + y;
    }

    public static int AddTwoNumbers(NumbersCouple couple)
    {
        return AddTwoNumbers(couple.numberOne, couple.numberTwo);
    }


}

public class NumbersCouple
{
    public int numberOne { get; private set; } = 1;
    public int numberTwo;
    private int numberThree;

}
