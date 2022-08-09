// Projekt.csproj
<PackageReference Include="Quartz.Extensions.DependencyInjection" Version="3.3.3" />


// WebApplicationBuilder (builder.Services)
Services.Configure<QuartzOptions>(q =>
{
    q.Scheduling.IgnoreDuplicates = true;
});

Services.AddTransient<QuartzBgService>();
Services.AddQuartz(x =>
{
    x.UseMicrosoftDependencyInjectionJobFactory();

    x.AddJob<QuartzBgService>(job =>
    {
        job.WithIdentity(nameof(QuartzBgService)).StoreDurably();
    });

    x.ScheduleJob<QuartzBgService>(tr =>
        tr.WithIdentity("Pravidelný BgService")
            .StartNow().WithSimpleSchedule(s => s.WithIntervalInSeconds(1).WithRepeatCount(10))
    );
});


// QuartzBgService
public class QuartzBgService : IJob {}