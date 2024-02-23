namespace SinusoidalSignalApi
{
    public class SinusoidalSignalApi
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthorization();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapPost("/sinusoidalsignal", Post)
                .WithName("Download sinusoidal chart")
                .WithOpenApi();

            app.Run();
        }

        public static IResult Post(double A, double Fd, double Fs, double N)
        {
            Chart.DrawSinusoidal(A, Fd, Fs, N).GetImage().Save("chart.png", System.Drawing.Imaging.ImageFormat.Png);
            var bytes = File.ReadAllBytes("chart.png");
            return Results.File(bytes, fileDownloadName: "chart.png");
        }
    }
}