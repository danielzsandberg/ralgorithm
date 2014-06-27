namespace RubiksCore
{
    public enum RubiksColor
    {
        Blue,
        Green,
        Orange,
        Red,
        White,
        Yellow
    }

    public enum TurningDirection
    {
        ThreeoClock,
        SixoClock,
        NineoClock
    }

    public enum RubiksDirection
    {
        Front,
        Back,
        Up,
        Down,
        Left,
        Right,
    }

    public enum Axes
    {
        X,
        Y,
        Z
    }

    enum RelativePosition
    {
        OnPointOne,
        Between1and2,
        OnPointTwo,
        Between2and3,
        OnPointThree,
        Between3and4,
        OnPointFour,
        Between4and1
    }
}