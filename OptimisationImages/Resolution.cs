namespace OptimisationImages;

public record Resolution(string Name, int Width)
{
    public static readonly Resolution[] All =
    [
        new("1080p", 1920),
        new("720p",  1280),
        new("480p",   854),
    ];
}
