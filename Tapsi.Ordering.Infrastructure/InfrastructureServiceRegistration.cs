using AutoMapper;
using Tapsi.Ordering.Application;
using Tapsi.Ordering.Application.Common;
using Tapsi.Ordering.Application.Contract.Services;
using Tapsi.Ordering.Application.Contract.SQLDB;
using Tapsi.Ordering.Domain;
using Tapsi.Ordering.Domain.Enums;
using Tapsi.Ordering.Infrastructure.Persistence;
using Tapsi.Ordering.Infrastructure.Service;
using Tapsi.Ordering.Infrastructure.ServiceImpls.MessagingImpl;
using Tapsi.Ordering.Infrastructure.SQLRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace Tapsi.Ordering.Infrastructure;

public static class InfrastructureServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        ConfigurationManager configurationManager,Configs configs)
    {
        //PostgreSql
       /* services.AddEntityFrameworkNpgsql().AddDbContext<CleanContext>(opt =>
            opt.UseNpgsql(configurationManager.GetConnectionString("CleanPostgresDB")));*/

        //Sql Server
        services.AddDbContext<Context>(options => options.UseSqlServer(configs.SQlConfigs.ConnectionString));

        services.AddScoped(typeof(IEmailService), typeof(EmailService));
        services.AddScoped(typeof(ISmsService), typeof(SmsService));
        services.AddScoped(typeof(IReportService), typeof(ReportService));
        services.AddScoped(typeof(ILogService), typeof(LogService));
        services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));
        services.AddTransient<IFileService>(s => new FileService(configs));
        services.AddTransient<IImageService>(s => new ImageService(configs));
        services.AddScoped(typeof(UserContext));
        services.AddScoped(typeof(DapperContext));
        services.AddScoped(typeof(ResponseGenerator));

        services.AddScoped(typeof(IMessageService), typeof(MessageService));
        services.AddScoped(typeof(En_MessagesImpl));
        services.AddScoped(typeof(Fa_MessagesImpl));


        return services;
    }
}