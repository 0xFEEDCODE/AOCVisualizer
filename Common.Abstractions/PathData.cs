namespace Abstractions;

public record PathData
{
    public Point2D EndPoint;
    public Point2D[] PointsInBetween;
    public Point2D StartPoint;
}